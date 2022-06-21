using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Erasmus.Domain.Domain;
using Erasmus.Domain.DTO;
using Erasmus.Repository.Interface;
using Erasmus.Service.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Security.Claims;

namespace Erasmus.Web.Controllers
{
    public class OrganizerController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IOrganizerService _organizerService;
        private readonly IOrganizerRepository _organizerRepository;
        private readonly IUserRepository _userRepository;
        private readonly INotyfService _notyfService;
        private readonly IRepository<ProfilePhoto> _profilePhotoRepository;
        private readonly INonGovProjectService _nonGovProjectService;
        private readonly IParticipantApplicationService _applicationService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public OrganizerController(IOrganizerRepository organizerRepository, IMapper mapper,
           IOrganizerService organizerService, IUserRepository userRepository, INotyfService notyfService,
           IRepository<ProfilePhoto> profilePhotoRepository,
           INonGovProjectService nonGovProjectService,
           IParticipantApplicationService applicationService,
           IWebHostEnvironment webHostEnvironment)
        {
            _organizerRepository = organizerRepository;
            _organizerService = organizerService;
            _userRepository = userRepository;
            _mapper = mapper;
            _notyfService = notyfService;
            _profilePhotoRepository = profilePhotoRepository;
            _nonGovProjectService = nonGovProjectService;
            _applicationService = applicationService;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Profile()
        {
            // id is the id of the logged user
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userRepository.Get(userId);
            // get the organizer
            var organizer = _organizerRepository.Get(user.OrganizerId);
            var model = _mapper.Map<OrganizerProfileDto>(user);
            _mapper.Map(organizer, model);
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(string id)
        {
            var organizer = _organizerService.Get(id);
            var model = new OrganizerProfileDto();
            var user = _organizerService.GetUser(id);
            _mapper.Map(organizer, model);
            _mapper.Map(user, model);
            return View(model);
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EditProfile(OrganizerProfileDto model)
        {
            if(ModelState.IsValid)
            {
                _organizerService.Edit(model);
                _notyfService.Success("Profile Saved!");
                return RedirectToAction("Profile");
            }
            else
            {
                _notyfService.Error("Error updating profile. Please try again later!");
                return View("Profile", model);
            }
        }

        [HttpGet]
        public IActionResult EditProfilePhoto(string organizerId)
        {
            var user = _organizerRepository.GetOrganizerFromBase(organizerId);
            var profilePhoto = _profilePhotoRepository.Get(user.ProfilePhotoId);
            var model = new EditProfilePictureDto
            {
                UserId = organizerId,
                ProfilePhotoPath = user.Photo !=null?  user.Photo.PathOnDisk : ""
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UploadPhoto(EditProfilePictureDto model)
        {
            string uniqueFileName = null;

            if (model.ProfilePhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = model.UserId + "_" + model.ProfilePhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProfilePhoto.CopyTo(fileStream);
                }

                var organizer = _organizerRepository.Get(model.UserId);
                var user = _organizerRepository.GetOrganizerFromBase(model.UserId);
                var photo = new ProfilePhoto
                {
                    PathOnDisk = uniqueFileName,
                    User = user
                };
                _profilePhotoRepository.Insert(photo);

                user.Photo = photo;
                user.ProfilePhotoId = photo.Id;
                _userRepository.Update(user);
                _notyfService.Success("Profile Picture updated successfully");
                return RedirectToAction("Profile");
            }
            return RedirectToAction("Profile");
        }

        /*
         This endpoint shows all applications for projects created by the organizer
         */
        [HttpGet]
        public IActionResult Projects(string organizerId)
        {
            var projects = _nonGovProjectService.GetProjectsOrganizer(organizerId);
            var model = new ProjectsForOrganizerDto
            {
                Projects = projects,
                OrganizerId = organizerId
            };
            return View(model);
        }

        [HttpGet]
        public IActionResult ApplicationsForProject(Guid projectId)
        {
            return View();
        }


        [HttpGet]
        public IActionResult ApplicationsForEvent(Guid id)
        {
            var applications = _applicationService.GetAllForProject(id);
            var project = _nonGovProjectService.Get(id);
            var model = _mapper.Map<ApplicationsForProjectDto>(project);
            model.Applications = applications;
            return View(model);
        }

        [HttpGet]
        public IActionResult Approve(Guid id)
        {
            var application = _applicationService.Get(id);
            try
            {
                _applicationService.Approve(application);
                _notyfService.Success("Application approved");
            }
            catch (Exception ex)
            {
                _notyfService.Error("Something went wrong, try again later.");
            }

            return RedirectToAction("ApplicationsForEvent", new { id = application.NonGovProject.Id });
        }

        [HttpGet]
        public IActionResult Reject(Guid id)
        {
            var application = _applicationService.Get(id);
            try
            {
                _applicationService.Reject(application);
                _notyfService.Success("Application rejected");
            }
            catch (Exception ex)
            {
                _notyfService.Error("Something went wrong, try again later.");
            }
            return RedirectToAction("ApplicationsForEvent", new { id = application.NonGovProject.Id });

        }
    }
}

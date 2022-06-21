using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using Erasmus.Domain.Domain;
using Erasmus.Domain.DTO;
using Erasmus.Repository.Interface;
using Erasmus.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;


namespace Erasmus.Web.Controllers
{
    public class NonGovProjectsController : Controller
    {
        private readonly INonGovProjectService _nonGovProjectsService;
        private readonly INotyfService _notyfService;
        private readonly ICityService _cityService;
        private readonly IOrganizerService _organizerService;
        private readonly IMapper _mapper;
        private readonly IUploadedFileRepository _uploadedFileRepository;
        private readonly IParticipantApplicationService _participantApplicationService;
        private readonly IParticipantService _participantService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public NonGovProjectsController(INonGovProjectService nonGovProjectService, INotyfService notyfService, ICityService cityService, IOrganizerService organizerService, IMapper mapper,
            IUploadedFileRepository uploadedFileRepository, IParticipantApplicationService participantApplciationService,
            IParticipantService participantService, IWebHostEnvironment webHostEnvironment)
        {
            _nonGovProjectsService = nonGovProjectService;
            _notyfService = notyfService;
            _organizerService = organizerService;
            _cityService = cityService;
            _uploadedFileRepository = uploadedFileRepository;
            _participantApplicationService = participantApplciationService;
            _participantService = participantService;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(string searchString)
        {
            var projects = _nonGovProjectsService.GetAll();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var participant = _participantService.Get(userId);
            if (!String.IsNullOrEmpty(searchString))
            {
                var project1 = from p in projects where p.ProjectTitle.Contains(searchString) || p.ProjectDescription.Contains(searchString) select p;
                projects = project1.ToList();
            }

            var projectsDto = new List<ProjectDto>();
            foreach(var project in projects)
            {
                // check with a call to the repository
                var userHasApplied = User.IsInRole("Participant") && _participantApplicationService.GetForParticipantAndProject(userId, project.Id) != null;
                projectsDto.Add(new ProjectDto
                {
                    Project = project,
                    UserHasApplied = userHasApplied
                });
            }
            var model = new NonGovProjectsDto
            {
                Projects = projectsDto
            };
            return View(model);
        }

        public IActionResult Create()
        {
            var cities = _cityService.GetCityList(); 
            var model = new NonGovProjectDto { Cities = cities };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Organizer")]
        public IActionResult Create(NonGovProjectDto model)
        {
            string uniqueFileName = null;

            if (model.ProjectPhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "projectimages");
                uniqueFileName = model.ProjectId + "_" + model.ProjectPhoto.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProjectPhoto.CopyTo(fileStream);
                }

               model.ProjectPhotoPath = uniqueFileName;
            }
            var organizerId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            model.NonGovProjectOrganizerId = organizerId;
            var projectCreated = _nonGovProjectsService.Create(model);
            if(projectCreated)
            {
                _notyfService.Success("Event created successfully!");
                return RedirectToAction("Index");
            }

            return null;

        }

        [HttpGet]
        public IActionResult Edit(Guid id)
        {
            var project = _nonGovProjectsService.Get(id);
            var cities = _cityService.GetCityList();
            var model = _mapper.Map<NonGovProjectDto>(project);
            model.ProjectId = id;
            model.Cities = cities;
 

            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(NonGovProjectDto model)
        {
            var project = _nonGovProjectsService.Get(model.ProjectId);
            if (model.ProjectPhoto != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "projectimages");
                string uniqueFileName = Guid.NewGuid() + "_" + model.ProjectId + "_" + model.ProjectPhoto.FileName;

                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ProjectPhoto.CopyTo(fileStream);
                }
                
                if(!string.IsNullOrEmpty(model.ProjectPhotoPath))
                {
                    FileInfo previousPhoto = new FileInfo(Path.Combine(uploadsFolder, model.ProjectPhotoPath));
                    if (previousPhoto.Exists)
                    {
                        previousPhoto.Delete();
                    }
                }
               
                model.ProjectPhotoPath = uniqueFileName;
            }

            var editSuccessful = _nonGovProjectsService.Edit(model);
            if(editSuccessful)
            {
                _notyfService.Success("Event edited!");
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error("Error updating event!");
                return View(model);
            }
            
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var projectDeleted = _nonGovProjectsService.Delete(id);
            if (projectDeleted)
            {
                _notyfService.Success("Event deleted successfully!");
                return RedirectToAction("Index");
            }
            else
            {
                _notyfService.Error("Error deleting event!");
                return RedirectToAction("Index");
            }

        }

        [HttpGet]
        [Authorize]
        public IActionResult Details(Guid eventid)
        {
            var project = _nonGovProjectsService.Get(eventid);
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var model = _mapper.Map<ProjectDetailsDto>(project);
            model.UploadedFilesForUser = _uploadedFileRepository.GetFilesForUserAndEvent(userId, eventid);
            model.UserHasApplied = _participantApplicationService.GetForParticipantAndProject(userId, eventid) != null;
            return View(model);
        }
    }
}

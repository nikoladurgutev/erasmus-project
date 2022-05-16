using Erasmus.Domain.Domain;
using Erasmus.Domain.DomainModels;
using Erasmus.Domain.DTO;
using Erasmus.Repository.Implementation;
using Erasmus.Repository.Interface;
using Erasmus.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System;
using System.IO;
using System.Security.Claims;

namespace Erasmus.Web.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly INonGovProjectService _projectService;
        private readonly IRepository<UploadedFile> _uploadedFileRepository;
        private readonly IUserRepository _userRepository;
        private readonly IParticipantsRepository _participantRepository;
        public ParticipantController(INonGovProjectService projectService, IRepository<UploadedFile> uploadedFileRepository, IUserRepository userRepository,
            IParticipantsRepository participantRepository)
        {
            _projectService = projectService;
            _uploadedFileRepository = uploadedFileRepository;
            _userRepository = userRepository;
            _participantRepository = participantRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult UploadFiles(Guid eventId)
        {
            var project = _projectService.Get(eventId);
            if(project != null)
            {
                var model = new ApplyToEventDto
                {
                    ProjectId = project.Id,
                    Project = project
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Index", "NonGovProjects");
            }
        }

        [HttpPost]
        public IActionResult UploadFiles(ApplyToEventDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier).ToString();
            var project = _projectService.Get(model.ProjectId);
            model.Project = project;
            var participant = _participantRepository.Get(userId);
            try
            {
                if (model.CV != null)
                {
                    string uploadFolder = $"{Directory.GetCurrentDirectory()}\\ProjectFiles\\";
                    string fileToUpload = uploadFolder + userId + "_" + model.ProjectId + "_" + model.CV.FileName;

                    using (FileStream fs = System.IO.File.Create(fileToUpload))
                    {
                        model.CV.CopyTo(fs);
                        fs.Flush();
                    }
                    var userToFile = new UploadedFile
                    {
                        UserId = userId,
                        FileName = model.CV.FileName,
                        ProjectId = model.ProjectId,
                        User = participant,
                        PathOnDisk = fileToUpload
                    };
                    _uploadedFileRepository.Insert(userToFile);
                    return RedirectToAction("Details", "NonGovProjects", new { id = model.ProjectId});
                }
                
            }
            catch
            {
                // sedn toastr that something is wrong
            }


            return View(model);
        }

        public IActionResult ShowUploadedFile(Guid id)
        {
            var file = _uploadedFileRepository.Get(id);
            byte[] bytes = System.IO.File.ReadAllBytes(file.PathOnDisk);
            return File(bytes, "application/pdf");
        }


    }
}

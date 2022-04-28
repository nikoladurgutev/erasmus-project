using AspNetCoreHero.ToastNotification.Abstractions;
using Erasmus.Domain.Domain;
using Erasmus.Domain.DTO;
using Erasmus.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;

namespace Erasmus.Web.Controllers
{
    public class NonGovProjectsController : Controller
    {
        private readonly INonGovProjectService _nonGovProjectsService;
        private readonly INotyfService _notyfService;
        private readonly ICityService _cityService;
        private readonly IOrganizerService _organizerService;
        public NonGovProjectsController(INonGovProjectService nonGovProjectService, INotyfService notyfService, ICityService cityService, IOrganizerService organizerService)
        {
            _nonGovProjectsService = nonGovProjectService;
            _notyfService = notyfService;
            _organizerService = organizerService;
            _cityService = cityService;
        }
        public IActionResult Index()
        {
            var projects = _nonGovProjectsService.GetAll();
            var model = new NonGovProjectsDto
            {
                Projects = projects
            };
            return View(model);
        }

        public IActionResult Create()
        {
            var cities = _cityService.GetCityList(); 
            var model = new CreateNonGovProjectDto { Cities = cities };
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Organizer")]
        public IActionResult Create(CreateNonGovProjectDto model)
        {
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
            var model = new CreateNonGovProjectDto
            {
                Deadline = project.Deadline,
                StartDate = project.StartDate,
                EndDate = project.EndDate,
                ProjectTitle = project.ProjectTitle,
                ProjectDescription = project.ProjectDescription,
                ProjectType = project.ProjectType,
                Cities = cities,
                SelectedCityId = project.CityId,
                ProjectId = id
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(CreateNonGovProjectDto model)
        {
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

    }
}

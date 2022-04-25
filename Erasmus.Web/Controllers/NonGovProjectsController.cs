using AspNetCoreHero.ToastNotification.Abstractions;
using Erasmus.Domain.Domain;
using Erasmus.Domain.DTO;
using Erasmus.Service.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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

    }
}

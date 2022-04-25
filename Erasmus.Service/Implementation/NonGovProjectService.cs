using Erasmus.Domain.Domain;
using Erasmus.Domain.DomainModels;
using Erasmus.Domain.DTO;
using Erasmus.Repository.Implementation;
using Erasmus.Repository.Interface;
using Erasmus.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Erasmus.Service.Implementation
{
    public class NonGovProjectService : INonGovProjectService
    {
        private readonly IRepository<NonGovProject> _repository;
        private readonly IOrganizerRepository _organizerRepository;
        private readonly IRepository<NonGovProjectOrganizer> _organizerToProjectRepsoitory;
        public NonGovProjectService(IRepository<NonGovProject> repository, IOrganizerRepository organizerRepository, IRepository<NonGovProjectOrganizer> organizerToProjectRepository)
        {
            _repository = repository;
            _organizerRepository = organizerRepository;
            _organizerToProjectRepsoitory = organizerToProjectRepository;
        }
        public bool Create(CreateNonGovProjectDto project)
        {
            try
            {
                NonGovProject nonGovProject = new NonGovProject();
                nonGovProject.CityId = project.SelectedCityId;
                nonGovProject.ProjectTitle = project.ProjectTitle;
                nonGovProject.ProjectDescription = project.ProjectDescription;
                nonGovProject.ProjectType = project.ProjectType;
                Organizer organizer = _organizerRepository.Get(project.NonGovProjectOrganizerId);

                // save the project
                _repository.Insert(nonGovProject);


                // M-N table
                var relation = new NonGovProjectOrganizer
                {
                    NonGovProject = nonGovProject,
                    NonGovProjectId = nonGovProject.Id,
                    Organizer = organizer,
                    OrganizerId = organizer.UserId
                };

                // save the relation
                _organizerToProjectRepsoitory.Insert(relation);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public List<NonGovProject> GetAll()
        {
            return _repository.GetAll().ToList();
        }
    }
}

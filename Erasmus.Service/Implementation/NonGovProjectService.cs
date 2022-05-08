using AutoMapper;
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
        private readonly IRepository<City> _cityRepository;
        private readonly IMapper _mapper;
        public NonGovProjectService(IRepository<NonGovProject> repository, IOrganizerRepository organizerRepository, IRepository<NonGovProjectOrganizer> organizerToProjectRepository, IRepository<City> cityRepository, IMapper mapper)
        {
            _repository = repository;
            _organizerRepository = organizerRepository;
            _organizerToProjectRepsoitory = organizerToProjectRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
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

        public bool Delete(Guid id)
        {
            try
            {
                var project = _repository.Get(id);
                
                // delete all records in M-N project - orgniser table
                IList<NonGovProjectOrganizer> records = _organizerToProjectRepsoitory.GetAll().Where(z => z.NonGovProjectId == id).ToList();
                foreach(var record in records)
                {
                    _organizerToProjectRepsoitory.Delete(record);
                }

                _repository.Delete(project);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(CreateNonGovProjectDto model)
        {
            try
            {
                var project = _repository.Get(model.ProjectId);
                var selectedCity = _cityRepository.Get(model.SelectedCityId);
                _mapper.Map(model, project);
                _repository.Update(project);
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
            
        }

        public NonGovProject Get(Guid id)
        {
            return _repository.Get(id);
        }

        public List<NonGovProject> GetAll()
        {
            return _repository.GetAll().ToList();
        }
    }
}

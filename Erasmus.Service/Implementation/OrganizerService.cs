using AutoMapper;
using Erasmus.Domain.Domain;
using Erasmus.Domain.DomainModels;
using Erasmus.Domain.DTO;
using Erasmus.Repository.Interface;
using Erasmus.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Service.Implementation
{
    public class OrganizerService : IOrganizerService
    {
        private readonly IOrganizerRepository _organizerRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        public OrganizerService(IOrganizerRepository organizerRepository,
            IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;   
            _organizerRepository = organizerRepository;
            _userRepository = userRepository;
        }

        public void Edit(OrganizerProfileDto model)
        {
            var organizer = _organizerRepository.Get(model.OrganizerId);
            var user = _organizerRepository.GetOrganizerFromBase(model.OrganizerId);
            _mapper.Map(model, organizer);
            _mapper.Map(model, user);
            _organizerRepository.Update(organizer);
            _userRepository.Update(user);
        }

        public Organizer Get(string id)
        {
            return _organizerRepository.Get(id);
        }

        public Organizer GetByMail(string mail)
        {
            return _organizerRepository.GetByMail(mail);
        }

        public ErasmusUser GetUser(string organizerId)
        {
            return _organizerRepository.GetUser(organizerId);
        }
    }
}

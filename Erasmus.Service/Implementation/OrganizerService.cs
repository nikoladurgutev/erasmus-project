using AutoMapper;
using Erasmus.Domain.Domain;
using Erasmus.Domain.DomainModels;
using Erasmus.Domain.DTO;
using Erasmus.Repository.Interface;
using Erasmus.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus.Service.Implementation
{
    public class OrganizerService : IOrganizerService
    {
        private readonly IOrganizerRepository _organizerRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IRepository<Email> _emailRepository;
        private readonly IEmailService _emailService;

        public OrganizerService(IOrganizerRepository organizerRepository,
            IMapper mapper, IUserRepository userRepository, IRepository<Email> emailRepository,
            IEmailService emailService)
        {
            _mapper = mapper;   
            _organizerRepository = organizerRepository;
            _userRepository = userRepository;
            _emailRepository = emailRepository;
            _emailService = emailService;
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

        public async Task<bool> SendMailForApprovedApplicationAsync(ParticipantApplication application)
        {
            Email email = new Email();
            StringBuilder sb = new StringBuilder();
            email.MailTo = application.Participant.BaseRecord.Email;
            sb.AppendLine("The application for the event: " + string.Concat("'", application.NonGovProject.ProjectTitle, ",") + "has been approved by the organizer");
            string Content = sb.ToString();
            email.Content = Content;
            email.Subject = "Application approved";
            email.Sent = true;
            _emailRepository.Insert(email);
            await _emailService.SendMailAsync(email, "See you soon,", null);
            return true;
        }

        public async Task<bool> SendMailForRejectedApplicationAsync(ParticipantApplication application)
        {
            Email email = new Email();
            StringBuilder sb = new StringBuilder();
            email.MailTo = application.Participant.BaseRecord.Email;
            sb.AppendLine("The application for the event: " + string.Concat("'", application.NonGovProject.ProjectTitle, ",") + "has been approved by the organizer");
            string Content = sb.ToString();
            email.Content = Content;
            email.Subject = "Application rejected";
            email.Sent = true;
            _emailRepository.Insert(email);
            await _emailService.SendMailAsync(email, "Kind regards,", null);
            return true;
        }
    }
}

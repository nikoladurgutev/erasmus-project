using AutoMapper;
using Erasmus.Domain.Domain;
using Erasmus.Domain.DTO;
using Erasmus.Repository.Interface;
using Erasmus.Service.Interface;
using MimeKit;
using MimeKit.Utils;
using Syncfusion.Pdf.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus.Service.Implementation
{
    public class ParticipantService : IParticipantService
    {
        private readonly IParticipantRepository _participantRepository;
        private readonly INonGovProjectRepository _nonGovProjectRepository;
        private readonly IParticipantApplicationRepository _participantApplicationRepository;
        private readonly IUploadedFileRepository _uploadedFileRepository;
        private readonly IRepository<Email> _emailRepository;
        private readonly IEmailService _emailService;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;


        public ParticipantService(IParticipantRepository participantRepository, INonGovProjectRepository nonGovProjectRepository,
            IParticipantApplicationRepository participantApplicationRepository, IUploadedFileRepository uploadedFileRepository,
            IRepository<Email> emailRepository, IEmailService emailService, IMapper mapper, IUserRepository userRepository)
        {
            _participantRepository = participantRepository;
            _nonGovProjectRepository = nonGovProjectRepository;
            _participantApplicationRepository = participantApplicationRepository;
            _uploadedFileRepository = uploadedFileRepository;
            _emailRepository = emailRepository;
            _emailService = emailService;
            _mapper = mapper;   
            _userRepository = userRepository;
        }

        public async Task<bool> Apply(string participantId, Guid projectId)
        {
            var participant = _participantRepository.Get(participantId);
            var project = _nonGovProjectRepository.Get(projectId);
            var files = _uploadedFileRepository.GetFilesForUserAndEvent(participantId, projectId);
            var application = new ParticipantApplication
            {
                NonGovProject = project,
                NonGovProjectId = projectId,
                Participant = participant,
                ParticipantId = participantId,
                ParticipantUserId = participant.UserId,
                UploadedFiles = files,
                ReviewStatus = ApplicationStatus.InReview
            };
            _participantApplicationRepository.Insert(application);

            await SendMailToParticipant(participant, project, application.UploadedFiles);
            return true;
        }

        public void Edit(ParticipantProfileDto model)
        {
            var participant = _participantRepository.Get(model.ParticipantId);
            var user = _participantRepository.GetParticipantFromBase(model.ParticipantId);
            _mapper.Map(model, participant);
            _mapper.Map(model, user);
            _participantRepository.Update(participant);
            _userRepository.Update(user);
        }

        public Participant Get(string participantId)
        {
            return _participantRepository.Get(participantId);
        }

        public ErasmusUser GetUser(string participantId)
        {
             return _participantRepository.GetUser(participantId);
        }

        public bool SendMailToOrganizer(string mail)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SendMailToParticipant(Participant participant, NonGovProject project, ICollection<UploadedFile> uploadedFiles)
        {
            Email email = new Email();
            StringBuilder sb = new StringBuilder();
            email.MailTo = participant.BaseRecord.Email;
            var application = _participantApplicationRepository.GetForParticipantAndProject(participant.UserId, project.Id);
            sb.AppendLine("The application for the event: " + string.Concat("'", project.ProjectTitle, ",") + "has been successfully sent");
            string Content = sb.ToString();
            email.Content = Content;
            email.Subject = "Application submitted";
            email.Sent = true;
            _emailRepository.Insert(email);
            await _emailService.SendMailAsync(email, uploadedFiles);
            return true;
        }
    }
}

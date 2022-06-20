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
        public ParticipantService(IParticipantRepository participantRepository, INonGovProjectRepository nonGovProjectRepository,
            IParticipantApplicationRepository participantApplicationRepository, IUploadedFileRepository uploadedFileRepository,
            IRepository<Email> emailRepository, IEmailService emailService)
        {
            _participantRepository = participantRepository;
            _nonGovProjectRepository = nonGovProjectRepository;
            _participantApplicationRepository = participantApplicationRepository;
            _uploadedFileRepository = uploadedFileRepository;
            _emailRepository = emailRepository;
            _emailService = emailService;
        }

        public async Task<bool> Apply(string participantId, Guid projectId)
        {
            // if the participant has already applied, he should not be able to apply again
            var previousApplication = _participantApplicationRepository.GetForParticipantAndProject(participantId, projectId);
            if(previousApplication != null)
            {
                // delete the previous application
                _participantApplicationRepository.Delete(previousApplication);
            }

            var participant = _participantRepository.Get(participantId);
            var project = _nonGovProjectRepository.Get(projectId);
            var files = _uploadedFileRepository.GetFilesForUserAndEvent(participantId, projectId);
            var application = new ParticipantApplication
            {
                NonGovProject = project,
                NonGovProjectId = projectId,
                Participant = participant,
                ParticipantId = participant.Id,
                ParticipantUserId = participant.UserId,
                UploadedFiles = files,
                ReviewStatus = ApplicationStatus.InReview
            };
            _participantApplicationRepository.Insert(application);

            await SendMailToParticipantForSubmittedApplication(participant, project, application.UploadedFiles);
            return true;
        }

        public Participant Get(string participantId)
        {
            return _participantRepository.Get(participantId);
        }

        public bool SendMailToOrganizer(string mail)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> SendMailToParticipantForSubmittedApplication(Participant participant, NonGovProject project, ICollection<UploadedFile> uploadedFiles)
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
            await _emailService.SendMailAsync(email, "Good luck, ", uploadedFiles);
            return true;
        }
    }
}

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
        private readonly INonGovProjectService _nonGovProjectService;
        public ParticipantService(IParticipantRepository participantRepository, INonGovProjectRepository nonGovProjectRepository,
            IParticipantApplicationRepository participantApplicationRepository, IUploadedFileRepository uploadedFileRepository,
            IRepository<Email> emailRepository, IEmailService emailService, INonGovProjectService nonGovProjectService)
        {
            _participantRepository = participantRepository;
            _nonGovProjectRepository = nonGovProjectRepository;
            _participantApplicationRepository = participantApplicationRepository;
            _uploadedFileRepository = uploadedFileRepository;
            _emailRepository = emailRepository;
            _emailService = emailService;
            _nonGovProjectService = nonGovProjectService;
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
                ParticipantId = participant.Id,
                ParticipantUserId = participant.UserId,
                UploadedFiles = files,
                ReviewStatus = ApplicationStatus.InReview
            };
            _participantApplicationRepository.Insert(application);

            await SendMailToParticipant(participant, project, application.UploadedFiles);
            return true;
        }

        public Participant Get(string participantId)
        {
            return _participantRepository.Get(participantId);
        }
        public async Task<bool> SendMailToOrganizer(Participant participant, NonGovProject project)
        {
            NonGovProjectOrganizer nonGovProjectOrganizer = _nonGovProjectService.GetNonGovProjectOrganizer(project.Id);
            if (nonGovProjectOrganizer == null) {
                return true;
            }
            Email email = new Email();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("You have one new participant application for your project: " + string.Concat("'", project.ProjectTitle, "'.") + "The participant with email " + string.Concat("", participant.BaseRecord.Email, ",") + " send his application right now. You can check all details in your organizer profile.");

            email.MailTo = nonGovProjectOrganizer.Organizer.BaseRecord.Email;
            email.Subject = "New application for the project " + project.ProjectTitle;
            email.Content = stringBuilder.ToString();
            email.Sent = true;
            _emailRepository.Insert(email);
            await _emailService.SendMailToOrganizerAsync(email);
            return true;
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
            await Task.WhenAll(_emailService.SendMailAsync(email, uploadedFiles), SendMailToOrganizer(participant, project));
            return true;
        }
    }
}

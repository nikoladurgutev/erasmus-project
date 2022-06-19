using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.Domain
{
    // A participant can apply to a project once
    // if the application was rejected and new documents are uploaded, the application will erase the previous
    // Participant M - applies to - N NonGovProject
    // Application - Uploaded File - 1 - N
    public class ParticipantApplication : BaseEntity
    {
        public string ParticipantId { get; set; }
        public string ParticipantUserId { get; set; }
        public Participant Participant { get; set; }
        public Guid NonGovProjectId { get; set; }
        public NonGovProject NonGovProject { get; set; }
        public ICollection<UploadedFile> UploadedFiles { get; set; }
        // the participant application can be either approved, rejected or in review
        // if this is NotCompleted, the user still hasn't applied but might have some documents
        public ApplicationStatus ReviewStatus { get; set; }
    }
}

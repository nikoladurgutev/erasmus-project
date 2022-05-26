using Erasmus.Domain.Domain;
using Erasmus.Domain.DomainModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DTO
{
    public class ApplyToEventDto
    {
        public string ParticipantId { get; set; }
        public NonGovProject Project { get; set; }
        public Guid ProjectId { get; set; }
        public IFormFile CV { get; set; }
        public UploadedFile UploadedCV { get; set; }
        public IFormFile MotivationLetter { get; set; }
        public UploadedFile UploadedMotivation { get; set; }
        public List<UploadedFile> UploadedFilesForUser { get; set; }
        public ApplicationStatus ReviewStatus { get; set; }
    }
}

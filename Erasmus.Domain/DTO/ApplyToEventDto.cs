using Erasmus.Domain.DomainModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DTO
{
    public class ApplyToEventDto
    {
        public Guid ParticipantId { get; set; }
        public NonGovProject Project { get; set; }
        public Guid ProjectId { get; set; }
        public IFormFile CV { get; set; }
    }
}

using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DTO
{
    public class ApplicationsForProjectDto
    {
        public Guid ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime StartDate { get; set; }
        public List<ParticipantApplication> Applications { get; set; }
    }
}

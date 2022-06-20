using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DTO
{
    public class ParticipantApplicationDto
    {
        public ParticipantApplication Application { get; set; }
        public ApplicationStatus Status { get; set; }
    }
}

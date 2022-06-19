using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DTO
{
    public class ParticipantProfileDto
    {
        public string ParticipantId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ProfilePhoto ProfilePicture { get; set; }
    }
}

using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DTO
{
    public class OrganizerProfileDto
    {
        public string OrganizerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OrganizationName { get; set; }
        public string Location { get; set; }
        public string OrganizationContact { get; set; }
        public ProfilePhoto ProfilePicture { get; set; }
    }
}

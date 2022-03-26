using Erasmus.Domain.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DomainModels
{
    // User can be a young person who appies for Erasmus projects
    // the roles is not kept here, because it is a many to many table configired by .net
    public class ErasmusUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // only for admin users these properties will be present
        public Admin Admin { get; set; }
        public string AdminId { get; set; }
        // only for coordinators these properties will be present
        public Coordinator Coordinator { get; set; }
        public string CoordinatorId { get; set; }

        //only for participants these properties will be present
        public Participant Participant { get; set; }
        public string ParticipantId { get; set; }

        // only for students these properties will be present
        public Student Student { get; set; }
        public string StudentId { get; set; }


    }
}

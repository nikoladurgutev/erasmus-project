using Erasmus.Domain.Domain;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.Domain
{
    // User can be a young person who appies for Erasmus projects
    // the roles is not kept here, because it is a many to many table configired by .net
    public class ErasmusUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // only for admin users these properties will be present
        public virtual Admin Admin { get; set; }
        public Guid? AdminId { get; set; }
        // only for coordinators these properties will be present
        public virtual Coordinator Coordinator { get; set; }
        public Guid? CoordinatorId { get; set; }

        //only for participants these properties will be present
        public virtual Participant Participant { get; set; }
        public virtual string ParticipantId { get; set; }

        // only for students these properties will be present
        public virtual Student Student { get; set; }
        public Guid? StudentId { get; set; }

        public virtual Organizer Organizer { get; set; }
        public virtual string OrganizerId { get; set; }

        public Guid? ProfilePhotoId { get; set; }
        public ProfilePhoto Photo { get; set; }

    }
}

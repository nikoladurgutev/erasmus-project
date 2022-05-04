using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.Domain
{
    public class NonGovProjectOrganizer : BaseEntity
    {
        public string OrganizerId { get; set; }
        public virtual Organizer Organizer { get; set; }

        public Guid? NonGovProjectId { get; set; }
        public virtual NonGovProject NonGovProject { get; set; }
    }
}

using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DomainModels
{
    public class ErasmusProject : BaseEntity
    {
        public string ProjectTitle { get; set; }
        public string ProjectDescription { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<Admin> Admins { get; set; }

        public ICollection<Coordinator> Coordinators { get; set; }

        public ICollection<ErasmusProjectUniversity> ErasmusProjectUniversities { get; set; }

        // TODO: add foreign key to global admin who created the event

    }
}

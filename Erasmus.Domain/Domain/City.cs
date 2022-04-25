using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.Domain
{
    public class City : BaseEntity
    {
        public string Name { get; set; }
        public Guid CountryId { get; set; }
        public Country Country { get; set; }
        public virtual ICollection<University> Universities { get; set; }

        public virtual ICollection<NonGovProject> NonGovProjects { get; set; }
    }
}

using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.Domain
{
    public class ProjectType : BaseEntity
    {
        public string Type { get; set; }

        public ICollection<NonGovProject> NonGovProjects { get; set; }
    }
}

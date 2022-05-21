using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DomainModels
{
    public class NonGovProject : BaseEntity
    {
        public string ProjectTitle { get; set; }
        // TODO: create a table for type
        //public string ProjectType { get; set; } // ex. Language learning
        public Guid? ProjectTypeId { get; set; }
        public ProjectType ProjectType { get; set; }
        public string ProjectDescription { get; set; }

        public Guid CityId { get; set; }
        public City City { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<NonGovProjectOrganizer> NonGovProjectOrganizers { get; set; }


    }
}

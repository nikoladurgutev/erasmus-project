using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DomainModels
{
    public class NonGovProject : BaseEntity
    {
        public string ProjectTitle { get; set; }
        // TODO: create a table for type
        public string ProjectType { get; set; } // ex. Language learning

        public string ProjectDescription { get; set; }
        //TODO: add city table
        public string Location { get; set; }
        public DateTime Deadline { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}

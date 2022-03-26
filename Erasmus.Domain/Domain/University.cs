using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DomainModels
{
    public class University : BaseEntity
    {
        public string Name { get; set; }
        public string Location { get; set; }

        public ICollection<Faculty> Faculties { get; set; }

        public ICollection<ErasmusProjectUniversity> ErasmusProjectUniversities { get; set; }

    }
}

using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DomainModels
{
    public class University : BaseEntity
    {
        public string Name { get; set; }
        public Guid CityId { get; set; }
        public City City { get; set; }
        public ICollection<Faculty> Faculties { get; set; }
        public ICollection<ErasmusProjectUniversity> ErasmusProjectUniversities { get; set; }

    }
}

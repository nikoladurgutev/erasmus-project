using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DomainModels
{
    public class Faculty : BaseEntity
    {
        public string FacultyName { get; set; }
        // TODO: add city and address
        public string Location { get; set; }
        
        public ICollection<Student> Students { get; set; }
        public Coordinator Coordinator { get; set; }

        public Guid? UniversityId { get; set; }
        public University University { get; set; }
    }
}

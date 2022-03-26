using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Erasmus.Domain.Domain
{
    public class Student
    {
        [Key]
        public string Id { get; set; }
        public string UserId { get; set; }
        public ErasmusUser BaseRecord { get; set; }
        public Guid FacultyId { get; set; }
        public Faculty Faculty { get; set; }
    }
}

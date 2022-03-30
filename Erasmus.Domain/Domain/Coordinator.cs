using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Erasmus.Domain.Domain
{
    public class Coordinator : BaseEntity
    {
        public string UserId { get; set; }
        public ErasmusUser BaseRecord { get; set; }
        public Guid? FacultyId { get; set; }
        public Faculty Faculty { get; set; }


        public Guid? ErasmusProjectId { get; set; }
        public ErasmusProject ErasmusProject { get; set; }
    }
}

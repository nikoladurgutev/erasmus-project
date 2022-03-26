using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.Domain
{
    public class ErasmusProjectUniversity : BaseEntity
    {
        public Guid UniversityId { get; set; }
        public virtual University University { get; set; }

        public Guid ErasmusProjectId { get; set; }
        public virtual ErasmusProject ErasmusProject { get; set; }
    }
}

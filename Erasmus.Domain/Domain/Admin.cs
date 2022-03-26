using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Erasmus.Domain.Domain
{
    // Admin - IdentityUser is 1-1
    public class Admin : BaseEntity
    {
        public string UserId { get; set; }
        public virtual ErasmusUser BaseRecord { get; set; }

        public Guid ErasmusProjectId { get; set; }
        public ErasmusProject ErasmusProject { get; set; }

    }
}

using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Erasmus.Domain.Domain
{
    public  class Organizer
    {
        [Key]
        public string UserId { get; set; }
        public virtual ErasmusUser BaseRecord { get; set; }
        public string OrganizationName { get; set; }
        public string Location { get; set; }
        public string OrganizationContact { get; set; }

        public ICollection<NonGovProjectOrganizer> NonGovProjectOrganizers { get; set; }
    }
}

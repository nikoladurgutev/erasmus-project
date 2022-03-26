using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Erasmus.Domain.Domain
{
    public class Participant : BaseEntity
    {
        public string UserId { get; set; }
        public ErasmusUser BaseRecord { get; set; }
    }
}

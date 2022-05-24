using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.Domain
{
    public class ProfilePhoto : BaseEntity
    {
        public string PathOnDisk { get; set; }
        public ErasmusUser User { get; set; }
    }
}

using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.Domain
{
    // Country 1 - N City
    public class Country : BaseEntity
    {
        public string Name { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }
}

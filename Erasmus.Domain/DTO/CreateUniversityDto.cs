using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DTO
{
    public class CreateUniversityDto
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; }
        public Guid CityId { get; set; }
    }
}

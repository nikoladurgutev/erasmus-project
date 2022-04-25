using Erasmus.Domain.Domain;
using Erasmus.Repository.Interface;
using Erasmus.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Erasmus.Service.Implementation
{
    public class CityService : ICityService
    {
        private readonly IRepository<City> _cityRepository;
        public CityService(IRepository<City> cityRepository)
        {
            _cityRepository = cityRepository;
        }
        public List<City> GetAll()
        {
            return _cityRepository.GetAll().ToList();
        }

        public List<SelectListItem> GetCityList()
        {
            return _cityRepository.GetAll().Select(z => new SelectListItem
            {
                Text = z.Name,
                Value = z.Id.ToString()
            }).ToList();
        }
    }
}

using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Erasmus.Service.Interface
{
    public interface ICityService
    {
        public List<City> GetAll();

        // this method is used to populate the dropdowns
        public List<SelectListItem> GetCityList();
    }
}

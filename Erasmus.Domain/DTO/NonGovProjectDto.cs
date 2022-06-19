using Erasmus.Domain.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace Erasmus.Domain.DTO
{
    public class NonGovProjectDto
    {
        public Guid ProjectId { get; set; }
        public string ProjectTitle { get; set; }

        // TODO: create a table for type
        public ProjectType ProjectType { get; set; } // ex. Language learning

        public string ProjectDescription { get; set; }
      
        public DateTime Deadline { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }

        public string NonGovProjectOrganizerId { get; set; }

        public List<SelectListItem> Cities { get; set; }
        [Required]
        public Guid SelectedCityId { get; set; }
        public string ProjectPhotoPath { get; set; }
        public IFormFile ProjectPhoto { get; set; }
    }
}

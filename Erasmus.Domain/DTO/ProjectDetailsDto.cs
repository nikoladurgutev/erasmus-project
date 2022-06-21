using Erasmus.Domain.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Web.Mvc;

namespace Erasmus.Domain.DTO
{
    public class ProjectDetailsDto
    {
        public Guid ProjectId { get; set; }
        public string ProjectTitle { get; set; }

        public string ProjectType { get; set; } // ex. Language learning

        public string ProjectDescription { get; set; }

        public DateTime Deadline { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date, ErrorMessage = "Date only")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime EndDate { get; set; }
        public string NonGovProjectOrganizerId { get; set; }
        [Required]
        public Guid SelectedCityId { get; set; }
        public List<UploadedFile> UploadedFilesForUser { get; set; }
        public string ProjectPhotoPath { get; set; }
        public bool UserHasApplied { get; set; }
    }
}

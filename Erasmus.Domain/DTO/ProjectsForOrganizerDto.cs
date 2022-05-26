using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DTO
{
    public class ProjectsForOrganizerDto
    {
        public List<NonGovProject> Projects { get; set; }
        public string OrganizerId { get; set; }
    }
}

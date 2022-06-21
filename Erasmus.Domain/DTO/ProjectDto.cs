using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.DTO
{
    public class ProjectDto
    {
        public NonGovProject Project { get; set; }
        public bool UserHasApplied { get; set; }
    }
}

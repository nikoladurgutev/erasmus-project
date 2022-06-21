using Erasmus.Domain.Domain;
using Erasmus.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Service.Interface
{
    public interface INonGovProjectService
    {
        bool Create(NonGovProjectDto project);
        List<NonGovProject> GetAll();
        NonGovProject Get(Guid id);
        bool Edit(NonGovProjectDto model);
        bool Delete(Guid id);
        List<NonGovProject> GetProjectsOrganizer(string organizerId);
        NonGovProjectOrganizer GetNonGovProjectOrganizer(Guid projectId);
    }
}

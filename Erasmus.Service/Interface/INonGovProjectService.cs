using Erasmus.Domain.DomainModels;
using Erasmus.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Service.Interface
{
    public interface INonGovProjectService
    {
        bool Create(CreateNonGovProjectDto project);
        List<NonGovProject> GetAll();
    }
}

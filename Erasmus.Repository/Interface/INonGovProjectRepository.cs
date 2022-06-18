using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Repository.Interface
{
    public interface INonGovProjectRepository
    {
        List<NonGovProject> GetAll();
        NonGovProject Get(Guid id);
        void Insert(NonGovProject project);
        void Delete(NonGovProject project);
        void Update(NonGovProject project);
        List<NonGovProject> GetProjectsForOrganizer(string organizerId);
    }
}

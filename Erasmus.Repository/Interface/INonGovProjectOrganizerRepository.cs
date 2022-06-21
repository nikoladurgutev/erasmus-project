using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Repository.Interface
{
    public interface INonGovProjectOrganizerRepository
    {
        List<NonGovProjectOrganizer> GetNonGovProjectOrganizersForProject(Guid projectId);
        NonGovProjectOrganizer Get(string organizerId);

    }
}

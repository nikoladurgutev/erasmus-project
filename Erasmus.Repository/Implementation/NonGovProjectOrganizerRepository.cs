using Erasmus.Domain.Domain;
using Erasmus.Repository.Interface;
using Erasmus.Web.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Erasmus.Repository.Implementation
{
    public class NonGovProjectOrganizerRepository : INonGovProjectOrganizerRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<NonGovProjectOrganizer> entities;
        public NonGovProjectOrganizerRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<NonGovProjectOrganizer>();
        }
        public List<NonGovProjectOrganizer> GetNonGovProjectOrganizersForProject(Guid projectId)
        {
            return entities.Include(z => z.Organizer).ThenInclude(z => z.BaseRecord).Where(z => z.NonGovProjectId == projectId).ToList();

        }

        // if we get the participant by the user id 
        public NonGovProjectOrganizer Get(string organizerId)
        {
            return entities.Include(z => z.Organizer).ThenInclude(z => z.BaseRecord).FirstOrDefault(z => z.OrganizerId == organizerId);
        }
    }
}

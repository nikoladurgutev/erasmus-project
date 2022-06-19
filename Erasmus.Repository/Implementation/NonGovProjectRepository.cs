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
    public class NonGovProjectRepository : INonGovProjectRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<NonGovProject> entities;
        public NonGovProjectRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<NonGovProject>();
        }

        public void Delete(NonGovProject project)
        {
            entities.Remove(project);
            context.SaveChanges();
        }

        public NonGovProject Get(Guid id)
        {
            return entities.FirstOrDefault(z => z.Id == id);
        }

        public List<NonGovProject> GetAll()
        {
            return entities.Include(z => z.NonGovProjectOrganizers).ThenInclude(z=> z.Organizer).ThenInclude(z => z.BaseRecord).ToList();
        }

        public List<NonGovProject> GetProjectsForOrganizer(string organizerId)
        {
            return entities.Include(z => z.NonGovProjectOrganizers).ThenInclude(z => z.Organizer).Where(z => z.NonGovProjectOrganizers.Any(z => z.Organizer.UserId == organizerId)).ToList();
        }

        public void Insert(NonGovProject project)
        {
            entities.Add(project);
            context.SaveChanges();
        }

        public void Update(NonGovProject project)
        {
            entities.Update(project);
            context.SaveChanges();
        }
    }
}

using Erasmus.Domain.Domain;
using Erasmus.Domain.DomainModels;
using Erasmus.Domain.DTO;
using Erasmus.Repository.Interface;
using Erasmus.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Erasmus.Repository.Implementation
{
    public class OrganizerRepository : IOrganizerRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Organizer> entities;
        private DbSet<IdentityUserRole<string>> userRoles;
        private RoleManager<IdentityRole> roleManager;
        string errorMessage = string.Empty;

        public OrganizerRepository(ApplicationDbContext context, RoleManager<IdentityRole> _roleManager)
        {
            this.context = context;
            entities = context.Set<Organizer>();
            userRoles = context.Set<IdentityUserRole<string>>();
            roleManager = _roleManager;
        }
        public Organizer Get(string Id)
        {
            return entities.SingleOrDefault(z => z.UserId == Id);
        }

        public Organizer GetByMail(string mail)
        {
            return entities.Include(z => z.BaseRecord).SingleOrDefault(z => z.BaseRecord.Email == mail);
        }

        public ErasmusUser GetOrganizerFromBase(string organizerId)
        {
            return context.Users.FirstOrDefault(z => z.OrganizerId == organizerId);
        }

        public ErasmusUser GetUser(string organizerId)
        {
            var organizer = entities.Include(z => z.BaseRecord).FirstOrDefault(z => z.UserId == organizerId);
            return organizer.BaseRecord;
        }

        public void Insert(Organizer entity)
        {
            entities.Add(entity);
            context.SaveChanges();
        }


        public void Update(Organizer entity)
        {
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}

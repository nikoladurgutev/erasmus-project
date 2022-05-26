using Erasmus.Domain.Domain;
using Erasmus.Domain.Identity;
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
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ErasmusUser> entities;
        private DbSet<IdentityUserRole<string>> userRoles;
        private RoleManager<IdentityRole> roleManager;
        string errorMessage = string.Empty;
        private UserManager<ErasmusUser> userManager;

        public UserRepository(ApplicationDbContext context, UserManager<ErasmusUser> _userManager, RoleManager<IdentityRole> _roleManager)
        {
            this.context = context;
            entities = context.Set<ErasmusUser>();
            userManager = _userManager;
            userRoles = context.Set<IdentityUserRole<string>>();
            roleManager = _roleManager;
        }

        public void Delete(ErasmusUser entity)
        {
            throw new NotImplementedException();
        }

        public ErasmusUser Get(string id)
        {
            return entities.Include(z => z.Photo).FirstOrDefault(z => z.Id == id);
        }

        public IEnumerable<ErasmusUser> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ErasmusUser> GetAllByRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public void Insert(ErasmusUser entity)
        {
            throw new NotImplementedException();
        }

        public void Update(ErasmusUser entity)
        {
            entities.Update(entity);
            context.SaveChanges();
        }
    }
}

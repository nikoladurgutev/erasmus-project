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
    public class UploadedFileRepository : IUploadedFileRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<UploadedFile> entities;
        public UploadedFileRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<UploadedFile>();
        }
        public List<UploadedFile> GetFilesForUserAndEvent(string userId, Guid eventId)
        {
           return entities.Where(z => z.ProjectId == eventId && z.UserId == userId).ToList();
        }
    }
}

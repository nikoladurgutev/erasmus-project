using Erasmus.Domain.Domain;
using Erasmus.Repository.Interface;
using Erasmus.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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

        public void Delete(Guid id)
        {
            var file = Get(id);
            entities.Remove(file);
            context.SaveChanges();
        }

        public UploadedFile Get(Guid id)
        {
            return entities.FirstOrDefault(z => z.Id == id);
        }

        public List<UploadedFile> GetFilesForUserAndEvent(string userId, Guid eventId)
        {
           return entities.Where(z => z.ProjectId == eventId && z.UserId == userId).ToList();
        }

        public void Insert(UploadedFile uploadedFile)
        {
            entities.Add(uploadedFile);
            context.SaveChanges();
        }

        public UploadedFile UploadedCvForEvent(string userId, Guid eventId)
        {
            return entities.FirstOrDefault(z => z.UserId == userId && z.ProjectId == eventId && z.FileType == FileType.CV);
        }

        public UploadedFile UploadedMotivationalLetterForEvent(string userId, Guid eventId)
        {
            return entities.FirstOrDefault(z => z.UserId == userId && z.ProjectId == eventId && z.FileType == FileType.MotivationLetter);
        }
    }
}

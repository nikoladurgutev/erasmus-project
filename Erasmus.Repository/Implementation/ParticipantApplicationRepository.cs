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
    public class ParticipantApplicationRepository : IParticipantApplicationRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<ParticipantApplication> entities;
        public ParticipantApplicationRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<ParticipantApplication>();
        }

        public void Approve(ParticipantApplication application)
        {
            application.ReviewStatus = ApplicationStatus.Approved;
            context.SaveChanges();
        }

        public void Delete(ParticipantApplication application)
        {
            entities.Remove(application);
            context.SaveChanges();
        }

        public List<ParticipantApplication> GetAllForProject(Guid id)
        {
            return entities.Include(z => z.UploadedFiles).Include(z => z.NonGovProject).Include(z => z.Participant).ThenInclude(z => z.BaseRecord).Where(z => z.NonGovProjectId == id && z.ReviewStatus < ApplicationStatus.NotCompleted).ToList();
        }

        public ParticipantApplication GetApplication(Guid id)
        {
            return entities.Include(z => z.NonGovProject).Include(z => z.Participant).ThenInclude(z => z.BaseRecord).FirstOrDefault(z => z.Id == id);
        }

        public ParticipantApplication GetForParticipantAndProject(string participantId, Guid projectId)
        {
            return entities.Include(z => z.Participant).Include(z => z.UploadedFiles).FirstOrDefault(z => z.ParticipantUserId == participantId && z.NonGovProjectId == projectId);
        }

        public void Insert(ParticipantApplication application)
        {
            application.ReviewStatus = ApplicationStatus.InReview;
            entities.Add(application);
            context.SaveChanges();
        }

        public void Reject(ParticipantApplication application)
        {
            application.ReviewStatus = ApplicationStatus.Rejected;
            context.SaveChanges();
        }

        public void Update(ParticipantApplication participantApplication)
        {
            entities.Update(participantApplication);
            context.SaveChanges();
        }
    }
}

using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Repository.Interface
{
    public interface IParticipantApplicationRepository
    {
        ParticipantApplication GetApplication(Guid id);
        List<ParticipantApplication> GetAllForProject(Guid id);
        void Insert(ParticipantApplication application);
        void Update(ParticipantApplication participantApplication);
        void Approve(ParticipantApplication application);
        void Reject(ParticipantApplication participantApplication);
        void Delete(ParticipantApplication entity);
        ParticipantApplication GetForParticipantAndProject(string participantId, Guid projectId);
    }
}

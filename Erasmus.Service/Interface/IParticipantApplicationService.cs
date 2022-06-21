using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Service.Interface
{
    public interface IParticipantApplicationService
    {
        ParticipantApplication Get(Guid id);
        ParticipantApplication GetForParticipantAndProject(string participantId, Guid projectId);
        void Insert(ParticipantApplication application);
        void Update(ParticipantApplication application);
        List<ParticipantApplication> GetAllForProject(Guid projectId);
        ParticipantApplication Approve(ParticipantApplication application);

        ParticipantApplication Reject(ParticipantApplication application);
    }
}

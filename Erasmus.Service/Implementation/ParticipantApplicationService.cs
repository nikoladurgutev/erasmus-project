using Erasmus.Domain.Domain;
using Erasmus.Repository.Interface;
using Erasmus.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Service.Implementation
{
    public class ParticipantApplicationService : IParticipantApplicationService
    {
        private readonly IParticipantApplicationRepository _repository;
        public ParticipantApplicationService(IParticipantApplicationRepository repository)
        {
            _repository = repository;
        }
        public ParticipantApplication Get(Guid id)
        {
            return _repository.GetApplication(id);
        }

        public ParticipantApplication GetForParticipantAndProject(string participantId, Guid projectId)
        {
            return _repository.GetForParticipantAndProject(participantId, projectId);
        }

        public void Insert(ParticipantApplication application)
        {
            _repository.Insert(application);
        }

        public void Update(ParticipantApplication application)
        {
            _repository.Update(application);
        }
    }
}

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


    }
}

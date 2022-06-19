using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Repository.Interface
{
    public interface IParticipantRepository
    {
        List<Participant> GetAll();
        Participant Get(string id);
        public void Update(Participant entity);
        public void Insert(Participant entity);

        ErasmusUser GetUser(string participantId);
        ErasmusUser GetParticipantFromBase(string participantId);



    }
}

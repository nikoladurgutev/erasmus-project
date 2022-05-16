using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Repository.Interface
{
    public interface IParticipantsRepository
    {
        List<Participant> GetAll();
        Participant Get(string id);
    }
}

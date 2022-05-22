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
    public class ParticipantRepository : IParticipantsRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<Participant> entities;
        public ParticipantRepository(ApplicationDbContext context)
        {
            this.context = context;
            this.entities = context.Set<Participant>();
        }

        // if we get the participant by the user id 
        public Participant Get(string id)
        {
            return entities.Include(z => z.BaseRecord).FirstOrDefault(z => z.BaseRecord.Id != null && z.BaseRecord.Id == id);
        }

        public List<Participant> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}

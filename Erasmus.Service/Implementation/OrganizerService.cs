using Erasmus.Domain.Domain;
using Erasmus.Repository.Interface;
using Erasmus.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Service.Implementation
{
    public class OrganizerService : IOrganizerService
    {
        private readonly IOrganizerRepository _organizerRepository;
        public OrganizerService(IOrganizerRepository organizerRepository)
        {
            _organizerRepository = organizerRepository;
        }
        public Organizer Get(string mail)
        {
            throw new NotImplementedException();
        }
    }
}

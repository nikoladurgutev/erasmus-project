using Erasmus.Domain.Domain;
using Erasmus.Domain.DomainModels;
using Erasmus.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Service.Interface
{
    public interface IOrganizerService
    {
        Organizer GetByMail(string mail);
        Organizer Get(string id);
        ErasmusUser GetUser(string organizerId);
        public void Edit(OrganizerProfileDto model);
    }
}

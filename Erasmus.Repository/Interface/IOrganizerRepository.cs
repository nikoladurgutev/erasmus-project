using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Repository.Interface
{
    public interface IOrganizerRepository
    {
        Organizer Get(string Id);

        Organizer GetByMail(string mail);

        public void Insert(Organizer entity);
    }
}

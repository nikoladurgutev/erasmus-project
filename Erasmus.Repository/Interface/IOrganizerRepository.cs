﻿using Erasmus.Domain.Domain;
using Erasmus.Domain.DomainModels;
using Erasmus.Domain.DTO;
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
        public void Update(Organizer entity);

        ErasmusUser GetUser(string organizerId);
        ErasmusUser GetOrganizerFromBase(string organizerId);
    }
}

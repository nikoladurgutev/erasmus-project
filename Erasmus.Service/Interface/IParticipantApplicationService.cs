﻿using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Service.Interface
{
    public interface IParticipantApplicationService
    {
        ParticipantApplication Get(Guid id);
    }
}
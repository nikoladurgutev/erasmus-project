using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.Identity
{
    public  class RegisterDto
    {
        // the user can choose to be a Participant, Student, Organization, Coordinator
        public Role ChosenRole { get; set; }
    }
}

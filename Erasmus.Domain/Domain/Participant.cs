using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Erasmus.Domain.Domain
{
    public class Participant
    {
        [Key]
        public string UserId { get; set; }
        public ErasmusUser BaseRecord { get; set; }
        public virtual ICollection<UploadedFile> UploadedFiles { get; set; }
        public virtual ICollection<ParticipantApplication> ErasmusApplications { get; set; }
    }
}

using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain.Domain
{
    public class UploadedFile : BaseEntity
    {
        public string FileName { get; set; }
        public Guid ProjectId { get; set; }
        public string UserId { get; set; }
        public Participant User { get; set; }
        public string PathOnDisk { get; set; }
        public FileType FileType { get; set; }
        public Guid? ApplicationId { get; set; }
        public ParticipantApplication Application { get; set; }
    } 
}

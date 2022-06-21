using Erasmus.Domain.Domain;
using Erasmus.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus.Service.Interface
{
    public interface IParticipantService
    {
        Participant Get(string participantId);
        Task<bool> Apply(string participantId, Guid projectId);
        Task<bool> SendMailToParticipant(Participant participant, NonGovProject project, ICollection<UploadedFile> files);
        Task<bool> SendMailToOrganizer(Participant participant, NonGovProject project);

    }
}

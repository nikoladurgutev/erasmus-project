using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus.Service.Interface
{
    public interface IEmailService
    {
        Task SendMailAsync(Email email, ICollection<UploadedFile> uploadedFiles);
        Task SendMailToOrganizerAsync(Email email);
        Task SendUnsentMailsAsync(List<Email> emails);
    }
}

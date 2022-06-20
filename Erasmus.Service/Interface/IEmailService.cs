using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Erasmus.Service.Interface
{
    public interface IEmailService
    {
        Task SendMailAsync(Email email, string message, ICollection<UploadedFile> uploadedFiles);
        Task SendUnsentMailsAsync(List<Email> emails);
    }
}

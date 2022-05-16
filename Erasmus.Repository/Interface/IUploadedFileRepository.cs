using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Repository.Interface
{
    public interface IUploadedFileRepository
    {
        List<UploadedFile> GetFilesForUserAndEvent(string userId, Guid eventId);
    }
}

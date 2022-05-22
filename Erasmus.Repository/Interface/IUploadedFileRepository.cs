using Erasmus.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Repository.Interface
{
    public interface IUploadedFileRepository
    {
        UploadedFile Get(Guid id);
        List<UploadedFile> GetFilesForUserAndEvent(string userId, Guid eventId);
        void Insert(UploadedFile uploadedFile);
        UploadedFile UploadedCvForEvent(string userId, Guid eventId);
        UploadedFile UploadedMotivationalLetterForEvent(string userId, Guid eventId);
        void Delete(Guid id);
    }
}

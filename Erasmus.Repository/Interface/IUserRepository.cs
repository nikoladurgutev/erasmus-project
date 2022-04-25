using Erasmus.Domain.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<ErasmusUser> GetAll();
        ErasmusUser Get(string id);
        void Insert(ErasmusUser entity);

        void Update(ErasmusUser entity);
        //void UpdateProfile(EditUserDto entity);

        //void UploadPicture(UploadProfilePictureDto entity);
        void Delete(ErasmusUser entity);

        IEnumerable<ErasmusUser> GetAllByRole(string roleName);
    }
}

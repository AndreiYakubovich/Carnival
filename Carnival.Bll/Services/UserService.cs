using System;
using System.Collections.Generic;
using System.Text;
using BLL.Entity;
using BLL.Interfaces;
using ClassLibrary.Models;
using DAL.Interfaces;

namespace BLL.Services
{
    public class UserService:IUserService
    {
        private IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(AuthEntity authEntity)
        {
            if (!CheckForExistingEmail(authEntity))
            {
                _unitOfWork.Profiles.Create(new Profile()
                {
                    Password = authEntity.
                    Password,Email = authEntity.Email
                });
                _unitOfWork.Commit();
            }
        }

        public void Delete(int Id)
        {
            _unitOfWork.Profiles.Delete(_unitOfWork.Profiles.GetById(Id));
            _unitOfWork.Commit();
        }

        public void ChangePassword(ProfileBLL profile, string password)
        {
            Profile whom = _unitOfWork.Profiles.GetOneByPredicate(p => p.Id == profile.Id);
            if (whom.Password == password)
            {
                whom.Password = password;
                _unitOfWork.Profiles.Update(whom);
                _unitOfWork.Commit();
            };
        }

        private bool CheckForExistingEmail(AuthEntity authEntity)
        {
            return _unitOfWork.Profiles.GetOneByPredicate(p => p.Email == authEntity.Email) != null;

        }

        public void Edit(AuthEntity prop)
        {
            throw new NotImplementedException();
        }
    }
}

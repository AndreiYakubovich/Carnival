using System;
using System.Collections.Generic;
using System.Text;
using BLL.Entity;

namespace BLL.Interfaces
{
    public interface IUserService:IBaseService<AuthEntity>
    {
        void ChangePassword(ProfileBLL profile, string password);
    }
}

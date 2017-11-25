using System;
using System.Collections.Generic;
using System.Text;
using BLL.Entity;
using BLL.Interfaces;
using BLL.Mappers;
using ClassLibrary.Models;
using DAL.Interfaces;

namespace BLL.Services
{
    public class BlogService:IBlogService
    {
        private IUnitOfWork _unitOfWork;

        public BlogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Create(Blog prop)
        {
            _unitOfWork.Blogs.Create(new Blog()
            {
                AuthorId = prop.AuthorId,
                AuthorProfile = _unitOfWork.Profiles.GetOneByPredicate(p=>p.Id==prop.Id),
                Message = prop.Message,
                WhosWall = prop.WhosWall,
                WhosWallProfile = _unitOfWork.Profiles.GetOneByPredicate(p => p.Id == prop.WhosWall)
            });
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            try
            {
                _unitOfWork.Blogs.Delete(_unitOfWork.Blogs.GetById(id));
            }
            catch (Exception e)
            {
                Console.WriteLine("Wasn't deleted");
            }

        }

        public void Edit(Blog prop)
        {
            _unitOfWork.Blogs.Update(_unitOfWork.Blogs.GetById(prop.Id).UpdateBlog(prop));
        }
    }
}

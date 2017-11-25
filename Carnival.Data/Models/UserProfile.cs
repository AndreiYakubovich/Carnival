using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Carnival.Data.Models
{
    public class UserProfile
    {
        public UserProfile(string Id)
        {
            this.Id = Id;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public string Bio { get; set; }

        private ICollection<Post> _posts;
        public virtual ICollection<Post> Posts
        {
            get { return _posts ?? (_posts = new Collection<Post>()); }
            set { _posts = value; }
        }

//        private ICollection<User> _followings;
//        public virtual ICollection<User> Followings
//        {
//            get { return _followings ?? (_followings = new Collection<User>()); }
//            set { _followings = value; }
//        }
//
//        private ICollection<User> _followers;
//        public virtual ICollection<User> Followers
//        {
//            get { return _followers ?? (_followers = new Collection<User>()); }
//            set { _followers = value; }
//        }

    }
}
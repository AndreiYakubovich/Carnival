using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Carnival.Data.Models
{
    public class User : IdentityUser
    {
        public User(string id)
        {
            Id = id;
        }

        public User()
        {
            Id = Guid.NewGuid().ToString();
            DateCreated = DateTime.Today;
           
        }

        public DateTime DateCreated { get; set; }
        
        public string ProfileId { get; set; }

        [ForeignKey("ProfileId")]
        public virtual UserProfile Profile { get; set; }
    }
}
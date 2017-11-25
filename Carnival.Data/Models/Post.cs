using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;

namespace Carnival.Data.Models
{
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid().ToString();
        }

        [Key]
        public string Id { get; set; }

        public string text { get; set; }

        public string ImageId { get; set; }

        public string AuthorId { get; set; }

    }
}
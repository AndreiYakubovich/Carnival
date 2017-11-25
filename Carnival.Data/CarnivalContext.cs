using Carnival.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Carnival.Data
{
    public class CarnivalContext : IdentityDbContext<User>
    {
        private static bool _created = false;

        public CarnivalContext(DbContextOptions<CarnivalContext> options) : base(options)
        {
            if (!_created)
            {
                _created = true;
                //                Database.EnsureDeleted();
                Database.EnsureCreated();
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionbuilder)
        {
            optionbuilder.UseSqlServer(
                @"Data Source=.\SQL2017;Database=СarnivalDataBase;Integrated Security=true");
        }

//        public DbSet<Profile> Profile { get; set; }
//        public DbSet<BlogComments> BlogComments { get; set; }
//        public DbSet<Blog> Blogs { get; set; }
//        public DbSet<FriendInvites> FriendInvites { get; set; }
//        public DbSet<Friends> Friends { get; set; }
//        public DbSet<Messages> Messages { get; set; }
//        public DbSet<UserType> UserType { get; set; }
        public DbSet<TestData> TestData { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}


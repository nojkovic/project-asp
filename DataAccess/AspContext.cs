using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class AspContext : DbContext

    {
        private readonly string _connectionString;
        public AspContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public AspContext()
        {
            _connectionString = "Data Source=LAPTOP-I2PIHDS7\\MSSQLSERVER05;Initial Catalog=AspBlog;TrustServerCertificate=true;Integrated security = true";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
           
        }

      
        public DbSet<User> Users { get; set; }
        public DbSet<TypeLike> TypeLikes { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<LikePost> LikePosts { get; set; }
        public DbSet<PostTag> PostTags { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<LikeComment> LikeComments { get; set; }
        public DbSet<LogError> LogErrors { get; set; }
        public DbSet<UseCaseLog> UseCasesLogs { get; set; }
        public DbSet<UserUseCase> UserUseCases {  get; set; }


    }
}

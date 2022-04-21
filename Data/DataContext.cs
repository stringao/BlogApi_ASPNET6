using Blog.Data.Mappings;
using Blog.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace Blog.Data
{
    public class BlogDataContext : DbContext
    {
        public BlogDataContext(DbContextOptions<BlogDataContext> options) : base(options){}

        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        //public DbSet<PostWithCategoriesCount> PostWithTagsCount { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer(@"Server=localhost,1433;Database=blog-modulo-6;User ID=sa;Password=Abcd#1234;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new PostMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new TagMap());

            //modelBuilder.Entity<PostWithCategoriesCount>(x =>
            //x.HasNoKey().ToSqlQuery(@"
            //    Select [Title] as [Name],
		          //      (SELECT Count(Id) FROM [Category] WHERE CategoryId = [Id]) AS [Count]
            //    FROM Post")
            //);

            //Chamada a uma view do banco
            //modelBuilder
            //    .Entity<PostWithCategoriesCount>( eb =>
            //{
            //    eb.HasNoKey();
            //    eb.ToView("vw_PostCategoriesCounts");
            //    eb.Property(v => v.Name).HasColumnName("Name");
            //});
        }
    }
}
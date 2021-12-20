using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Concrete
{
   public class BlogContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            DbContextOptionsBuilder dbContextOptionsBuilder1 = dbContextOptionsBuilder.UseNpgsql("User ID=postgres;Password=Merve.35;Server=localhost;Port=5432;Database=SoftwareBlog;Integrated Security=true;Pooling=true;");

        }


    }
}

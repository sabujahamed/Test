using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebAppBS.Model;

namespace WebAppDBContext
{
    public class AspContext : DbContext
    {
        public AspContext(DbContextOptions<AspContext> options ) : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<Blog> Blog { get; set; }     
        public virtual DbSet<LikeOrDisLikes> LikeOrDisLikes { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<Comments> Comments { get; set; }

      
    }
}

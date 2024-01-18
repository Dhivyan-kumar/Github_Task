using EFinheritance.Models;
using Microsoft.EntityFrameworkCore;

namespace EFinheritance.Efdata;
public class WebDbContext :DbContext
    {
        public WebDbContext(DbContextOptions<WebDbContext> options):base(options){

        } 
        public DbSet<User> Userinfo{get;set;}
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>();
            modelBuilder.Entity<Admin>();
            base.OnModelCreating(modelBuilder);

        }

    

}
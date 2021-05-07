using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<University> Universities { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Profiling> Profilings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<RoleAccount> RoleAccounts { get; set; }
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<University>().HasMany(s => s.Education).WithOne(s => s.University);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<University>()
              .HasMany(b => b.Education)
              .WithOne(c => c.University)
              .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Education>()
              .HasMany(b => b.Profiling)
              .WithOne(c => c.Education)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<RoleAccount>()
            .HasKey(bc => new { bc.NIK, bc.RoleId });
            modelBuilder.Entity<RoleAccount>()
                .HasOne(bc => bc.Account)
                .WithMany(b => b.RoleAccount)
                .HasForeignKey(bc => bc.NIK);
            modelBuilder.Entity<RoleAccount>()
                .HasOne(bc => bc.Role)
                .WithMany(c => c.RoleAccount)
                .HasForeignKey(bc => bc.RoleId);

        }
    }
}

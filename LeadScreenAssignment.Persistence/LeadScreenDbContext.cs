using LeadScreenAssignment.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeadScreenAssignment.Persistence
{
    //TODO move into data?
    public class LeadScreenDbContext : DbContext
    {
        public LeadScreenDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LeadEntity> Leads { get; set; }     
        public DbSet<SubAreaEntity> SubAreas { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LeadEntity>()                
                .HasOne(e => e.SubArea)
                .WithMany(e => e.Leads)
                .HasForeignKey(x => x.SubAreaId)
                .IsRequired();

            modelBuilder
                .Entity<LeadEntity>()
                .Property(e=>e.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder
               .Entity<SubAreaEntity>()
               .Property(e => e.Name)
               .HasMaxLength(50)
               .IsRequired();

            modelBuilder
             .Entity<SubAreaEntity>()
             .Property(e => e.PinCode)
             .HasMaxLength(6)
             .IsRequired();


            base.OnModelCreating(modelBuilder);
        }

        
    }
}

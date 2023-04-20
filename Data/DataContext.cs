using Microsoft.EntityFrameworkCore;
using net_react.Models;

namespace net_react.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Organizations> Organizations => Set<Organizations>();
        public DbSet<Requisites> Requisites => Set<Requisites>();
        public DbSet<OrganizationsRequisites> OrganizationsRequisites => Set<OrganizationsRequisites>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrganizationsRequisites>()
                    .HasKey(or => new { or.OrganizationId, or.RequisitesId });
            modelBuilder.Entity<OrganizationsRequisites>()
                    .HasOne(p => p.Organizations)
                    .WithMany(pc => pc.OrganizationsRequisites)
                    .HasForeignKey(p => p.OrganizationId);
            modelBuilder.Entity<OrganizationsRequisites>()
                    .HasOne(p => p.Requisites)
                    .WithMany(pc => pc.OrganizationsRequisites)
                    .HasForeignKey(c => c.RequisitesId);
        }
    }
}

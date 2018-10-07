using KickStarter.Library.Entities;
using Microsoft.EntityFrameworkCore;

namespace KickStarter.DataLayer.EntityFramework
{
    public partial class DataContext : DbContext, IDataContext
    {
        #region OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Customer>(entity =>
            //{
            //    entity.Property(e => e.Name)
            //        .IsRequired()
            //        .HasMaxLength(255);
            //    entity.Property(e => e.CoCNumber)
            //        .IsRequired()
            //        .HasMaxLength(20);
            //    entity.Property(e => e.PhoneNumber)
            //        .HasMaxLength(20);
            //    entity.Property(e => e.Email)
            //        .IsRequired()
            //        .HasMaxLength(255);

            //    entity.Property(e => e.Street)
            //        .IsRequired()
            //        .HasMaxLength(100);
            //    entity.Property(e => e.HouseNumber).IsRequired();
            //    entity.Property(e => e.HouseNumberAttachment).HasMaxLength(100);
            //    entity.Property(e => e.ZipCode)
            //        .IsRequired()
            //        .HasMaxLength(20);
            //    entity.Property(e => e.City)
            //        .IsRequired()
            //        .HasMaxLength(100);

            //    entity.Property(e => e.InvoiceStreet)
            //        .IsRequired()
            //        .HasMaxLength(100);
            //    entity.Property(e => e.InvoiceHouseNumber).IsRequired();
            //    entity.Property(e => e.InvoiceHouseNumberAttachment).HasMaxLength(100);
            //    entity.Property(e => e.InvoiceZipCode)
            //        .IsRequired()
            //        .HasMaxLength(20);
            //    entity.Property(e => e.InvoiceCity)
            //        .IsRequired()
            //        .HasMaxLength(100);
            //});

        }

        #endregion

        #region Virtuals

        public virtual DbSet<Person> Persons { get; set; }
 
        #endregion
    }
}
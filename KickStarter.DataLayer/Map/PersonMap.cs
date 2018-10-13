using KickStarter.Library.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KickStarter.DataLayer.Map
{
    public class PersonMap : EntityTypeConfiguration<Person>
    {
        public override void Map(EntityTypeBuilder<Person> personTable)
        {

            // Set Primary key
            personTable.HasKey(e => e.Id).ForSqlServerIsClustered();
            personTable.Property(e => e.Id)
                .HasColumnName("Id")
                .IsRequired();
            personTable.Property(b => b.FirstName).HasColumnType("nvarchar(50)");
            personTable.Property(e => e.FirstName)
                .HasColumnName("FirstName")
                .IsRequired()
                .HasMaxLength(50);
            personTable.Property(b => b.MiddleName).HasColumnType("nvarchar(50)");
            personTable.Property(e => e.MiddleName)
                .HasColumnName("MiddleName")
                .IsRequired(false)
                .HasMaxLength(50);
            personTable.Property(b => b.Insertion).HasColumnType("nvarchar(50)");
            personTable.Property(e => e.Insertion)
                .HasColumnName("Insertion")
                .IsRequired(false)
                .HasMaxLength(50);
            personTable.Property(b => b.LastName).HasColumnType("nvarchar(50)");
            personTable.Property(e => e.LastName)
                .HasColumnName("LastName")
                .IsRequired()
                .HasMaxLength(50);
            personTable.Property(b => b.Suffix).HasColumnType("nvarchar(50)");
            personTable.Property(e => e.Suffix)
                .HasColumnName("Suffix")
                .IsRequired(false)
                .HasMaxLength(50);
            personTable.Property(e => e.Gender)
                .HasColumnName("Gender")
                .IsRequired();
            personTable.Property(b => b.DateOfBirth).HasColumnType("datetime");
            personTable.Property(e => e.DateOfBirth)
                .HasColumnName("DateOfBirth")
                .IsRequired();
            personTable.Property(b => b.SocialSegurityNumber).HasColumnType("nvarchar");
            personTable.Property(e => e.SocialSegurityNumber)
                .HasColumnName("SocialSegurityNumber")
                .IsRequired(false)
                .HasMaxLength(50);
            personTable.Property(e => e.Image)
                .HasColumnName("Image")
                .IsRequired(false);
            personTable.Property(b => b.Description).HasColumnType("nvarchar(max)");
            personTable.Property(e => e.Description)
                .HasColumnName("Description")
                .IsRequired();
            personTable.Property(b => b.UpdateDate).HasColumnType("datetime");
            personTable.Property(e => e.InsertDate)
                .HasColumnName("InsertDate")
                .IsRequired();
            personTable.Property(b => b.UpdateDate).HasColumnType("datetime");
            personTable.Property(e => e.UpdateDate)
                .HasColumnName("UpdateDate")
                .IsRequired();



        }
    }


}

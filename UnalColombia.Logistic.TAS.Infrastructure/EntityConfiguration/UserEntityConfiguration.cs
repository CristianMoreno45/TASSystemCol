using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UnalColombia.Logistic.TAS.Domain.Entities;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entity)
        {
            entity.HasKey(e => e.UserId);
            entity.HasIndex(e => e.UserName)
                .IsUnique();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.Property(e => e.UserName)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Password)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(e => e.Terminal)
                .WithMany(t => t.Users)
                .HasForeignKey(e => e.TerminalId);

            entity.HasOne(e => e.Category)
                .WithMany()
                .HasForeignKey(e => e.CategoryId);

            entity.HasMany(e => e.HistoryPoints)
               .WithOne(a => a.User)
               .HasForeignKey(e => e.UserId)
               .IsRequired(false);

            entity.HasMany(e => e.WalledByUsers)
                .WithOne(a => a.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);

            entity.HasMany(e => e.Drivers)
                .WithOne(a => a.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);

            entity.HasMany(e => e.Providers)
                .WithOne(a => a.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);

            entity.HasMany(e => e.TerminalOperators)
                .WithOne(a => a.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);

            entity.HasMany(e => e.CreatedHistoryPoints)
                .WithOne(a => a.CreatedByUser)
                .HasForeignKey(e => e.CreatedUserId)
                .IsRequired(false);

            entity.HasMany(e => e.UpdatedHistoryPoints)
               .WithOne(a => a.UpdatedByUser)
               .HasForeignKey(e => e.LastUpdatedUserId)
               .IsRequired(false);

            entity.HasMany(e => e.CreatedSuperPowerByUserList)
              .WithOne(a => a.CreatedByUser)
              .HasForeignKey(e => e.CreatedUserId)
              .IsRequired(false);

            entity.HasMany(e => e.UpdatedSuperPowerByUserList)
               .WithOne(a => a.UpdatedByUser)
               .HasForeignKey(e => e.LastUpdatedUserId)
               .IsRequired(false);

            entity.HasMany(e => e.SuperPowers)
               .WithOne(a => a.User)
               .HasForeignKey(e => e.UserId)
               .IsRequired(false);

            entity.HasMany(e => e.CreatedHistoryAppointments)
              .WithOne(a => a.CreatedByUser)
              .HasForeignKey(e => e.CreatedUserId)
              .IsRequired(false);

            entity.HasMany(e => e.UpdatedHistoryAppointments)
               .WithOne(a => a.UpdatedByUser)
               .HasForeignKey(e => e.LastUpdatedUserId)
               .IsRequired(false);

            entity.HasMany(e => e.CreatedAppointments)
               .WithOne(a => a.CreatedByUser)
               .HasForeignKey(e => e.CreatedUserId)
               .IsRequired(false);

            entity.HasMany(e => e.UpdatedAppointments)
               .WithOne(a => a.UpdatedByUser)
               .HasForeignKey(e => e.LastUpdatedUserId)
               .IsRequired(false);

            entity.HasMany(e => e.CreatedMissions)
               .WithOne(a => a.CreatedByUser)
               .HasForeignKey(e => e.CreatedUserId)
               .IsRequired(false);

            entity.HasMany(e => e.UpdatedMissions)
               .WithOne(a => a.UpdatedByUser)
               .HasForeignKey(e => e.LastUpdatedUserId)
               .IsRequired(false);
        }
    }
}

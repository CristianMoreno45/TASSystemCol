using Microsoft.EntityFrameworkCore;
using UnalColombia.Common.Interfaces;


namespace UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration
{
    public static class DbGeneralSettings
    {
        public static void ConfigureByInterfaceDefinition(ModelBuilder modelBuilder)
        {
            // Configuraciones comunes para auditoría
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // Configuración para entidades auditables
                if (typeof(IAuditable).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property("CreatedDate")
                        .HasColumnType("datetime2")
                        .IsRequired();

                    modelBuilder.Entity(entityType.ClrType)
                        .Property("CreatedUserId")
                        .IsRequired();

                    modelBuilder.Entity(entityType.ClrType)
                        .Property("LastUpdatedDate")
                        .HasColumnType("datetime2");
                }

                // Configuración para entidades activables
                if (typeof(IActivatable).IsAssignableFrom(entityType.ClrType))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property("IsActive")
                        .IsRequired();
                }
            }
        }
    }
}

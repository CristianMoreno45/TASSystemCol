using System.Globalization;
using Microsoft.EntityFrameworkCore;
using UnalColombia.Common.Interfaces;
using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Infrastructure.EntityConfiguration;
using Calendar = UnalColombia.Logistic.TAS.Domain.Entities.Calendar;

namespace UnalColombia.Logistic.TAS.Infrastructure.Persistence
{
    public class TASDbContext : DbContext
    {

        public TASDbContext(DbContextOptions<TASDbContext> options)
            : base(options)
        {
        }

        // DbSet Properties
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentState> AppointmentStates { get; set; }
        public DbSet<Calendar> Calendars { get; set; }
        public DbSet<CargoInformation> CargoInformation { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<DayOfWeekSettings> DayOfWeekSettings { get; set; }
        public DbSet<DeadBand> DeadBands { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<HistoryAppointment> HistoryAppointments { get; set; }
        public DbSet<HistoryPoint> HistoryPoints { get; set; }
        public DbSet<IdentificationType> IdentificationTypes { get; set; }
        public DbSet<ISOCountry> ISOCountries { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Mission> Missions { get; set; }
        public DbSet<MissionAppointmet> MissionAppointments { get; set; }
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<SuperPower> SuperPowers { get; set; }
        public DbSet<SuperPowerUser> SuperPowerUsers { get; set; }
        public DbSet<Terminal> Terminals { get; set; }
        public DbSet<TerminalOperator> TerminalOperators { get; set; }
        public DbSet<TypeContainer> TypeContainers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<WalletUser> WalletUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // Aplica todas las configuraciones de entidades automáticamente
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppointmentEntityConfiguration).Assembly);
            DbGeneralSettings.ConfigureByInterfaceDefinition(modelBuilder);
        }
    }
}

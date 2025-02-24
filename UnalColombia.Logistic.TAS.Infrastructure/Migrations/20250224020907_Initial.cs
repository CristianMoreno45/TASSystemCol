using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnalColombia.Logistic.TAS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    RankingNumber = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "IdentificationTypes",
                columns: table => new
                {
                    IdentificationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Code1 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Code2 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Code3 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IdentificationTypes", x => x.IdentificationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ISOCountries",
                columns: table => new
                {
                    ISOCountryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    A2 = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: false),
                    A3 = table.Column<string>(type: "varchar(3)", unicode: false, maxLength: 3, nullable: false),
                    Code = table.Column<string>(type: "varchar(10)", unicode: false, maxLength: 10, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ISOCountries", x => x.ISOCountryId);
                });

            migrationBuilder.CreateTable(
                name: "Operators",
                columns: table => new
                {
                    OperatorId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operators", x => x.OperatorId);
                });

            migrationBuilder.CreateTable(
                name: "States",
                columns: table => new
                {
                    StateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Code1 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Code2 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Code3 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_States", x => x.StateId);
                });

            migrationBuilder.CreateTable(
                name: "TypeContainers",
                columns: table => new
                {
                    TypeContainerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeContainers", x => x.TypeContainerId);
                });

            migrationBuilder.CreateTable(
                name: "Wallets",
                columns: table => new
                {
                    WalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wallets", x => x.WalletId);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    CityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Code1 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Code2 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    Code3 = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.CityId);
                    table.ForeignKey(
                        name: "FK_Cities_States_StateId",
                        column: x => x.StateId,
                        principalTable: "States",
                        principalColumn: "StateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Terminals",
                columns: table => new
                {
                    TerminalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperatorId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Url = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    GeographicLocationCityId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Terminals", x => x.TerminalId);
                    table.ForeignKey(
                        name: "FK_Terminals_Cities_GeographicLocationCityId",
                        column: x => x.GeographicLocationCityId,
                        principalTable: "Cities",
                        principalColumn: "CityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Terminals_Operators_OperatorId",
                        column: x => x.OperatorId,
                        principalTable: "Operators",
                        principalColumn: "OperatorId");
                });

            migrationBuilder.CreateTable(
                name: "AppointmentStates",
                columns: table => new
                {
                    AppointmentStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    AllowChanges = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentStates", x => x.AppointmentStateId);
                    table.ForeignKey(
                        name: "FK_AppointmentStates_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "TerminalId");
                });

            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    CalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerminalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    FinishTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    HasOverlaping = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.CalendarId);
                    table.ForeignKey(
                        name: "FK_Calendars_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "TerminalId");
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TerminalId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    FisicalLocation = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_Locations_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "TerminalId");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TerminalId = table.Column<int>(type: "int", nullable: true),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    UserName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_Terminals_TerminalId",
                        column: x => x.TerminalId,
                        principalTable: "Terminals",
                        principalColumn: "TerminalId");
                });

            migrationBuilder.CreateTable(
                name: "DayOfWeekSettings",
                columns: table => new
                {
                    SettingDayOfWeekId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DayOfWeek = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    FinishTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayOfWeekSettings", x => x.SettingDayOfWeekId);
                    table.ForeignKey(
                        name: "FK_DayOfWeekSettings_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "CalendarId");
                });

            migrationBuilder.CreateTable(
                name: "DeadBands",
                columns: table => new
                {
                    DeadBandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Reason = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    FinishTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsRecurrent = table.Column<bool>(type: "bit", nullable: false),
                    RecurrentPattern = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeadBands", x => x.DeadBandId);
                    table.ForeignKey(
                        name: "FK_DeadBands_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "CalendarId");
                });

            migrationBuilder.CreateTable(
                name: "Drivers",
                columns: table => new
                {
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Phone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    LicenceNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IdentificationTypeId = table.Column<int>(type: "int", nullable: false),
                    IdentificationNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Notes = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drivers", x => x.DriverId);
                    table.ForeignKey(
                        name: "FK_Drivers_IdentificationTypes_IdentificationTypeId",
                        column: x => x.IdentificationTypeId,
                        principalTable: "IdentificationTypes",
                        principalColumn: "IdentificationTypeId");
                    table.ForeignKey(
                        name: "FK_Drivers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Missions",
                columns: table => new
                {
                    MissionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    IsAchieved = table.Column<bool>(type: "bit", nullable: false),
                    Points = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Missions", x => x.MissionId);
                    table.ForeignKey(
                        name: "FK_Missions_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Missions_Users_LastUpdatedUserId",
                        column: x => x.LastUpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Providers",
                columns: table => new
                {
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FiscalNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FiscalAddress = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    ContactName = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    ContactPhone = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    Notes = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Providers", x => x.ProviderId);
                    table.ForeignKey(
                        name: "FK_Providers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "SuperPowers",
                columns: table => new
                {
                    SuperPowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MultiplierFactor = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Name = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    MinutesDuaration = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedByUserIdUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UpdatedByUserIdUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPowers", x => x.SuperPowerId);
                    table.ForeignKey(
                        name: "FK_SuperPowers_Users_CreatedByUserIdUserId",
                        column: x => x.CreatedByUserIdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuperPowers_Users_UpdatedByUserIdUserId",
                        column: x => x.UpdatedByUserIdUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "SuperPowerUsers",
                columns: table => new
                {
                    SuperPowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPowerUsers", x => new { x.SuperPowerId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SuperPowerUsers_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_SuperPowerUsers_Users_LastUpdatedUserId",
                        column: x => x.LastUpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_SuperPowerUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "TerminalOperators",
                columns: table => new
                {
                    TerminalOperatorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TerminalOperators", x => x.TerminalOperatorId);
                    table.ForeignKey(
                        name: "FK_TerminalOperators_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "WalletUsers",
                columns: table => new
                {
                    WalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Balance = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalletUsers", x => new { x.WalletId, x.UserId });
                    table.ForeignKey(
                        name: "FK_WalletUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_WalletUsers_Wallets_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Wallets",
                        principalColumn: "WalletId");
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentStateId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    FinishTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                    table.ForeignKey(
                        name: "FK_Appointments_AppointmentStates_AppointmentStateId",
                        column: x => x.AppointmentStateId,
                        principalTable: "AppointmentStates",
                        principalColumn: "AppointmentStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Appointments_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId");
                    table.ForeignKey(
                        name: "FK_Appointments_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_Appointments_Users_LastUpdatedUserId",
                        column: x => x.LastUpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "HistoryPoints",
                columns: table => new
                {
                    PointHistoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WalletId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SuperPowerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: false),
                    Points = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryPoints", x => x.PointHistoryId);
                    table.ForeignKey(
                        name: "FK_HistoryPoints_SuperPowerUsers_UserId_SuperPowerId",
                        columns: x => new { x.UserId, x.SuperPowerId },
                        principalTable: "SuperPowerUsers",
                        principalColumns: new[] { "SuperPowerId", "UserId" });
                    table.ForeignKey(
                        name: "FK_HistoryPoints_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_HistoryPoints_Users_LastUpdatedUserId",
                        column: x => x.LastUpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_HistoryPoints_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_HistoryPoints_WalletUsers_UserId_WalletId",
                        columns: x => new { x.UserId, x.WalletId },
                        principalTable: "WalletUsers",
                        principalColumns: new[] { "WalletId", "UserId" });
                });

            migrationBuilder.CreateTable(
                name: "CargoInformation",
                columns: table => new
                {
                    CargoInformationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContainerId = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    LengthInFeet = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    HeightInFeet = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    WidthInFeet = table.Column<decimal>(type: "decimal(8,2)", nullable: false),
                    GrossWeightInKilos = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    NetWeightInKilos = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    TypeContainerId = table.Column<int>(type: "int", nullable: false),
                    GeographicalLocationOriginISOCountryId = table.Column<int>(type: "int", nullable: false),
                    GeographicalLocationDestinationISOCountryId = table.Column<int>(type: "int", nullable: false),
                    IsLoaded = table.Column<bool>(type: "bit", nullable: false),
                    TypeCargo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    TractorTrailerRegistrationNumber = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    IsOversizedLoad = table.Column<bool>(type: "bit", nullable: false),
                    IMOCode = table.Column<string>(type: "varchar(20)", unicode: false, maxLength: 20, nullable: false),
                    RequiredCelciusTemperature = table.Column<decimal>(type: "decimal(5,2)", nullable: false),
                    Notes = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CargoInformation", x => x.CargoInformationId);
                    table.ForeignKey(
                        name: "FK_CargoInformation_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CargoInformation_ISOCountries_GeographicalLocationDestinationISOCountryId",
                        column: x => x.GeographicalLocationDestinationISOCountryId,
                        principalTable: "ISOCountries",
                        principalColumn: "ISOCountryId");
                    table.ForeignKey(
                        name: "FK_CargoInformation_ISOCountries_GeographicalLocationOriginISOCountryId",
                        column: x => x.GeographicalLocationOriginISOCountryId,
                        principalTable: "ISOCountries",
                        principalColumn: "ISOCountryId");
                    table.ForeignKey(
                        name: "FK_CargoInformation_TypeContainers_TypeContainerId",
                        column: x => x.TypeContainerId,
                        principalTable: "TypeContainers",
                        principalColumn: "TypeContainerId");
                });

            migrationBuilder.CreateTable(
                name: "HistoryAppointments",
                columns: table => new
                {
                    HistoryAppointmentId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AppointmentStateId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    ProviderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DriverId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CalendarId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: true),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    FinishTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastUpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastUpdatedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoryAppointments", x => x.HistoryAppointmentId);
                    table.ForeignKey(
                        name: "FK_HistoryAppointments_AppointmentStates_AppointmentStateId",
                        column: x => x.AppointmentStateId,
                        principalTable: "AppointmentStates",
                        principalColumn: "AppointmentStateId");
                    table.ForeignKey(
                        name: "FK_HistoryAppointments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId");
                    table.ForeignKey(
                        name: "FK_HistoryAppointments_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "CalendarId");
                    table.ForeignKey(
                        name: "FK_HistoryAppointments_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "DriverId");
                    table.ForeignKey(
                        name: "FK_HistoryAppointments_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId");
                    table.ForeignKey(
                        name: "FK_HistoryAppointments_Providers_ProviderId",
                        column: x => x.ProviderId,
                        principalTable: "Providers",
                        principalColumn: "ProviderId");
                    table.ForeignKey(
                        name: "FK_HistoryAppointments_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                    table.ForeignKey(
                        name: "FK_HistoryAppointments_Users_LastUpdatedUserId",
                        column: x => x.LastUpdatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "MissionAppointments",
                columns: table => new
                {
                    MissionId = table.Column<int>(type: "int", nullable: false),
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MissionAppointments", x => new { x.MissionId, x.AppointmentId });
                    table.ForeignKey(
                        name: "FK_MissionAppointments_Appointments_AppointmentId",
                        column: x => x.AppointmentId,
                        principalTable: "Appointments",
                        principalColumn: "AppointmentId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MissionAppointments_Missions_MissionId",
                        column: x => x.MissionId,
                        principalTable: "Missions",
                        principalColumn: "MissionId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_AppointmentStateId",
                table: "Appointments",
                column: "AppointmentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CalendarId",
                table: "Appointments",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_CreatedUserId",
                table: "Appointments",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_DriverId",
                table: "Appointments",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_FinishTime",
                table: "Appointments",
                column: "FinishTime");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_LastUpdatedUserId",
                table: "Appointments",
                column: "LastUpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_LocationId",
                table: "Appointments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_ProviderId",
                table: "Appointments",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_Appointments_StartTime",
                table: "Appointments",
                column: "StartTime");

            migrationBuilder.CreateIndex(
                name: "IX_AppointmentStates_TerminalId",
                table: "AppointmentStates",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Calendars_TerminalId",
                table: "Calendars",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoInformation_AppointmentId",
                table: "CargoInformation",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoInformation_ContainerId",
                table: "CargoInformation",
                column: "ContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoInformation_GeographicalLocationDestinationISOCountryId",
                table: "CargoInformation",
                column: "GeographicalLocationDestinationISOCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoInformation_GeographicalLocationOriginISOCountryId",
                table: "CargoInformation",
                column: "GeographicalLocationOriginISOCountryId");

            migrationBuilder.CreateIndex(
                name: "IX_CargoInformation_TypeContainerId",
                table: "CargoInformation",
                column: "TypeContainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                table: "Cities",
                column: "StateId");

            migrationBuilder.CreateIndex(
                name: "IX_DayOfWeekSettings_CalendarId",
                table: "DayOfWeekSettings",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_DeadBands_CalendarId",
                table: "DeadBands",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_IdentificationTypeId",
                table: "Drivers",
                column: "IdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_LicenceNumber",
                table: "Drivers",
                column: "LicenceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_UserId",
                table: "Drivers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryAppointments_AppointmentId",
                table: "HistoryAppointments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryAppointments_AppointmentStateId",
                table: "HistoryAppointments",
                column: "AppointmentStateId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryAppointments_CalendarId",
                table: "HistoryAppointments",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryAppointments_CreatedUserId",
                table: "HistoryAppointments",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryAppointments_DriverId",
                table: "HistoryAppointments",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryAppointments_LastUpdatedUserId",
                table: "HistoryAppointments",
                column: "LastUpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryAppointments_LocationId",
                table: "HistoryAppointments",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryAppointments_ProviderId",
                table: "HistoryAppointments",
                column: "ProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryPoints_CreatedUserId",
                table: "HistoryPoints",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryPoints_LastUpdatedUserId",
                table: "HistoryPoints",
                column: "LastUpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_HistoryPoints_UserId_SuperPowerId",
                table: "HistoryPoints",
                columns: new[] { "UserId", "SuperPowerId" });

            migrationBuilder.CreateIndex(
                name: "IX_HistoryPoints_UserId_WalletId",
                table: "HistoryPoints",
                columns: new[] { "UserId", "WalletId" });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_TerminalId",
                table: "Locations",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_MissionAppointments_AppointmentId",
                table: "MissionAppointments",
                column: "AppointmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_CreatedUserId",
                table: "Missions",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Missions_LastUpdatedUserId",
                table: "Missions",
                column: "LastUpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Providers_FiscalNumber",
                table: "Providers",
                column: "FiscalNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Providers_UserId",
                table: "Providers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowers_CreatedByUserIdUserId",
                table: "SuperPowers",
                column: "CreatedByUserIdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowers_UpdatedByUserIdUserId",
                table: "SuperPowers",
                column: "UpdatedByUserIdUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowerUsers_CreatedUserId",
                table: "SuperPowerUsers",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowerUsers_LastUpdatedUserId",
                table: "SuperPowerUsers",
                column: "LastUpdatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowerUsers_UserId",
                table: "SuperPowerUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TerminalOperators_UserId",
                table: "TerminalOperators",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_GeographicLocationCityId",
                table: "Terminals",
                column: "GeographicLocationCityId");

            migrationBuilder.CreateIndex(
                name: "IX_Terminals_OperatorId",
                table: "Terminals",
                column: "OperatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_CategoryId",
                table: "Users",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TerminalId",
                table: "Users",
                column: "TerminalId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WalletUsers_UserId",
                table: "WalletUsers",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CargoInformation");

            migrationBuilder.DropTable(
                name: "DayOfWeekSettings");

            migrationBuilder.DropTable(
                name: "DeadBands");

            migrationBuilder.DropTable(
                name: "HistoryAppointments");

            migrationBuilder.DropTable(
                name: "HistoryPoints");

            migrationBuilder.DropTable(
                name: "MissionAppointments");

            migrationBuilder.DropTable(
                name: "SuperPowers");

            migrationBuilder.DropTable(
                name: "TerminalOperators");

            migrationBuilder.DropTable(
                name: "ISOCountries");

            migrationBuilder.DropTable(
                name: "TypeContainers");

            migrationBuilder.DropTable(
                name: "SuperPowerUsers");

            migrationBuilder.DropTable(
                name: "WalletUsers");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Missions");

            migrationBuilder.DropTable(
                name: "Wallets");

            migrationBuilder.DropTable(
                name: "AppointmentStates");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "Drivers");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Providers");

            migrationBuilder.DropTable(
                name: "IdentificationTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Terminals");

            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Operators");

            migrationBuilder.DropTable(
                name: "States");
        }
    }
}

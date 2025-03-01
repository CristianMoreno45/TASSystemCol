using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace UnalColombia.Logistic.TAS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Bigbang : Migration
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
                    IsReserve = table.Column<bool>(type: "bit", nullable: false),
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
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuperPowers", x => x.SuperPowerId);
                    table.ForeignKey(
                        name: "FK_SuperPowers_Users_CreatedUserId",
                        column: x => x.CreatedUserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SuperPowers_Users_LastUpdatedUserId",
                        column: x => x.LastUpdatedUserId,
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
                    StartTime = table.Column<DateTime>(type: "datetime", nullable: false),
                    FinishTime = table.Column<DateTime>(type: "datetime", nullable: false),
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
                    AppointmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsAchieved = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "IsActive", "Name", "RankingNumber" },
                values: new object[,]
                {
                    { 1, true, "Ocasional", 1 },
                    { 2, true, "Frecuente", 2 },
                    { 3, true, "Estrella 1", 3 },
                    { 4, true, "Estrella 2", 4 },
                    { 5, true, "Estrella 3", 5 },
                    { 6, true, "Estrella 4", 6 },
                    { 7, true, "Estrella 5", 7 },
                    { 8, true, "Gold", 8 },
                    { 9, true, "Premium", 100 }
                });

            migrationBuilder.InsertData(
                table: "ISOCountries",
                columns: new[] { "ISOCountryId", "A2", "A3", "Code", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "AF", "AFG", "4", true, "Afghanistan" },
                    { 2, "AL", "ALB", "8", true, "Albania" },
                    { 3, "DZ", "DZA", "12", true, "Algeria" },
                    { 4, "AS", "ASM", "16", true, "American Samoa" },
                    { 5, "AD", "AND", "20", true, "Andorra" },
                    { 6, "AO", "AGO", "24", true, "Angola" },
                    { 7, "AI", "AIA", "660", true, "Anguilla" },
                    { 8, "AQ", "ATA", "10", true, "Antarctica" },
                    { 9, "AG", "ATG", "28", true, "Antigua and Barbuda" },
                    { 10, "AR", "ARG", "32", true, "Argentina" },
                    { 11, "AM", "ARM", "51", true, "Armenia" },
                    { 12, "AW", "ABW", "533", true, "Aruba" },
                    { 13, "AU", "AUS", "36", true, "Australia" },
                    { 14, "AT", "AUT", "40", true, "Austria" },
                    { 15, "AZ", "AZE", "31", true, "Azerbaijan" },
                    { 16, "BS", "BHS", "44", true, "Bahamas (the)" },
                    { 17, "BH", "BHR", "48", true, "Bahrain" },
                    { 18, "BD", "BGD", "50", true, "Bangladesh" },
                    { 19, "BB", "BRB", "52", true, "Barbados" },
                    { 20, "BY", "BLR", "112", true, "Belarus" },
                    { 21, "BE", "BEL", "56", true, "Belgium" },
                    { 22, "BZ", "BLZ", "84", true, "Belize" },
                    { 23, "BJ", "BEN", "204", true, "Benin" },
                    { 24, "BM", "BMU", "60", true, "Bermuda" },
                    { 25, "BT", "BTN", "64", true, "Bhutan" },
                    { 26, "BO", "BOL", "68", true, "Bolivia (Plurinational State of)" },
                    { 27, "BQ", "BES", "535", true, "Bonaire, Sint Eustatius and Saba" },
                    { 28, "BA", "BIH", "70", true, "Bosnia and Herzegovina" },
                    { 29, "BW", "BWA", "72", true, "Botswana" },
                    { 30, "BV", "BVT", "74", true, "Bouvet Island" },
                    { 31, "BR", "BRA", "76", true, "Brazil" },
                    { 32, "IO", "IOT", "86", true, "British Indian Ocean Territory (the)" },
                    { 33, "BN", "BRN", "96", true, "Brunei Darussalam" },
                    { 34, "BG", "BGR", "100", true, "Bulgaria" },
                    { 35, "BF", "BFA", "854", true, "Burkina Faso" },
                    { 36, "BI", "BDI", "108", true, "Burundi" },
                    { 37, "CV", "CPV", "132", true, "Cabo Verde" },
                    { 38, "KH", "KHM", "116", true, "Cambodia" },
                    { 39, "CM", "CMR", "120", true, "Cameroon" },
                    { 40, "CA", "CAN", "124", true, "Canada" },
                    { 41, "KY", "CYM", "136", true, "Cayman Islands (the)" },
                    { 42, "CF", "CAF", "140", true, "Central African Republic (the)" },
                    { 43, "TD", "TCD", "148", true, "Chad" },
                    { 44, "CL", "CHL", "152", true, "Chile" },
                    { 45, "CN", "CHN", "156", true, "China" },
                    { 46, "CX", "CXR", "162", true, "Christmas Island" },
                    { 47, "CC", "CCK", "166", true, "Cocos (Keeling) Islands (the)" },
                    { 48, "CO", "COL", "170", true, "Colombia" },
                    { 49, "KM", "COM", "174", true, "Comoros (the)" },
                    { 50, "CD", "COD", "180", true, "Congo (the Democratic Republic of the)" },
                    { 51, "CG", "COG", "178", true, "Congo (the)" },
                    { 52, "CK", "COK", "184", true, "Cook Islands (the)" },
                    { 53, "CR", "CRI", "188", true, "Costa Rica" },
                    { 54, "HR", "HRV", "191", true, "Croatia" },
                    { 55, "CU", "CUB", "192", true, "Cuba" },
                    { 56, "CW", "CUW", "531", true, "Curaçao" },
                    { 57, "CY", "CYP", "196", true, "Cyprus" },
                    { 58, "CZ", "CZE", "203", true, "Czechia" },
                    { 59, "CI", "CIV", "384", true, "Côte d'Ivoire" },
                    { 60, "DK", "DNK", "208", true, "Denmark" },
                    { 61, "DJ", "DJI", "262", true, "Djibouti" },
                    { 62, "DM", "DMA", "212", true, "Dominica" },
                    { 63, "DO", "DOM", "214", true, "Dominican Republic (the)" },
                    { 64, "EC", "ECU", "218", true, "Ecuador" },
                    { 65, "EG", "EGY", "818", true, "Egypt" },
                    { 66, "SV", "SLV", "222", true, "El Salvador" },
                    { 67, "GQ", "GNQ", "226", true, "Equatorial Guinea" },
                    { 68, "ER", "ERI", "232", true, "Eritrea" },
                    { 69, "EE", "EST", "233", true, "Estonia" },
                    { 70, "SZ", "SWZ", "748", true, "Eswatini" },
                    { 71, "ET", "ETH", "231", true, "Ethiopia" },
                    { 72, "FK", "FLK", "238", true, "Falkland Islands (the) [Malvinas]" },
                    { 73, "FO", "FRO", "234", true, "Faroe Islands (the)" },
                    { 74, "FJ", "FJI", "242", true, "Fiji" },
                    { 75, "FI", "FIN", "246", true, "Finland" },
                    { 76, "FR", "FRA", "250", true, "France" },
                    { 77, "GF", "GUF", "254", true, "French Guiana" },
                    { 78, "PF", "PYF", "258", true, "French Polynesia" },
                    { 79, "TF", "ATF", "260", true, "French Southern Territories (the)" },
                    { 80, "GA", "GAB", "266", true, "Gabon" },
                    { 81, "GM", "GMB", "270", true, "Gambia (the)" },
                    { 82, "GE", "GEO", "268", true, "Georgia" },
                    { 83, "DE", "DEU", "276", true, "Germany" },
                    { 84, "GH", "GHA", "288", true, "Ghana" },
                    { 85, "GI", "GIB", "292", true, "Gibraltar" },
                    { 86, "GR", "GRC", "300", true, "Greece" },
                    { 87, "GL", "GRL", "304", true, "Greenland" },
                    { 88, "GD", "GRD", "308", true, "Grenada" },
                    { 89, "GP", "GLP", "312", true, "Guadeloupe" },
                    { 90, "GU", "GUM", "316", true, "Guam" },
                    { 91, "GT", "GTM", "320", true, "Guatemala" },
                    { 92, "GG", "GGY", "831", true, "Guernsey" },
                    { 93, "GN", "GIN", "324", true, "Guinea" },
                    { 94, "GW", "GNB", "624", true, "Guinea-Bissau" },
                    { 95, "GY", "GUY", "328", true, "Guyana" },
                    { 96, "HT", "HTI", "332", true, "Haiti" },
                    { 97, "HM", "HMD", "334", true, "Heard Island and McDonald Islands" },
                    { 98, "VA", "VAT", "336", true, "Holy See (the)" },
                    { 99, "HN", "HND", "340", true, "Honduras" },
                    { 100, "HK", "HKG", "344", true, "Hong Kong" },
                    { 101, "HU", "HUN", "348", true, "Hungary" },
                    { 102, "IS", "ISL", "352", true, "Iceland" },
                    { 103, "IN", "IND", "356", true, "India" },
                    { 104, "ID", "IDN", "360", true, "Indonesia" },
                    { 105, "IR", "IRN", "364", true, "Iran (Islamic Republic of)" },
                    { 106, "IQ", "IRQ", "368", true, "Iraq" },
                    { 107, "IE", "IRL", "372", true, "Ireland" },
                    { 108, "IM", "IMN", "833", true, "Isle of Man" },
                    { 109, "IL", "ISR", "376", true, "Israel" },
                    { 110, "IT", "ITA", "380", true, "Italy" },
                    { 111, "JM", "JAM", "388", true, "Jamaica" },
                    { 112, "JP", "JPN", "392", true, "Japan" },
                    { 113, "JE", "JEY", "832", true, "Jersey" },
                    { 114, "JO", "JOR", "400", true, "Jordan" },
                    { 115, "KZ", "KAZ", "398", true, "Kazakhstan" },
                    { 116, "KE", "KEN", "404", true, "Kenya" },
                    { 117, "KI", "KIR", "296", true, "Kiribati" },
                    { 118, "KP", "PRK", "408", true, "Korea (the Democratic People's Republic of)" },
                    { 119, "KR", "KOR", "410", true, "Korea (the Republic of)" },
                    { 120, "KW", "KWT", "414", true, "Kuwait" },
                    { 121, "KG", "KGZ", "417", true, "Kyrgyzstan" },
                    { 122, "LA", "LAO", "418", true, "Lao People's Democratic Republic (the)" },
                    { 123, "LV", "LVA", "428", true, "Latvia" },
                    { 124, "LB", "LBN", "422", true, "Lebanon" },
                    { 125, "LS", "LSO", "426", true, "Lesotho" },
                    { 126, "LR", "LBR", "430", true, "Liberia" },
                    { 127, "LY", "LBY", "434", true, "Libya" },
                    { 128, "LI", "LIE", "438", true, "Liechtenstein" },
                    { 129, "LT", "LTU", "440", true, "Lithuania" },
                    { 130, "LU", "LUX", "442", true, "Luxembourg" },
                    { 131, "MO", "MAC", "446", true, "Macao" },
                    { 132, "MG", "MDG", "450", true, "Madagascar" },
                    { 133, "MW", "MWI", "454", true, "Malawi" },
                    { 134, "MY", "MYS", "458", true, "Malaysia" },
                    { 135, "MV", "MDV", "462", true, "Maldives" },
                    { 136, "ML", "MLI", "466", true, "Mali" },
                    { 137, "MT", "MLT", "470", true, "Malta" },
                    { 138, "MH", "MHL", "584", true, "Marshall Islands (the)" },
                    { 139, "MQ", "MTQ", "474", true, "Martinique" },
                    { 140, "MR", "MRT", "478", true, "Mauritania" },
                    { 141, "MU", "MUS", "480", true, "Mauritius" },
                    { 142, "YT", "MYT", "175", true, "Mayotte" },
                    { 143, "MX", "MEX", "484", true, "Mexico" },
                    { 144, "FM", "FSM", "583", true, "Micronesia (Federated States of)" },
                    { 145, "MD", "MDA", "498", true, "Moldova (the Republic of)" },
                    { 146, "MC", "MCO", "492", true, "Monaco" },
                    { 147, "MN", "MNG", "496", true, "Mongolia" },
                    { 148, "ME", "MNE", "499", true, "Montenegro" },
                    { 149, "MS", "MSR", "500", true, "Montserrat" },
                    { 150, "MA", "MAR", "504", true, "Morocco" },
                    { 151, "MZ", "MOZ", "508", true, "Mozambique" },
                    { 152, "MM", "MMR", "104", true, "Myanmar" },
                    { 153, "NA", "NAM", "516", true, "Namibia" },
                    { 154, "NR", "NRU", "520", true, "Nauru" },
                    { 155, "NP", "NPL", "524", true, "Nepal" },
                    { 156, "NL", "NLD", "528", true, "Netherlands (the)" },
                    { 157, "NC", "NCL", "540", true, "New Caledonia" },
                    { 158, "NZ", "NZL", "554", true, "New Zealand" },
                    { 159, "NI", "NIC", "558", true, "Nicaragua" },
                    { 160, "NE", "NER", "562", true, "Niger (the)" },
                    { 161, "NG", "NGA", "566", true, "Nigeria" },
                    { 162, "NU", "NIU", "570", true, "Niue" },
                    { 163, "NF", "NFK", "574", true, "Norfolk Island" },
                    { 164, "MP", "MNP", "580", true, "Northern Mariana Islands (the)" },
                    { 165, "NO", "NOR", "578", true, "Norway" },
                    { 166, "OM", "OMN", "512", true, "Oman" },
                    { 167, "PK", "PAK", "586", true, "Pakistan" },
                    { 168, "PW", "PLW", "585", true, "Palau" },
                    { 169, "PS", "PSE", "275", true, "Palestine, State of" },
                    { 170, "PA", "PAN", "591", true, "Panama" },
                    { 171, "PG", "PNG", "598", true, "Papua New Guinea" },
                    { 172, "PY", "PRY", "600", true, "Paraguay" },
                    { 173, "PE", "PER", "604", true, "Peru" },
                    { 174, "PH", "PHL", "608", true, "Philippines (the)" },
                    { 175, "PN", "PCN", "612", true, "Pitcairn" },
                    { 176, "PL", "POL", "616", true, "Poland" },
                    { 177, "PT", "PRT", "620", true, "Portugal" },
                    { 178, "PR", "PRI", "630", true, "Puerto Rico" },
                    { 179, "QA", "QAT", "634", true, "Qatar" },
                    { 180, "MK", "MKD", "807", true, "Republic of North Macedonia" },
                    { 181, "RO", "ROU", "642", true, "Romania" },
                    { 182, "RU", "RUS", "643", true, "Russian Federation (the)" },
                    { 183, "RW", "RWA", "646", true, "Rwanda" },
                    { 184, "RE", "REU", "638", true, "Réunion" },
                    { 185, "BL", "BLM", "652", true, "Saint Barthélemy" },
                    { 186, "SH", "SHN", "654", true, "Saint Helena, Ascension and Tristan da Cunha" },
                    { 187, "KN", "KNA", "659", true, "Saint Kitts and Nevis" },
                    { 188, "LC", "LCA", "662", true, "Saint Lucia" },
                    { 189, "MF", "MAF", "663", true, "Saint Martin (French part)" },
                    { 190, "PM", "SPM", "666", true, "Saint Pierre and Miquelon" },
                    { 191, "VC", "VCT", "670", true, "Saint Vincent and the Grenadines" },
                    { 192, "WS", "WSM", "882", true, "Samoa" },
                    { 193, "SM", "SMR", "674", true, "San Marino" },
                    { 194, "ST", "STP", "678", true, "Sao Tome and Principe" },
                    { 195, "SA", "SAU", "682", true, "Saudi Arabia" },
                    { 196, "SN", "SEN", "686", true, "Senegal" },
                    { 197, "RS", "SRB", "688", true, "Serbia" },
                    { 198, "SC", "SYC", "690", true, "Seychelles" },
                    { 199, "SL", "SLE", "694", true, "Sierra Leone" },
                    { 200, "SG", "SGP", "702", true, "Singapore" },
                    { 201, "SX", "SXM", "534", true, "Sint Maarten (Dutch part)" },
                    { 202, "SK", "SVK", "703", true, "Slovakia" },
                    { 203, "SI", "SVN", "705", true, "Slovenia" },
                    { 204, "SB", "SLB", "90", true, "Solomon Islands" },
                    { 205, "SO", "SOM", "706", true, "Somalia" },
                    { 206, "ZA", "ZAF", "710", true, "South Africa" },
                    { 207, "GS", "SGS", "239", true, "South Georgia and the South Sandwich Islands" },
                    { 208, "SS", "SSD", "728", true, "South Sudan" },
                    { 209, "ES", "ESP", "724", true, "Spain" },
                    { 210, "LK", "LKA", "144", true, "Sri Lanka" },
                    { 211, "SD", "SDN", "729", true, "Sudan (the)" },
                    { 212, "SR", "SUR", "740", true, "Suriname" },
                    { 213, "SJ", "SJM", "744", true, "Svalbard and Jan Mayen" },
                    { 214, "SE", "SWE", "752", true, "Sweden" },
                    { 215, "CH", "CHE", "756", true, "Switzerland" },
                    { 216, "SY", "SYR", "760", true, "Syrian Arab Republic" },
                    { 217, "TW", "TWN", "158", true, "Taiwan (Province of China)" },
                    { 218, "TJ", "TJK", "762", true, "Tajikistan" },
                    { 219, "TZ", "TZA", "834", true, "Tanzania, United Republic of" },
                    { 220, "TH", "THA", "764", true, "Thailand" },
                    { 221, "TL", "TLS", "626", true, "Timor-Leste" },
                    { 222, "TG", "TGO", "768", true, "Togo" },
                    { 223, "TK", "TKL", "772", true, "Tokelau" },
                    { 224, "TO", "TON", "776", true, "Tonga" },
                    { 225, "TT", "TTO", "780", true, "Trinidad and Tobago" },
                    { 226, "TN", "TUN", "788", true, "Tunisia" },
                    { 227, "TR", "TUR", "792", true, "Turkey" },
                    { 228, "TM", "TKM", "795", true, "Turkmenistan" },
                    { 229, "TC", "TCA", "796", true, "Turks and Caicos Islands (the)" },
                    { 230, "TV", "TUV", "798", true, "Tuvalu" },
                    { 231, "UG", "UGA", "800", true, "Uganda" },
                    { 232, "UA", "UKR", "804", true, "Ukraine" },
                    { 233, "AE", "ARE", "784", true, "United Arab Emirates (the)" },
                    { 234, "GB", "GBR", "826", true, "United Kingdom of Great Britain and Northern Ireland (the)" },
                    { 235, "UM", "UMI", "581", true, "United States Minor Outlying Islands (the)" },
                    { 236, "US", "USA", "840", true, "United States of America (the)" },
                    { 237, "UY", "URY", "858", true, "Uruguay" },
                    { 238, "UZ", "UZB", "860", true, "Uzbekistan" },
                    { 239, "VU", "VUT", "548", true, "Vanuatu" },
                    { 240, "VE", "VEN", "862", true, "Venezuela (Bolivarian Republic of)" },
                    { 241, "VN", "VNM", "704", true, "Viet Nam" },
                    { 242, "VG", "VGB", "92", true, "Virgin Islands (British)" },
                    { 243, "VI", "VIR", "850", true, "Virgin Islands (U.S.)" },
                    { 244, "WF", "WLF", "876", true, "Wallis and Futuna" },
                    { 245, "EH", "ESH", "732", true, "Western Sahara" },
                    { 246, "YE", "YEM", "887", true, "Yemen" },
                    { 247, "ZM", "ZMB", "894", true, "Zambia" },
                    { 248, "ZW", "ZWE", "716", true, "Zimbabwe" },
                    { 249, "AX", "ALA", "248", true, "Åland Islands" }
                });

            migrationBuilder.InsertData(
                table: "IdentificationTypes",
                columns: new[] { "IdentificationTypeId", "Code1", "Code2", "Code3", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "CC", null, null, true, "Cédula de ciudadanía" },
                    { 2, "CC", null, null, true, "Cédula de extranjería" },
                    { 3, "PP", null, null, true, "Pasaporte" }
                });

            migrationBuilder.InsertData(
                table: "Operators",
                columns: new[] { "OperatorId", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1L, true, "Sociedad Portuaria Regional de Cartagena (SPRC)" },
                    { 2L, true, "Grupo Puerto de Buenaventura" },
                    { 3L, true, "Sociedad Portuaria de Santa Marta" },
                    { 4L, true, "Sociedad Portuaria de Barranquilla" },
                    { 5L, true, "Grupo PSA International" },
                    { 6L, true, "Sociedad Portuaria de Turbo" },
                    { 7L, true, "Sociedad Portuaria de Tumaco" }
                });

            migrationBuilder.InsertData(
                table: "States",
                columns: new[] { "StateId", "Code1", "Code2", "Code3", "IsActive", "Name" },
                values: new object[,]
                {
                    { 1, "05", null, null, true, "ANTIOQUIA" },
                    { 2, "08", null, null, true, "ATLÁNTICO" },
                    { 3, "11", null, null, true, "BOGOTÁ, D.C." },
                    { 4, "13", null, null, true, "BOLÍVAR" },
                    { 5, "15", null, null, true, "BOYACÁ" },
                    { 6, "17", null, null, true, "CALDAS" },
                    { 7, "18", null, null, true, "CAQUETÁ" },
                    { 8, "19", null, null, true, "CAUCA" },
                    { 9, "20", null, null, true, "CESAR" },
                    { 10, "23", null, null, true, "CÓRDOBA" },
                    { 11, "25", null, null, true, "CUNDINAMARCA" },
                    { 12, "27", null, null, true, "CHOCÓ" },
                    { 13, "41", null, null, true, "HUILA" },
                    { 14, "44", null, null, true, "LA GUAJIRA" },
                    { 15, "47", null, null, true, "MAGDALENA" },
                    { 16, "50", null, null, true, "META" },
                    { 17, "52", null, null, true, "NARIÑO" },
                    { 18, "54", null, null, true, "NORTE DE SANTANDER" },
                    { 19, "63", null, null, true, "QUINDÍO" },
                    { 20, "66", null, null, true, "RISARALDA" },
                    { 21, "68", null, null, true, "SANTANDER" },
                    { 22, "70", null, null, true, "SUCRE" },
                    { 23, "73", null, null, true, "TOLIMA" },
                    { 24, "76", null, null, true, "VALLE DEL CAUCA" },
                    { 25, "81", null, null, true, "ARAUCA" },
                    { 26, "85", null, null, true, "CASANARE" },
                    { 27, "86", null, null, true, "PUTUMAYO" },
                    { 28, "88", null, null, true, "ARCHIPIÉLAGO DE SAN ANDRÉS, PROVIDENCIA Y SANTA CATALINA" },
                    { 29, "91", null, null, true, "AMAZONAS" },
                    { 30, "94", null, null, true, "GUAINÍA" },
                    { 31, "95", null, null, true, "GUAVIARE" },
                    { 32, "97", null, null, true, "VAUPÉS" },
                    { 33, "99", null, null, true, "VICHADA" }
                });

            migrationBuilder.InsertData(
                table: "TypeContainers",
                columns: new[] { "TypeContainerId", "Code", "Description", "IsActive" },
                values: new object[,]
                {
                    { 1, "05", "Refrigerado", true },
                    { 2, "22", "Seco 20ft", true },
                    { 3, "25", "Seco 20ft High Cube", true },
                    { 4, "42", "Seco 40ft", true },
                    { 5, "43", "Seco 40ft High Cube", true },
                    { 6, "45", "Seco 40ft Pallet Wide", true },
                    { 7, "53", "Seco 45ft High Cube", true },
                    { 8, "63", "Tanque 20ft", true },
                    { 9, "66", "Tanque 40ft", true },
                    { 10, "82", "Plataforma 20ft", true },
                    { 11, "85", "Plataforma 40ft", true },
                    { 99, "99", "Desconocido", true }
                });

            migrationBuilder.InsertData(
                table: "Wallets",
                columns: new[] { "WalletId", "IsActive", "Name" },
                values: new object[,]
                {
                    { new Guid("2767eaa8-b36c-4b28-85ff-64aca70aac5c"), true, "General" },
                    { new Guid("ee2b3a84-43b1-46cf-b29e-7ad4db5a2000"), true, "General" }
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Code1", "Code2", "Code3", "IsActive", "Name", "StateId" },
                values: new object[,]
                {
                    { 1, "05001", null, null, false, "MEDELLÍN", 1 },
                    { 2, "05002", null, null, false, "ABEJORRAL", 1 },
                    { 3, "05004", null, null, false, "ABRIAQUÍ", 1 },
                    { 4, "05021", null, null, false, "ALEJANDRÍA", 1 },
                    { 5, "05030", null, null, false, "AMAGÁ", 1 },
                    { 6, "05031", null, null, false, "AMALFI", 1 },
                    { 7, "05034", null, null, false, "ANDES", 1 },
                    { 8, "05036", null, null, false, "ANGELÓPOLIS", 1 },
                    { 9, "05038", null, null, false, "ANGOSTURA", 1 },
                    { 10, "05040", null, null, false, "ANORÍ", 1 },
                    { 11, "05042", null, null, false, "SANTA FÉ DE ANTIOQUIA", 1 },
                    { 12, "05044", null, null, false, "ANZÁ", 1 },
                    { 13, "05045", null, null, false, "APARTADÓ", 1 },
                    { 14, "05051", null, null, false, "ARBOLETES", 1 },
                    { 15, "05055", null, null, false, "ARGELIA", 1 },
                    { 16, "05059", null, null, false, "ARMENIA", 1 },
                    { 17, "05079", null, null, false, "BARBOSA", 1 },
                    { 18, "05086", null, null, false, "BELMIRA", 1 },
                    { 19, "05088", null, null, false, "BELLO", 1 },
                    { 20, "05091", null, null, false, "BETANIA", 1 },
                    { 21, "05093", null, null, false, "BETULIA", 1 },
                    { 22, "05101", null, null, false, "CIUDAD BOLÍVAR", 1 },
                    { 23, "05107", null, null, false, "BRICEÑO", 1 },
                    { 24, "05113", null, null, false, "BURITICÁ", 1 },
                    { 25, "05120", null, null, false, "CÁCERES", 1 },
                    { 26, "05125", null, null, false, "CAICEDO", 1 },
                    { 27, "05129", null, null, false, "CALDAS", 1 },
                    { 28, "05134", null, null, false, "CAMPAMENTO", 1 },
                    { 29, "05138", null, null, false, "CAÑASGORDAS", 1 },
                    { 30, "05142", null, null, false, "CARACOLÍ", 1 },
                    { 31, "05145", null, null, false, "CARAMANTA", 1 },
                    { 32, "05147", null, null, false, "CAREPA", 1 },
                    { 33, "05148", null, null, false, "EL CARMEN DE VIBORAL", 1 },
                    { 34, "05150", null, null, false, "CAROLINA", 1 },
                    { 35, "05154", null, null, false, "CAUCASIA", 1 },
                    { 36, "05172", null, null, false, "CHIGORODÓ", 1 },
                    { 37, "05190", null, null, false, "CISNEROS", 1 },
                    { 38, "05197", null, null, false, "COCORNÁ", 1 },
                    { 39, "05206", null, null, false, "CONCEPCIÓN", 1 },
                    { 40, "05209", null, null, false, "CONCORDIA", 1 },
                    { 41, "05212", null, null, false, "COPACABANA", 1 },
                    { 42, "05234", null, null, false, "DABEIBA", 1 },
                    { 43, "05237", null, null, false, "DONMATÍAS", 1 },
                    { 44, "05240", null, null, false, "EBÉJICO", 1 },
                    { 45, "05250", null, null, false, "EL BAGRE", 1 },
                    { 46, "05264", null, null, false, "ENTRERRÍOS", 1 },
                    { 47, "05266", null, null, false, "ENVIGADO", 1 },
                    { 48, "05282", null, null, false, "FREDONIA", 1 },
                    { 49, "05284", null, null, false, "FRONTINO", 1 },
                    { 50, "05306", null, null, false, "GIRALDO", 1 },
                    { 51, "05308", null, null, false, "GIRARDOTA", 1 },
                    { 52, "05310", null, null, false, "GÓMEZ PLATA", 1 },
                    { 53, "05313", null, null, false, "GRANADA", 1 },
                    { 54, "05315", null, null, false, "GUADALUPE", 1 },
                    { 55, "05318", null, null, false, "GUARNE", 1 },
                    { 56, "05321", null, null, false, "GUATAPÉ", 1 },
                    { 57, "05347", null, null, false, "HELICONIA", 1 },
                    { 58, "05353", null, null, false, "HISPANIA", 1 },
                    { 59, "05360", null, null, false, "ITAGÜÍ", 1 },
                    { 60, "05361", null, null, false, "ITUANGO", 1 },
                    { 61, "05364", null, null, false, "JARDÍN", 1 },
                    { 62, "05368", null, null, false, "JERICÓ", 1 },
                    { 63, "05376", null, null, false, "LA CEJA", 1 },
                    { 64, "05380", null, null, false, "LA ESTRELLA", 1 },
                    { 65, "05390", null, null, false, "LA PINTADA", 1 },
                    { 66, "05400", null, null, false, "LA UNIÓN", 1 },
                    { 67, "05411", null, null, false, "LIBORINA", 1 },
                    { 68, "05425", null, null, false, "MACEO", 1 },
                    { 69, "05440", null, null, false, "MARINILLA", 1 },
                    { 70, "05467", null, null, false, "MONTEBELLO", 1 },
                    { 71, "05475", null, null, false, "MURINDÓ", 1 },
                    { 72, "05480", null, null, false, "MUTATÁ", 1 },
                    { 73, "05483", null, null, false, "NARIÑO", 1 },
                    { 74, "05490", null, null, false, "NECOCLÍ", 1 },
                    { 75, "05495", null, null, false, "NECHÍ", 1 },
                    { 76, "05501", null, null, false, "OLAYA", 1 },
                    { 77, "05541", null, null, false, "PEÑOL", 1 },
                    { 78, "05543", null, null, false, "PEQUE", 1 },
                    { 79, "05576", null, null, false, "PUEBLORRICO", 1 },
                    { 80, "05579", null, null, false, "PUERTO BERRÍO", 1 },
                    { 81, "05585", null, null, false, "PUERTO NARE", 1 },
                    { 82, "05591", null, null, false, "PUERTO TRIUNFO", 1 },
                    { 83, "05604", null, null, false, "REMEDIOS", 1 },
                    { 84, "05607", null, null, false, "RETIRO", 1 },
                    { 85, "05615", null, null, false, "RIONEGRO", 1 },
                    { 86, "05628", null, null, false, "SABANALARGA", 1 },
                    { 87, "05631", null, null, false, "SABANETA", 1 },
                    { 88, "05642", null, null, false, "SALGAR", 1 },
                    { 89, "05647", null, null, false, "SAN ANDRÉS DE CUERQUÍA", 1 },
                    { 90, "05649", null, null, false, "SAN CARLOS", 1 },
                    { 91, "05652", null, null, false, "SAN FRANCISCO", 1 },
                    { 92, "05656", null, null, false, "SAN JERÓNIMO", 1 },
                    { 93, "05658", null, null, false, "SAN JOSÉ DE LA MONTAÑA", 1 },
                    { 94, "05659", null, null, false, "SAN JUAN DE URABÁ", 1 },
                    { 95, "05660", null, null, false, "SAN LUIS", 1 },
                    { 96, "05664", null, null, false, "SAN PEDRO DE LOS MILAGROS", 1 },
                    { 97, "05665", null, null, false, "SAN PEDRO DE URABÁ", 1 },
                    { 98, "05667", null, null, false, "SAN RAFAEL", 1 },
                    { 99, "05670", null, null, false, "SAN ROQUE", 1 },
                    { 100, "05674", null, null, false, "SAN VICENTE FERRER", 1 },
                    { 101, "05679", null, null, false, "SANTA BÁRBARA", 1 },
                    { 102, "05686", null, null, false, "SANTA ROSA DE OSOS", 1 },
                    { 103, "05690", null, null, false, "SANTO DOMINGO", 1 },
                    { 104, "05697", null, null, false, "EL SANTUARIO", 1 },
                    { 105, "05736", null, null, false, "SEGOVIA", 1 },
                    { 106, "05756", null, null, false, "SONSÓN", 1 },
                    { 107, "05761", null, null, false, "SOPETRÁN", 1 },
                    { 108, "05789", null, null, false, "TÁMESIS", 1 },
                    { 109, "05790", null, null, false, "TARAZÁ", 1 },
                    { 110, "05792", null, null, false, "TARSO", 1 },
                    { 111, "05809", null, null, false, "TITIRIBÍ", 1 },
                    { 112, "05819", null, null, false, "TOLEDO", 1 },
                    { 113, "05837", null, null, false, "TURBO", 1 },
                    { 114, "05842", null, null, false, "URAMITA", 1 },
                    { 115, "05847", null, null, false, "URRAO", 1 },
                    { 116, "05854", null, null, false, "VALDIVIA", 1 },
                    { 117, "05856", null, null, false, "VALPARAÍSO", 1 },
                    { 118, "05858", null, null, false, "VEGACHÍ", 1 },
                    { 119, "05861", null, null, false, "VENECIA", 1 },
                    { 120, "05873", null, null, false, "VIGÍA DEL FUERTE", 1 },
                    { 121, "05885", null, null, false, "YALÍ", 1 },
                    { 122, "05887", null, null, false, "YARUMAL", 1 },
                    { 123, "05890", null, null, false, "YOLOMBÓ", 1 },
                    { 124, "05893", null, null, false, "YONDÓ", 1 },
                    { 125, "05895", null, null, false, "ZARAGOZA", 1 },
                    { 126, "08001", null, null, false, "BARRANQUILLA", 2 },
                    { 127, "08078", null, null, false, "BARANOA", 2 },
                    { 128, "08137", null, null, false, "CAMPO DE LA CRUZ", 2 },
                    { 129, "08141", null, null, false, "CANDELARIA", 2 },
                    { 130, "08296", null, null, false, "GALAPA", 2 },
                    { 131, "08372", null, null, false, "JUAN DE ACOSTA", 2 },
                    { 132, "08421", null, null, false, "LURUACO", 2 },
                    { 133, "08433", null, null, false, "MALAMBO", 2 },
                    { 134, "08436", null, null, false, "MANATÍ", 2 },
                    { 135, "08520", null, null, false, "PALMAR DE VARELA", 2 },
                    { 136, "08549", null, null, false, "PIOJÓ", 2 },
                    { 137, "08558", null, null, false, "POLONUEVO", 2 },
                    { 138, "08560", null, null, false, "PONEDERA", 2 },
                    { 139, "08573", null, null, false, "PUERTO COLOMBIA", 2 },
                    { 140, "08606", null, null, false, "REPELÓN", 2 },
                    { 141, "08634", null, null, false, "SABANAGRANDE", 2 },
                    { 142, "08638", null, null, false, "SABANALARGA", 2 },
                    { 143, "08675", null, null, false, "SANTA LUCÍA", 2 },
                    { 144, "08685", null, null, false, "SANTO TOMÁS", 2 },
                    { 145, "08758", null, null, false, "SOLEDAD", 2 },
                    { 146, "08770", null, null, false, "SUAN", 2 },
                    { 147, "08832", null, null, false, "TUBARÁ", 2 },
                    { 148, "08849", null, null, false, "USIACURÍ", 2 },
                    { 149, "11001", null, null, false, "BOGOTÁ, D.C.", 3 },
                    { 150, "13001", null, null, false, "CARTAGENA DE INDIAS", 4 },
                    { 151, "13006", null, null, false, "ACHÍ", 4 },
                    { 152, "13030", null, null, false, "ALTOS DEL ROSARIO", 4 },
                    { 153, "13042", null, null, false, "ARENAL", 4 },
                    { 154, "13052", null, null, false, "ARJONA", 4 },
                    { 155, "13062", null, null, false, "ARROYOHONDO", 4 },
                    { 156, "13074", null, null, false, "BARRANCO DE LOBA", 4 },
                    { 157, "13140", null, null, false, "CALAMAR", 4 },
                    { 158, "13160", null, null, false, "CANTAGALLO", 4 },
                    { 159, "13188", null, null, false, "CICUCO", 4 },
                    { 160, "13212", null, null, false, "CÓRDOBA", 4 },
                    { 161, "13222", null, null, false, "CLEMENCIA", 4 },
                    { 162, "13244", null, null, false, "EL CARMEN DE BOLÍVAR", 4 },
                    { 163, "13248", null, null, false, "EL GUAMO", 4 },
                    { 164, "13268", null, null, false, "EL PEÑÓN", 4 },
                    { 165, "13300", null, null, false, "HATILLO DE LOBA", 4 },
                    { 166, "13430", null, null, false, "MAGANGUÉ", 4 },
                    { 167, "13433", null, null, false, "MAHATES", 4 },
                    { 168, "13440", null, null, false, "MARGARITA", 4 },
                    { 169, "13442", null, null, false, "MARÍA LA BAJA", 4 },
                    { 170, "13458", null, null, false, "MONTECRISTO", 4 },
                    { 171, "13468", null, null, false, "SANTA CRUZ DE MOMPOX", 4 },
                    { 172, "13473", null, null, false, "MORALES", 4 },
                    { 173, "13490", null, null, false, "NOROSÍ", 4 },
                    { 174, "13549", null, null, false, "PINILLOS", 4 },
                    { 175, "13580", null, null, false, "REGIDOR", 4 },
                    { 176, "13600", null, null, false, "RÍO VIEJO", 4 },
                    { 177, "13620", null, null, false, "SAN CRISTÓBAL", 4 },
                    { 178, "13647", null, null, false, "SAN ESTANISLAO", 4 },
                    { 179, "13650", null, null, false, "SAN FERNANDO", 4 },
                    { 180, "13654", null, null, false, "SAN JACINTO", 4 },
                    { 181, "13655", null, null, false, "SAN JACINTO DEL CAUCA", 4 },
                    { 182, "13657", null, null, false, "SAN JUAN NEPOMUCENO", 4 },
                    { 183, "13667", null, null, false, "SAN MARTÍN DE LOBA", 4 },
                    { 184, "13670", null, null, false, "SAN PABLO", 4 },
                    { 185, "13673", null, null, false, "SANTA CATALINA", 4 },
                    { 186, "13683", null, null, false, "SANTA ROSA", 4 },
                    { 187, "13688", null, null, false, "SANTA ROSA DEL SUR", 4 },
                    { 188, "13744", null, null, false, "SIMITÍ", 4 },
                    { 189, "13760", null, null, false, "SOPLAVIENTO", 4 },
                    { 190, "13780", null, null, false, "TALAIGUA NUEVO", 4 },
                    { 191, "13810", null, null, false, "TIQUISIO", 4 },
                    { 192, "13836", null, null, false, "TURBACO", 4 },
                    { 193, "13838", null, null, false, "TURBANÁ", 4 },
                    { 194, "13873", null, null, false, "VILLANUEVA", 4 },
                    { 195, "13894", null, null, false, "ZAMBRANO", 4 },
                    { 196, "15001", null, null, false, "TUNJA", 5 },
                    { 197, "15022", null, null, false, "ALMEIDA", 5 },
                    { 198, "15047", null, null, false, "AQUITANIA", 5 },
                    { 199, "15051", null, null, false, "ARCABUCO", 5 },
                    { 200, "15087", null, null, false, "BELÉN", 5 },
                    { 201, "15090", null, null, false, "BERBEO", 5 },
                    { 202, "15092", null, null, false, "BETÉITIVA", 5 },
                    { 203, "15097", null, null, false, "BOAVITA", 5 },
                    { 204, "15104", null, null, false, "BOYACÁ", 5 },
                    { 205, "15106", null, null, false, "BRICEÑO", 5 },
                    { 206, "15109", null, null, false, "BUENAVISTA", 5 },
                    { 207, "15114", null, null, false, "BUSBANZÁ", 5 },
                    { 208, "15131", null, null, false, "CALDAS", 5 },
                    { 209, "15135", null, null, false, "CAMPOHERMOSO", 5 },
                    { 210, "15162", null, null, false, "CERINZA", 5 },
                    { 211, "15172", null, null, false, "CHINAVITA", 5 },
                    { 212, "15176", null, null, false, "CHIQUINQUIRÁ", 5 },
                    { 213, "15180", null, null, false, "CHISCAS", 5 },
                    { 214, "15183", null, null, false, "CHITA", 5 },
                    { 215, "15185", null, null, false, "CHITARAQUE", 5 },
                    { 216, "15187", null, null, false, "CHIVATÁ", 5 },
                    { 217, "15189", null, null, false, "CIÉNEGA", 5 },
                    { 218, "15204", null, null, false, "CÓMBITA", 5 },
                    { 219, "15212", null, null, false, "COPER", 5 },
                    { 220, "15215", null, null, false, "CORRALES", 5 },
                    { 221, "15218", null, null, false, "COVARACHÍA", 5 },
                    { 222, "15223", null, null, false, "CUBARÁ", 5 },
                    { 223, "15224", null, null, false, "CUCAITA", 5 },
                    { 224, "15226", null, null, false, "CUÍTIVA", 5 },
                    { 225, "15232", null, null, false, "CHÍQUIZA", 5 },
                    { 226, "15236", null, null, false, "CHIVOR", 5 },
                    { 227, "15238", null, null, false, "DUITAMA", 5 },
                    { 228, "15244", null, null, false, "EL COCUY", 5 },
                    { 229, "15248", null, null, false, "EL ESPINO", 5 },
                    { 230, "15272", null, null, false, "FIRAVITOBA", 5 },
                    { 231, "15276", null, null, false, "FLORESTA", 5 },
                    { 232, "15293", null, null, false, "GACHANTIVÁ", 5 },
                    { 233, "15296", null, null, false, "GÁMEZA", 5 },
                    { 234, "15299", null, null, false, "GARAGOA", 5 },
                    { 235, "15317", null, null, false, "GUACAMAYAS", 5 },
                    { 236, "15322", null, null, false, "GUATEQUE", 5 },
                    { 237, "15325", null, null, false, "GUAYATÁ", 5 },
                    { 238, "15332", null, null, false, "GÜICÁN DE LA SIERRA", 5 },
                    { 239, "15362", null, null, false, "IZA", 5 },
                    { 240, "15367", null, null, false, "JENESANO", 5 },
                    { 241, "15368", null, null, false, "JERICÓ", 5 },
                    { 242, "15377", null, null, false, "LABRANZAGRANDE", 5 },
                    { 243, "15380", null, null, false, "LA CAPILLA", 5 },
                    { 244, "15401", null, null, false, "LA VICTORIA", 5 },
                    { 245, "15403", null, null, false, "LA UVITA", 5 },
                    { 246, "15407", null, null, false, "VILLA DE LEYVA", 5 },
                    { 247, "15425", null, null, false, "MACANAL", 5 },
                    { 248, "15442", null, null, false, "MARIPÍ", 5 },
                    { 249, "15455", null, null, false, "MIRAFLORES", 5 },
                    { 250, "15464", null, null, false, "MONGUA", 5 },
                    { 251, "15466", null, null, false, "MONGUÍ", 5 },
                    { 252, "15469", null, null, false, "MONIQUIRÁ", 5 },
                    { 253, "15476", null, null, false, "MOTAVITA", 5 },
                    { 254, "15480", null, null, false, "MUZO", 5 },
                    { 255, "15491", null, null, false, "NOBSA", 5 },
                    { 256, "15494", null, null, false, "NUEVO COLÓN", 5 },
                    { 257, "15500", null, null, false, "OICATÁ", 5 },
                    { 258, "15507", null, null, false, "OTANCHE", 5 },
                    { 259, "15511", null, null, false, "PACHAVITA", 5 },
                    { 260, "15514", null, null, false, "PÁEZ", 5 },
                    { 261, "15516", null, null, false, "PAIPA", 5 },
                    { 262, "15518", null, null, false, "PAJARITO", 5 },
                    { 263, "15522", null, null, false, "PANQUEBA", 5 },
                    { 264, "15531", null, null, false, "PAUNA", 5 },
                    { 265, "15533", null, null, false, "PAYA", 5 },
                    { 266, "15537", null, null, false, "PAZ DE RÍO", 5 },
                    { 267, "15542", null, null, false, "PESCA", 5 },
                    { 268, "15550", null, null, false, "PISBA", 5 },
                    { 269, "15572", null, null, false, "PUERTO BOYACÁ", 5 },
                    { 270, "15580", null, null, false, "QUÍPAMA", 5 },
                    { 271, "15599", null, null, false, "RAMIRIQUÍ", 5 },
                    { 272, "15600", null, null, false, "RÁQUIRA", 5 },
                    { 273, "15621", null, null, false, "RONDÓN", 5 },
                    { 274, "15632", null, null, false, "SABOYÁ", 5 },
                    { 275, "15638", null, null, false, "SÁCHICA", 5 },
                    { 276, "15646", null, null, false, "SAMACÁ", 5 },
                    { 277, "15660", null, null, false, "SAN EDUARDO", 5 },
                    { 278, "15664", null, null, false, "SAN JOSÉ DE PARE", 5 },
                    { 279, "15667", null, null, false, "SAN LUIS DE GACENO", 5 },
                    { 280, "15673", null, null, false, "SAN MATEO", 5 },
                    { 281, "15676", null, null, false, "SAN MIGUEL DE SEMA", 5 },
                    { 282, "15681", null, null, false, "SAN PABLO DE BORBUR", 5 },
                    { 283, "15686", null, null, false, "SANTANA", 5 },
                    { 284, "15690", null, null, false, "SANTA MARÍA", 5 },
                    { 285, "15693", null, null, false, "SANTA ROSA DE VITERBO", 5 },
                    { 286, "15696", null, null, false, "SANTA SOFÍA", 5 },
                    { 287, "15720", null, null, false, "SATIVANORTE", 5 },
                    { 288, "15723", null, null, false, "SATIVASUR", 5 },
                    { 289, "15740", null, null, false, "SIACHOQUE", 5 },
                    { 290, "15753", null, null, false, "SOATÁ", 5 },
                    { 291, "15755", null, null, false, "SOCOTÁ", 5 },
                    { 292, "15757", null, null, false, "SOCHA", 5 },
                    { 293, "15759", null, null, false, "SOGAMOSO", 5 },
                    { 294, "15761", null, null, false, "SOMONDOCO", 5 },
                    { 295, "15762", null, null, false, "SORA", 5 },
                    { 296, "15763", null, null, false, "SOTAQUIRÁ", 5 },
                    { 297, "15764", null, null, false, "SORACÁ", 5 },
                    { 298, "15774", null, null, false, "SUSACÓN", 5 },
                    { 299, "15776", null, null, false, "SUTAMARCHÁN", 5 },
                    { 300, "15778", null, null, false, "SUTATENZA", 5 },
                    { 301, "15790", null, null, false, "TASCO", 5 },
                    { 302, "15798", null, null, false, "TENZA", 5 },
                    { 303, "15804", null, null, false, "TIBANÁ", 5 },
                    { 304, "15806", null, null, false, "TIBASOSA", 5 },
                    { 305, "15808", null, null, false, "TINJACÁ", 5 },
                    { 306, "15810", null, null, false, "TIPACOQUE", 5 },
                    { 307, "15814", null, null, false, "TOCA", 5 },
                    { 308, "15816", null, null, false, "TOGÜÍ", 5 },
                    { 309, "15820", null, null, false, "TÓPAGA", 5 },
                    { 310, "15822", null, null, false, "TOTA", 5 },
                    { 311, "15832", null, null, false, "TUNUNGUÁ", 5 },
                    { 312, "15835", null, null, false, "TURMEQUÉ", 5 },
                    { 313, "15837", null, null, false, "TUTA", 5 },
                    { 314, "15839", null, null, false, "TUTAZÁ", 5 },
                    { 315, "15842", null, null, false, "ÚMBITA", 5 },
                    { 316, "15861", null, null, false, "VENTAQUEMADA", 5 },
                    { 317, "15879", null, null, false, "VIRACACHÁ", 5 },
                    { 318, "15897", null, null, false, "ZETAQUIRA", 5 },
                    { 319, "17001", null, null, false, "MANIZALES", 6 },
                    { 320, "17013", null, null, false, "AGUADAS", 6 },
                    { 321, "17042", null, null, false, "ANSERMA", 6 },
                    { 322, "17050", null, null, false, "ARANZAZU", 6 },
                    { 323, "17088", null, null, false, "BELALCÁZAR", 6 },
                    { 324, "17174", null, null, false, "CHINCHINÁ", 6 },
                    { 325, "17272", null, null, false, "FILADELFIA", 6 },
                    { 326, "17380", null, null, false, "LA DORADA", 6 },
                    { 327, "17388", null, null, false, "LA MERCED", 6 },
                    { 328, "17433", null, null, false, "MANZANARES", 6 },
                    { 329, "17442", null, null, false, "MARMATO", 6 },
                    { 330, "17444", null, null, false, "MARQUETALIA", 6 },
                    { 331, "17446", null, null, false, "MARULANDA", 6 },
                    { 332, "17486", null, null, false, "NEIRA", 6 },
                    { 333, "17495", null, null, false, "NORCASIA", 6 },
                    { 334, "17513", null, null, false, "PÁCORA", 6 },
                    { 335, "17524", null, null, false, "PALESTINA", 6 },
                    { 336, "17541", null, null, false, "PENSILVANIA", 6 },
                    { 337, "17614", null, null, false, "RIOSUCIO", 6 },
                    { 338, "17616", null, null, false, "RISARALDA", 6 },
                    { 339, "17653", null, null, false, "SALAMINA", 6 },
                    { 340, "17662", null, null, false, "SAMANÁ", 6 },
                    { 341, "17665", null, null, false, "SAN JOSÉ", 6 },
                    { 342, "17777", null, null, false, "SUPÍA", 6 },
                    { 343, "17867", null, null, false, "VICTORIA", 6 },
                    { 344, "17873", null, null, false, "VILLAMARÍA", 6 },
                    { 345, "17877", null, null, false, "VITERBO", 6 },
                    { 346, "18001", null, null, false, "FLORENCIA", 7 },
                    { 347, "18029", null, null, false, "ALBANIA", 7 },
                    { 348, "18094", null, null, false, "BELÉN DE LOS ANDAQUÍES", 7 },
                    { 349, "18150", null, null, false, "CARTAGENA DEL CHAIRÁ", 7 },
                    { 350, "18205", null, null, false, "CURILLO", 7 },
                    { 351, "18247", null, null, false, "EL DONCELLO", 7 },
                    { 352, "18256", null, null, false, "EL PAUJÍL", 7 },
                    { 353, "18410", null, null, false, "LA MONTAÑITA", 7 },
                    { 354, "18460", null, null, false, "MILÁN", 7 },
                    { 355, "18479", null, null, false, "MORELIA", 7 },
                    { 356, "18592", null, null, false, "PUERTO RICO", 7 },
                    { 357, "18610", null, null, false, "SAN JOSÉ DEL FRAGUA", 7 },
                    { 358, "18753", null, null, false, "SAN VICENTE DEL CAGUÁN", 7 },
                    { 359, "18756", null, null, false, "SOLANO", 7 },
                    { 360, "18785", null, null, false, "SOLITA", 7 },
                    { 361, "18860", null, null, false, "VALPARAÍSO", 7 },
                    { 362, "19001", null, null, false, "POPAYÁN", 8 },
                    { 363, "19022", null, null, false, "ALMAGUER", 8 },
                    { 364, "19050", null, null, false, "ARGELIA", 8 },
                    { 365, "19075", null, null, false, "BALBOA", 8 },
                    { 366, "19100", null, null, false, "BOLÍVAR", 8 },
                    { 367, "19110", null, null, false, "BUENOS AIRES", 8 },
                    { 368, "19130", null, null, false, "CAJIBÍO", 8 },
                    { 369, "19137", null, null, false, "CALDONO", 8 },
                    { 370, "19142", null, null, false, "CALOTO", 8 },
                    { 371, "19212", null, null, false, "CORINTO", 8 },
                    { 372, "19256", null, null, false, "EL TAMBO", 8 },
                    { 373, "19290", null, null, false, "FLORENCIA", 8 },
                    { 374, "19300", null, null, false, "GUACHENÉ", 8 },
                    { 375, "19318", null, null, false, "GUAPI", 8 },
                    { 376, "19355", null, null, false, "INZÁ", 8 },
                    { 377, "19364", null, null, false, "JAMBALÓ", 8 },
                    { 378, "19392", null, null, false, "LA SIERRA", 8 },
                    { 379, "19397", null, null, false, "LA VEGA", 8 },
                    { 380, "19418", null, null, false, "LÓPEZ DE MICAY", 8 },
                    { 381, "19450", null, null, false, "MERCADERES", 8 },
                    { 382, "19455", null, null, false, "MIRANDA", 8 },
                    { 383, "19473", null, null, false, "MORALES", 8 },
                    { 384, "19513", null, null, false, "PADILLA", 8 },
                    { 385, "19517", null, null, false, "PÁEZ", 8 },
                    { 386, "19532", null, null, false, "PATÍA", 8 },
                    { 387, "19533", null, null, false, "PIAMONTE", 8 },
                    { 388, "19548", null, null, false, "PIENDAMÓ - TUNÍA", 8 },
                    { 389, "19573", null, null, false, "PUERTO TEJADA", 8 },
                    { 390, "19585", null, null, false, "PURACÉ", 8 },
                    { 391, "19622", null, null, false, "ROSAS", 8 },
                    { 392, "19693", null, null, false, "SAN SEBASTIÁN", 8 },
                    { 393, "19698", null, null, false, "SANTANDER DE QUILICHAO", 8 },
                    { 394, "19701", null, null, false, "SANTA ROSA", 8 },
                    { 395, "19743", null, null, false, "SILVIA", 8 },
                    { 396, "19760", null, null, false, "SOTARÁ - PAISPAMBA", 8 },
                    { 397, "19780", null, null, false, "SUÁREZ", 8 },
                    { 398, "19785", null, null, false, "SUCRE", 8 },
                    { 399, "19807", null, null, false, "TIMBÍO", 8 },
                    { 400, "19809", null, null, false, "TIMBIQUÍ", 8 },
                    { 401, "19821", null, null, false, "TORIBÍO", 8 },
                    { 402, "19824", null, null, false, "TOTORÓ", 8 },
                    { 403, "19845", null, null, false, "VILLA RICA", 8 },
                    { 404, "20001", null, null, false, "VALLEDUPAR", 9 },
                    { 405, "20011", null, null, false, "AGUACHICA", 9 },
                    { 406, "20013", null, null, false, "AGUSTÍN CODAZZI", 9 },
                    { 407, "20032", null, null, false, "ASTREA", 9 },
                    { 408, "20045", null, null, false, "BECERRIL", 9 },
                    { 409, "20060", null, null, false, "BOSCONIA", 9 },
                    { 410, "20175", null, null, false, "CHIMICHAGUA", 9 },
                    { 411, "20178", null, null, false, "CHIRIGUANÁ", 9 },
                    { 412, "20228", null, null, false, "CURUMANÍ", 9 },
                    { 413, "20238", null, null, false, "EL COPEY", 9 },
                    { 414, "20250", null, null, false, "EL PASO", 9 },
                    { 415, "20295", null, null, false, "GAMARRA", 9 },
                    { 416, "20310", null, null, false, "GONZÁLEZ", 9 },
                    { 417, "20383", null, null, false, "LA GLORIA", 9 },
                    { 418, "20400", null, null, false, "LA JAGUA DE IBIRICO", 9 },
                    { 419, "20443", null, null, false, "MANAURE BALCÓN DEL CESAR", 9 },
                    { 420, "20517", null, null, false, "PAILITAS", 9 },
                    { 421, "20550", null, null, false, "PELAYA", 9 },
                    { 422, "20570", null, null, false, "PUEBLO BELLO", 9 },
                    { 423, "20614", null, null, false, "RÍO DE ORO", 9 },
                    { 424, "20621", null, null, false, "LA PAZ", 9 },
                    { 425, "20710", null, null, false, "SAN ALBERTO", 9 },
                    { 426, "20750", null, null, false, "SAN DIEGO", 9 },
                    { 427, "20770", null, null, false, "SAN MARTÍN", 9 },
                    { 428, "20787", null, null, false, "TAMALAMEQUE", 9 },
                    { 429, "23001", null, null, false, "MONTERÍA", 10 },
                    { 430, "23068", null, null, false, "AYAPEL", 10 },
                    { 431, "23079", null, null, false, "BUENAVISTA", 10 },
                    { 432, "23090", null, null, false, "CANALETE", 10 },
                    { 433, "23162", null, null, false, "CERETÉ", 10 },
                    { 434, "23168", null, null, false, "CHIMÁ", 10 },
                    { 435, "23182", null, null, false, "CHINÚ", 10 },
                    { 436, "23189", null, null, false, "CIÉNAGA DE ORO", 10 },
                    { 437, "23300", null, null, false, "COTORRA", 10 },
                    { 438, "23350", null, null, false, "LA APARTADA", 10 },
                    { 439, "23417", null, null, false, "LORICA", 10 },
                    { 440, "23419", null, null, false, "LOS CÓRDOBAS", 10 },
                    { 441, "23464", null, null, false, "MOMIL", 10 },
                    { 442, "23466", null, null, false, "MONTELÍBANO", 10 },
                    { 443, "23500", null, null, false, "MOÑITOS", 10 },
                    { 444, "23555", null, null, false, "PLANETA RICA", 10 },
                    { 445, "23570", null, null, false, "PUEBLO NUEVO", 10 },
                    { 446, "23574", null, null, false, "PUERTO ESCONDIDO", 10 },
                    { 447, "23580", null, null, false, "PUERTO LIBERTADOR", 10 },
                    { 448, "23586", null, null, false, "PURÍSIMA DE LA CONCEPCIÓN", 10 },
                    { 449, "23660", null, null, false, "SAHAGÚN", 10 },
                    { 450, "23670", null, null, false, "SAN ANDRÉS DE SOTAVENTO", 10 },
                    { 451, "23672", null, null, false, "SAN ANTERO", 10 },
                    { 452, "23675", null, null, false, "SAN BERNARDO DEL VIENTO", 10 },
                    { 453, "23678", null, null, false, "SAN CARLOS", 10 },
                    { 454, "23682", null, null, false, "SAN JOSÉ DE URÉ", 10 },
                    { 455, "23686", null, null, false, "SAN PELAYO", 10 },
                    { 456, "23807", null, null, false, "TIERRALTA", 10 },
                    { 457, "23815", null, null, false, "TUCHÍN", 10 },
                    { 458, "23855", null, null, false, "VALENCIA", 10 },
                    { 459, "25001", null, null, false, "AGUA DE DIOS", 11 },
                    { 460, "25019", null, null, false, "ALBÁN", 11 },
                    { 461, "25035", null, null, false, "ANAPOIMA", 11 },
                    { 462, "25040", null, null, false, "ANOLAIMA", 11 },
                    { 463, "25053", null, null, false, "ARBELÁEZ", 11 },
                    { 464, "25086", null, null, false, "BELTRÁN", 11 },
                    { 465, "25095", null, null, false, "BITUIMA", 11 },
                    { 466, "25099", null, null, false, "BOJACÁ", 11 },
                    { 467, "25120", null, null, false, "CABRERA", 11 },
                    { 468, "25123", null, null, false, "CACHIPAY", 11 },
                    { 469, "25126", null, null, false, "CAJICÁ", 11 },
                    { 470, "25148", null, null, false, "CAPARRAPÍ", 11 },
                    { 471, "25151", null, null, false, "CÁQUEZA", 11 },
                    { 472, "25154", null, null, false, "CARMEN DE CARUPA", 11 },
                    { 473, "25168", null, null, false, "CHAGUANÍ", 11 },
                    { 474, "25175", null, null, false, "CHÍA", 11 },
                    { 475, "25178", null, null, false, "CHIPAQUE", 11 },
                    { 476, "25181", null, null, false, "CHOACHÍ", 11 },
                    { 477, "25183", null, null, false, "CHOCONTÁ", 11 },
                    { 478, "25200", null, null, false, "COGUA", 11 },
                    { 479, "25214", null, null, false, "COTA", 11 },
                    { 480, "25224", null, null, false, "CUCUNUBÁ", 11 },
                    { 481, "25245", null, null, false, "EL COLEGIO", 11 },
                    { 482, "25258", null, null, false, "EL PEÑÓN", 11 },
                    { 483, "25260", null, null, false, "EL ROSAL", 11 },
                    { 484, "25269", null, null, false, "FACATATIVÁ", 11 },
                    { 485, "25279", null, null, false, "FÓMEQUE", 11 },
                    { 486, "25281", null, null, false, "FOSCA", 11 },
                    { 487, "25286", null, null, false, "FUNZA", 11 },
                    { 488, "25288", null, null, false, "FÚQUENE", 11 },
                    { 489, "25290", null, null, false, "FUSAGASUGÁ", 11 },
                    { 490, "25293", null, null, false, "GACHALÁ", 11 },
                    { 491, "25295", null, null, false, "GACHANCIPÁ", 11 },
                    { 492, "25297", null, null, false, "GACHETÁ", 11 },
                    { 493, "25299", null, null, false, "GAMA", 11 },
                    { 494, "25307", null, null, false, "GIRARDOT", 11 },
                    { 495, "25312", null, null, false, "GRANADA", 11 },
                    { 496, "25317", null, null, false, "GUACHETÁ", 11 },
                    { 497, "25320", null, null, false, "GUADUAS", 11 },
                    { 498, "25322", null, null, false, "GUASCA", 11 },
                    { 499, "25324", null, null, false, "GUATAQUÍ", 11 },
                    { 500, "25326", null, null, false, "GUATAVITA", 11 },
                    { 501, "25328", null, null, false, "GUAYABAL DE SÍQUIMA", 11 },
                    { 502, "25335", null, null, false, "GUAYABETAL", 11 },
                    { 503, "25339", null, null, false, "GUTIÉRREZ", 11 },
                    { 504, "25368", null, null, false, "JERUSALÉN", 11 },
                    { 505, "25372", null, null, false, "JUNÍN", 11 },
                    { 506, "25377", null, null, false, "LA CALERA", 11 },
                    { 507, "25386", null, null, false, "LA MESA", 11 },
                    { 508, "25394", null, null, false, "LA PALMA", 11 },
                    { 509, "25398", null, null, false, "LA PEÑA", 11 },
                    { 510, "25402", null, null, false, "LA VEGA", 11 },
                    { 511, "25407", null, null, false, "LENGUAZAQUE", 11 },
                    { 512, "25426", null, null, false, "MACHETÁ", 11 },
                    { 513, "25430", null, null, false, "MADRID", 11 },
                    { 514, "25436", null, null, false, "MANTA", 11 },
                    { 515, "25438", null, null, false, "MEDINA", 11 },
                    { 516, "25473", null, null, false, "MOSQUERA", 11 },
                    { 517, "25483", null, null, false, "NARIÑO", 11 },
                    { 518, "25486", null, null, false, "NEMOCÓN", 11 },
                    { 519, "25488", null, null, false, "NILO", 11 },
                    { 520, "25489", null, null, false, "NIMAIMA", 11 },
                    { 521, "25491", null, null, false, "NOCAIMA", 11 },
                    { 522, "25506", null, null, false, "VENECIA", 11 },
                    { 523, "25513", null, null, false, "PACHO", 11 },
                    { 524, "25518", null, null, false, "PAIME", 11 },
                    { 525, "25524", null, null, false, "PANDI", 11 },
                    { 526, "25530", null, null, false, "PARATEBUENO", 11 },
                    { 527, "25535", null, null, false, "PASCA", 11 },
                    { 528, "25572", null, null, false, "PUERTO SALGAR", 11 },
                    { 529, "25580", null, null, false, "PULÍ", 11 },
                    { 530, "25592", null, null, false, "QUEBRADANEGRA", 11 },
                    { 531, "25594", null, null, false, "QUETAME", 11 },
                    { 532, "25596", null, null, false, "QUIPILE", 11 },
                    { 533, "25599", null, null, false, "APULO", 11 },
                    { 534, "25612", null, null, false, "RICAURTE", 11 },
                    { 535, "25645", null, null, false, "SAN ANTONIO DEL TEQUENDAMA", 11 },
                    { 536, "25649", null, null, false, "SAN BERNARDO", 11 },
                    { 537, "25653", null, null, false, "SAN CAYETANO", 11 },
                    { 538, "25658", null, null, false, "SAN FRANCISCO", 11 },
                    { 539, "25662", null, null, false, "SAN JUAN DE RIOSECO", 11 },
                    { 540, "25718", null, null, false, "SASAIMA", 11 },
                    { 541, "25736", null, null, false, "SESQUILÉ", 11 },
                    { 542, "25740", null, null, false, "SIBATÉ", 11 },
                    { 543, "25743", null, null, false, "SILVANIA", 11 },
                    { 544, "25745", null, null, false, "SIMIJACA", 11 },
                    { 545, "25754", null, null, false, "SOACHA", 11 },
                    { 546, "25758", null, null, false, "SOPÓ", 11 },
                    { 547, "25769", null, null, false, "SUBACHOQUE", 11 },
                    { 548, "25772", null, null, false, "SUESCA", 11 },
                    { 549, "25777", null, null, false, "SUPATÁ", 11 },
                    { 550, "25779", null, null, false, "SUSA", 11 },
                    { 551, "25781", null, null, false, "SUTATAUSA", 11 },
                    { 552, "25785", null, null, false, "TABIO", 11 },
                    { 553, "25793", null, null, false, "TAUSA", 11 },
                    { 554, "25797", null, null, false, "TENA", 11 },
                    { 555, "25799", null, null, false, "TENJO", 11 },
                    { 556, "25805", null, null, false, "TIBACUY", 11 },
                    { 557, "25807", null, null, false, "TIBIRITA", 11 },
                    { 558, "25815", null, null, false, "TOCAIMA", 11 },
                    { 559, "25817", null, null, false, "TOCANCIPÁ", 11 },
                    { 560, "25823", null, null, false, "TOPAIPÍ", 11 },
                    { 561, "25839", null, null, false, "UBALÁ", 11 },
                    { 562, "25841", null, null, false, "UBAQUE", 11 },
                    { 563, "25843", null, null, false, "VILLA DE SAN DIEGO DE UBATÉ", 11 },
                    { 564, "25845", null, null, false, "UNE", 11 },
                    { 565, "25851", null, null, false, "ÚTICA", 11 },
                    { 566, "25862", null, null, false, "VERGARA", 11 },
                    { 567, "25867", null, null, false, "VIANÍ", 11 },
                    { 568, "25871", null, null, false, "VILLAGÓMEZ", 11 },
                    { 569, "25873", null, null, false, "VILLAPINZÓN", 11 },
                    { 570, "25875", null, null, false, "VILLETA", 11 },
                    { 571, "25878", null, null, false, "VIOTÁ", 11 },
                    { 572, "25885", null, null, false, "YACOPÍ", 11 },
                    { 573, "25898", null, null, false, "ZIPACÓN", 11 },
                    { 574, "25899", null, null, false, "ZIPAQUIRÁ", 11 },
                    { 575, "27001", null, null, false, "QUIBDÓ", 12 },
                    { 576, "27006", null, null, false, "ACANDÍ", 12 },
                    { 577, "27025", null, null, false, "ALTO BAUDÓ", 12 },
                    { 578, "27050", null, null, false, "ATRATO", 12 },
                    { 579, "27073", null, null, false, "BAGADÓ", 12 },
                    { 580, "27075", null, null, false, "BAHÍA SOLANO", 12 },
                    { 581, "27077", null, null, false, "BAJO BAUDÓ", 12 },
                    { 582, "27099", null, null, false, "BOJAYÁ", 12 },
                    { 583, "27135", null, null, false, "EL CANTÓN DEL SAN PABLO", 12 },
                    { 584, "27150", null, null, false, "CARMEN DEL DARIÉN", 12 },
                    { 585, "27160", null, null, false, "CÉRTEGUI", 12 },
                    { 586, "27205", null, null, false, "CONDOTO", 12 },
                    { 587, "27245", null, null, false, "EL CARMEN DE ATRATO", 12 },
                    { 588, "27250", null, null, false, "EL LITORAL DEL SAN JUAN", 12 },
                    { 589, "27361", null, null, false, "ISTMINA", 12 },
                    { 590, "27372", null, null, false, "JURADÓ", 12 },
                    { 591, "27413", null, null, false, "LLORÓ", 12 },
                    { 592, "27425", null, null, false, "MEDIO ATRATO", 12 },
                    { 593, "27430", null, null, false, "MEDIO BAUDÓ", 12 },
                    { 594, "27450", null, null, false, "MEDIO SAN JUAN", 12 },
                    { 595, "27491", null, null, false, "NÓVITA", 12 },
                    { 596, "27493", null, null, false, "NUEVO BELÉN DE BAJIRÁ", 12 },
                    { 597, "27495", null, null, false, "NUQUÍ", 12 },
                    { 598, "27580", null, null, false, "RÍO IRÓ", 12 },
                    { 599, "27600", null, null, false, "RÍO QUITO", 12 },
                    { 600, "27615", null, null, false, "RIOSUCIO", 12 },
                    { 601, "27660", null, null, false, "SAN JOSÉ DEL PALMAR", 12 },
                    { 602, "27745", null, null, false, "SIPÍ", 12 },
                    { 603, "27787", null, null, false, "TADÓ", 12 },
                    { 604, "27800", null, null, false, "UNGUÍA", 12 },
                    { 605, "27810", null, null, false, "UNIÓN PANAMERICANA", 12 },
                    { 606, "41001", null, null, false, "NEIVA", 13 },
                    { 607, "41006", null, null, false, "ACEVEDO", 13 },
                    { 608, "41013", null, null, false, "AGRADO", 13 },
                    { 609, "41016", null, null, false, "AIPE", 13 },
                    { 610, "41020", null, null, false, "ALGECIRAS", 13 },
                    { 611, "41026", null, null, false, "ALTAMIRA", 13 },
                    { 612, "41078", null, null, false, "BARAYA", 13 },
                    { 613, "41132", null, null, false, "CAMPOALEGRE", 13 },
                    { 614, "41206", null, null, false, "COLOMBIA", 13 },
                    { 615, "41244", null, null, false, "ELÍAS", 13 },
                    { 616, "41298", null, null, false, "GARZÓN", 13 },
                    { 617, "41306", null, null, false, "GIGANTE", 13 },
                    { 618, "41319", null, null, false, "GUADALUPE", 13 },
                    { 619, "41349", null, null, false, "HOBO", 13 },
                    { 620, "41357", null, null, false, "ÍQUIRA", 13 },
                    { 621, "41359", null, null, false, "ISNOS", 13 },
                    { 622, "41378", null, null, false, "LA ARGENTINA", 13 },
                    { 623, "41396", null, null, false, "LA PLATA", 13 },
                    { 624, "41483", null, null, false, "NÁTAGA", 13 },
                    { 625, "41503", null, null, false, "OPORAPA", 13 },
                    { 626, "41518", null, null, false, "PAICOL", 13 },
                    { 627, "41524", null, null, false, "PALERMO", 13 },
                    { 628, "41530", null, null, false, "PALESTINA", 13 },
                    { 629, "41548", null, null, false, "PITAL", 13 },
                    { 630, "41551", null, null, false, "PITALITO", 13 },
                    { 631, "41615", null, null, false, "RIVERA", 13 },
                    { 632, "41660", null, null, false, "SALADOBLANCO", 13 },
                    { 633, "41668", null, null, false, "SAN AGUSTÍN", 13 },
                    { 634, "41676", null, null, false, "SANTA MARÍA", 13 },
                    { 635, "41770", null, null, false, "SUAZA", 13 },
                    { 636, "41791", null, null, false, "TARQUI", 13 },
                    { 637, "41797", null, null, false, "TESALIA", 13 },
                    { 638, "41799", null, null, false, "TELLO", 13 },
                    { 639, "41801", null, null, false, "TERUEL", 13 },
                    { 640, "41807", null, null, false, "TIMANÁ", 13 },
                    { 641, "41872", null, null, false, "VILLAVIEJA", 13 },
                    { 642, "41885", null, null, false, "YAGUARÁ", 13 },
                    { 643, "44001", null, null, false, "RIOHACHA", 14 },
                    { 644, "44035", null, null, false, "ALBANIA", 14 },
                    { 645, "44078", null, null, false, "BARRANCAS", 14 },
                    { 646, "44090", null, null, false, "DIBULLA", 14 },
                    { 647, "44098", null, null, false, "DISTRACCIÓN", 14 },
                    { 648, "44110", null, null, false, "EL MOLINO", 14 },
                    { 649, "44279", null, null, false, "FONSECA", 14 },
                    { 650, "44378", null, null, false, "HATONUEVO", 14 },
                    { 651, "44420", null, null, false, "LA JAGUA DEL PILAR", 14 },
                    { 652, "44430", null, null, false, "MAICAO", 14 },
                    { 653, "44560", null, null, false, "MANAURE", 14 },
                    { 654, "44650", null, null, false, "SAN JUAN DEL CESAR", 14 },
                    { 655, "44847", null, null, false, "URIBIA", 14 },
                    { 656, "44855", null, null, false, "URUMITA", 14 },
                    { 657, "44874", null, null, false, "VILLANUEVA", 14 },
                    { 658, "47001", null, null, false, "SANTA MARTA", 15 },
                    { 659, "47030", null, null, false, "ALGARROBO", 15 },
                    { 660, "47053", null, null, false, "ARACATACA", 15 },
                    { 661, "47058", null, null, false, "ARIGUANÍ", 15 },
                    { 662, "47161", null, null, false, "CERRO DE SAN ANTONIO", 15 },
                    { 663, "47170", null, null, false, "CHIVOLO", 15 },
                    { 664, "47189", null, null, false, "CIÉNAGA", 15 },
                    { 665, "47205", null, null, false, "CONCORDIA", 15 },
                    { 666, "47245", null, null, false, "EL BANCO", 15 },
                    { 667, "47258", null, null, false, "EL PIÑÓN", 15 },
                    { 668, "47268", null, null, false, "EL RETÉN", 15 },
                    { 669, "47288", null, null, false, "FUNDACIÓN", 15 },
                    { 670, "47318", null, null, false, "GUAMAL", 15 },
                    { 671, "47460", null, null, false, "NUEVA GRANADA", 15 },
                    { 672, "47541", null, null, false, "PEDRAZA", 15 },
                    { 673, "47545", null, null, false, "PIJIÑO DEL CARMEN", 15 },
                    { 674, "47551", null, null, false, "PIVIJAY", 15 },
                    { 675, "47555", null, null, false, "PLATO", 15 },
                    { 676, "47570", null, null, false, "PUEBLOVIEJO", 15 },
                    { 677, "47605", null, null, false, "REMOLINO", 15 },
                    { 678, "47660", null, null, false, "SABANAS DE SAN ÁNGEL", 15 },
                    { 679, "47675", null, null, false, "SALAMINA", 15 },
                    { 680, "47692", null, null, false, "SAN SEBASTIÁN DE BUENAVISTA", 15 },
                    { 681, "47703", null, null, false, "SAN ZENÓN", 15 },
                    { 682, "47707", null, null, false, "SANTA ANA", 15 },
                    { 683, "47720", null, null, false, "SANTA BÁRBARA DE PINTO", 15 },
                    { 684, "47745", null, null, false, "SITIONUEVO", 15 },
                    { 685, "47798", null, null, false, "TENERIFE", 15 },
                    { 686, "47960", null, null, false, "ZAPAYÁN", 15 },
                    { 687, "47980", null, null, false, "ZONA BANANERA", 15 },
                    { 688, "50001", null, null, false, "VILLAVICENCIO", 16 },
                    { 689, "50006", null, null, false, "ACACÍAS", 16 },
                    { 690, "50110", null, null, false, "BARRANCA DE UPÍA", 16 },
                    { 691, "50124", null, null, false, "CABUYARO", 16 },
                    { 692, "50150", null, null, false, "CASTILLA LA NUEVA", 16 },
                    { 693, "50223", null, null, false, "CUBARRAL", 16 },
                    { 694, "50226", null, null, false, "CUMARAL", 16 },
                    { 695, "50245", null, null, false, "EL CALVARIO", 16 },
                    { 696, "50251", null, null, false, "EL CASTILLO", 16 },
                    { 697, "50270", null, null, false, "EL DORADO", 16 },
                    { 698, "50287", null, null, false, "FUENTE DE ORO", 16 },
                    { 699, "50313", null, null, false, "GRANADA", 16 },
                    { 700, "50318", null, null, false, "GUAMAL", 16 },
                    { 701, "50325", null, null, false, "MAPIRIPÁN", 16 },
                    { 702, "50330", null, null, false, "MESETAS", 16 },
                    { 703, "50350", null, null, false, "LA MACARENA", 16 },
                    { 704, "50370", null, null, false, "URIBE", 16 },
                    { 705, "50400", null, null, false, "LEJANÍAS", 16 },
                    { 706, "50450", null, null, false, "PUERTO CONCORDIA", 16 },
                    { 707, "50568", null, null, false, "PUERTO GAITÁN", 16 },
                    { 708, "50573", null, null, false, "PUERTO LÓPEZ", 16 },
                    { 709, "50577", null, null, false, "PUERTO LLERAS", 16 },
                    { 710, "50590", null, null, false, "PUERTO RICO", 16 },
                    { 711, "50606", null, null, false, "RESTREPO", 16 },
                    { 712, "50680", null, null, false, "SAN CARLOS DE GUAROA", 16 },
                    { 713, "50683", null, null, false, "SAN JUAN DE ARAMA", 16 },
                    { 714, "50686", null, null, false, "SAN JUANITO", 16 },
                    { 715, "50689", null, null, false, "SAN MARTÍN", 16 },
                    { 716, "50711", null, null, false, "VISTAHERMOSA", 16 },
                    { 717, "52001", null, null, false, "PASTO", 17 },
                    { 718, "52019", null, null, false, "ALBÁN", 17 },
                    { 719, "52022", null, null, false, "ALDANA", 17 },
                    { 720, "52036", null, null, false, "ANCUYA", 17 },
                    { 721, "52051", null, null, false, "ARBOLEDA", 17 },
                    { 722, "52079", null, null, false, "BARBACOAS", 17 },
                    { 723, "52083", null, null, false, "BELÉN", 17 },
                    { 724, "52110", null, null, false, "BUESACO", 17 },
                    { 725, "52203", null, null, false, "COLÓN", 17 },
                    { 726, "52207", null, null, false, "CONSACÁ", 17 },
                    { 727, "52210", null, null, false, "CONTADERO", 17 },
                    { 728, "52215", null, null, false, "CÓRDOBA", 17 },
                    { 729, "52224", null, null, false, "CUASPUD CARLOSAMA", 17 },
                    { 730, "52227", null, null, false, "CUMBAL", 17 },
                    { 731, "52233", null, null, false, "CUMBITARA", 17 },
                    { 732, "52240", null, null, false, "CHACHAGÜÍ", 17 },
                    { 733, "52250", null, null, false, "EL CHARCO", 17 },
                    { 734, "52254", null, null, false, "EL PEÑOL", 17 },
                    { 735, "52256", null, null, false, "EL ROSARIO", 17 },
                    { 736, "52258", null, null, false, "EL TABLÓN DE GÓMEZ", 17 },
                    { 737, "52260", null, null, false, "EL TAMBO", 17 },
                    { 738, "52287", null, null, false, "FUNES", 17 },
                    { 739, "52317", null, null, false, "GUACHUCAL", 17 },
                    { 740, "52320", null, null, false, "GUAITARILLA", 17 },
                    { 741, "52323", null, null, false, "GUALMATÁN", 17 },
                    { 742, "52352", null, null, false, "ILES", 17 },
                    { 743, "52354", null, null, false, "IMUÉS", 17 },
                    { 744, "52356", null, null, false, "IPIALES", 17 },
                    { 745, "52378", null, null, false, "LA CRUZ", 17 },
                    { 746, "52381", null, null, false, "LA FLORIDA", 17 },
                    { 747, "52385", null, null, false, "LA LLANADA", 17 },
                    { 748, "52390", null, null, false, "LA TOLA", 17 },
                    { 749, "52399", null, null, false, "LA UNIÓN", 17 },
                    { 750, "52405", null, null, false, "LEIVA", 17 },
                    { 751, "52411", null, null, false, "LINARES", 17 },
                    { 752, "52418", null, null, false, "LOS ANDES", 17 },
                    { 753, "52427", null, null, false, "MAGÜÍ", 17 },
                    { 754, "52435", null, null, false, "MALLAMA", 17 },
                    { 755, "52473", null, null, false, "MOSQUERA", 17 },
                    { 756, "52480", null, null, false, "NARIÑO", 17 },
                    { 757, "52490", null, null, false, "OLAYA HERRERA", 17 },
                    { 758, "52506", null, null, false, "OSPINA", 17 },
                    { 759, "52520", null, null, false, "FRANCISCO PIZARRO", 17 },
                    { 760, "52540", null, null, false, "POLICARPA", 17 },
                    { 761, "52560", null, null, false, "POTOSÍ", 17 },
                    { 762, "52565", null, null, false, "PROVIDENCIA", 17 },
                    { 763, "52573", null, null, false, "PUERRES", 17 },
                    { 764, "52585", null, null, false, "PUPIALES", 17 },
                    { 765, "52612", null, null, false, "RICAURTE", 17 },
                    { 766, "52621", null, null, false, "ROBERTO PAYÁN", 17 },
                    { 767, "52678", null, null, false, "SAMANIEGO", 17 },
                    { 768, "52683", null, null, false, "SANDONÁ", 17 },
                    { 769, "52685", null, null, false, "SAN BERNARDO", 17 },
                    { 770, "52687", null, null, false, "SAN LORENZO", 17 },
                    { 771, "52693", null, null, false, "SAN PABLO", 17 },
                    { 772, "52694", null, null, false, "SAN PEDRO DE CARTAGO", 17 },
                    { 773, "52696", null, null, false, "SANTA BÁRBARA", 17 },
                    { 774, "52699", null, null, false, "SANTACRUZ", 17 },
                    { 775, "52720", null, null, false, "SAPUYES", 17 },
                    { 776, "52786", null, null, false, "TAMINANGO", 17 },
                    { 777, "52788", null, null, false, "TANGUA", 17 },
                    { 778, "52835", null, null, false, "SAN ANDRÉS DE TUMACO", 17 },
                    { 779, "52838", null, null, false, "TÚQUERRES", 17 },
                    { 780, "52885", null, null, false, "YACUANQUER", 17 },
                    { 781, "54001", null, null, false, "SAN JOSÉ DE CÚCUTA", 18 },
                    { 782, "54003", null, null, false, "ÁBREGO", 18 },
                    { 783, "54051", null, null, false, "ARBOLEDAS", 18 },
                    { 784, "54099", null, null, false, "BOCHALEMA", 18 },
                    { 785, "54109", null, null, false, "BUCARASICA", 18 },
                    { 786, "54125", null, null, false, "CÁCOTA", 18 },
                    { 787, "54128", null, null, false, "CÁCHIRA", 18 },
                    { 788, "54172", null, null, false, "CHINÁCOTA", 18 },
                    { 789, "54174", null, null, false, "CHITAGÁ", 18 },
                    { 790, "54206", null, null, false, "CONVENCIÓN", 18 },
                    { 791, "54223", null, null, false, "CUCUTILLA", 18 },
                    { 792, "54239", null, null, false, "DURANIA", 18 },
                    { 793, "54245", null, null, false, "EL CARMEN", 18 },
                    { 794, "54250", null, null, false, "EL TARRA", 18 },
                    { 795, "54261", null, null, false, "EL ZULIA", 18 },
                    { 796, "54313", null, null, false, "GRAMALOTE", 18 },
                    { 797, "54344", null, null, false, "HACARÍ", 18 },
                    { 798, "54347", null, null, false, "HERRÁN", 18 },
                    { 799, "54377", null, null, false, "LABATECA", 18 },
                    { 800, "54385", null, null, false, "LA ESPERANZA", 18 },
                    { 801, "54398", null, null, false, "LA PLAYA", 18 },
                    { 802, "54405", null, null, false, "LOS PATIOS", 18 },
                    { 803, "54418", null, null, false, "LOURDES", 18 },
                    { 804, "54480", null, null, false, "MUTISCUA", 18 },
                    { 805, "54498", null, null, false, "OCAÑA", 18 },
                    { 806, "54518", null, null, false, "PAMPLONA", 18 },
                    { 807, "54520", null, null, false, "PAMPLONITA", 18 },
                    { 808, "54553", null, null, false, "PUERTO SANTANDER", 18 },
                    { 809, "54599", null, null, false, "RAGONVALIA", 18 },
                    { 810, "54660", null, null, false, "SALAZAR", 18 },
                    { 811, "54670", null, null, false, "SAN CALIXTO", 18 },
                    { 812, "54673", null, null, false, "SAN CAYETANO", 18 },
                    { 813, "54680", null, null, false, "SANTIAGO", 18 },
                    { 814, "54720", null, null, false, "SARDINATA", 18 },
                    { 815, "54743", null, null, false, "SILOS", 18 },
                    { 816, "54800", null, null, false, "TEORAMA", 18 },
                    { 817, "54810", null, null, false, "TIBÚ", 18 },
                    { 818, "54820", null, null, false, "TOLEDO", 18 },
                    { 819, "54871", null, null, false, "VILLA CARO", 18 },
                    { 820, "54874", null, null, false, "VILLA DEL ROSARIO", 18 },
                    { 821, "63001", null, null, false, "ARMENIA", 19 },
                    { 822, "63111", null, null, false, "BUENAVISTA", 19 },
                    { 823, "63130", null, null, false, "CALARCÁ", 19 },
                    { 824, "63190", null, null, false, "CIRCASIA", 19 },
                    { 825, "63212", null, null, false, "CÓRDOBA", 19 },
                    { 826, "63272", null, null, false, "FILANDIA", 19 },
                    { 827, "63302", null, null, false, "GÉNOVA", 19 },
                    { 828, "63401", null, null, false, "LA TEBAIDA", 19 },
                    { 829, "63470", null, null, false, "MONTENEGRO", 19 },
                    { 830, "63548", null, null, false, "PIJAO", 19 },
                    { 831, "63594", null, null, false, "QUIMBAYA", 19 },
                    { 832, "63690", null, null, false, "SALENTO", 19 },
                    { 833, "66001", null, null, false, "PEREIRA", 20 },
                    { 834, "66045", null, null, false, "APÍA", 20 },
                    { 835, "66075", null, null, false, "BALBOA", 20 },
                    { 836, "66088", null, null, false, "BELÉN DE UMBRÍA", 20 },
                    { 837, "66170", null, null, false, "DOSQUEBRADAS", 20 },
                    { 838, "66318", null, null, false, "GUÁTICA", 20 },
                    { 839, "66383", null, null, false, "LA CELIA", 20 },
                    { 840, "66400", null, null, false, "LA VIRGINIA", 20 },
                    { 841, "66440", null, null, false, "MARSELLA", 20 },
                    { 842, "66456", null, null, false, "MISTRATÓ", 20 },
                    { 843, "66572", null, null, false, "PUEBLO RICO", 20 },
                    { 844, "66594", null, null, false, "QUINCHÍA", 20 },
                    { 845, "66682", null, null, false, "SANTA ROSA DE CABAL", 20 },
                    { 846, "66687", null, null, false, "SANTUARIO", 20 },
                    { 847, "68001", null, null, false, "BUCARAMANGA", 21 },
                    { 848, "68013", null, null, false, "AGUADA", 21 },
                    { 849, "68020", null, null, false, "ALBANIA", 21 },
                    { 850, "68051", null, null, false, "ARATOCA", 21 },
                    { 851, "68077", null, null, false, "BARBOSA", 21 },
                    { 852, "68079", null, null, false, "BARICHARA", 21 },
                    { 853, "68081", null, null, false, "BARRANCABERMEJA", 21 },
                    { 854, "68092", null, null, false, "BETULIA", 21 },
                    { 855, "68101", null, null, false, "BOLÍVAR", 21 },
                    { 856, "68121", null, null, false, "CABRERA", 21 },
                    { 857, "68132", null, null, false, "CALIFORNIA", 21 },
                    { 858, "68147", null, null, false, "CAPITANEJO", 21 },
                    { 859, "68152", null, null, false, "CARCASÍ", 21 },
                    { 860, "68160", null, null, false, "CEPITÁ", 21 },
                    { 861, "68162", null, null, false, "CERRITO", 21 },
                    { 862, "68167", null, null, false, "CHARALÁ", 21 },
                    { 863, "68169", null, null, false, "CHARTA", 21 },
                    { 864, "68176", null, null, false, "CHIMA", 21 },
                    { 865, "68179", null, null, false, "CHIPATÁ", 21 },
                    { 866, "68190", null, null, false, "CIMITARRA", 21 },
                    { 867, "68207", null, null, false, "CONCEPCIÓN", 21 },
                    { 868, "68209", null, null, false, "CONFINES", 21 },
                    { 869, "68211", null, null, false, "CONTRATACIÓN", 21 },
                    { 870, "68217", null, null, false, "COROMORO", 21 },
                    { 871, "68229", null, null, false, "CURITÍ", 21 },
                    { 872, "68235", null, null, false, "EL CARMEN DE CHUCURÍ", 21 },
                    { 873, "68245", null, null, false, "EL GUACAMAYO", 21 },
                    { 874, "68250", null, null, false, "EL PEÑÓN", 21 },
                    { 875, "68255", null, null, false, "EL PLAYÓN", 21 },
                    { 876, "68264", null, null, false, "ENCINO", 21 },
                    { 877, "68266", null, null, false, "ENCISO", 21 },
                    { 878, "68271", null, null, false, "FLORIÁN", 21 },
                    { 879, "68276", null, null, false, "FLORIDABLANCA", 21 },
                    { 880, "68296", null, null, false, "GALÁN", 21 },
                    { 881, "68298", null, null, false, "GÁMBITA", 21 },
                    { 882, "68307", null, null, false, "GIRÓN", 21 },
                    { 883, "68318", null, null, false, "GUACA", 21 },
                    { 884, "68320", null, null, false, "GUADALUPE", 21 },
                    { 885, "68322", null, null, false, "GUAPOTÁ", 21 },
                    { 886, "68324", null, null, false, "GUAVATÁ", 21 },
                    { 887, "68327", null, null, false, "GÜEPSA", 21 },
                    { 888, "68344", null, null, false, "HATO", 21 },
                    { 889, "68368", null, null, false, "JESÚS MARÍA", 21 },
                    { 890, "68370", null, null, false, "JORDÁN", 21 },
                    { 891, "68377", null, null, false, "LA BELLEZA", 21 },
                    { 892, "68385", null, null, false, "LANDÁZURI", 21 },
                    { 893, "68397", null, null, false, "LA PAZ", 21 },
                    { 894, "68406", null, null, false, "LEBRIJA", 21 },
                    { 895, "68418", null, null, false, "LOS SANTOS", 21 },
                    { 896, "68425", null, null, false, "MACARAVITA", 21 },
                    { 897, "68432", null, null, false, "MÁLAGA", 21 },
                    { 898, "68444", null, null, false, "MATANZA", 21 },
                    { 899, "68464", null, null, false, "MOGOTES", 21 },
                    { 900, "68468", null, null, false, "MOLAGAVITA", 21 },
                    { 901, "68498", null, null, false, "OCAMONTE", 21 },
                    { 902, "68500", null, null, false, "OIBA", 21 },
                    { 903, "68502", null, null, false, "ONZAGA", 21 },
                    { 904, "68522", null, null, false, "PALMAR", 21 },
                    { 905, "68524", null, null, false, "PALMAS DEL SOCORRO", 21 },
                    { 906, "68533", null, null, false, "PÁRAMO", 21 },
                    { 907, "68547", null, null, false, "PIEDECUESTA", 21 },
                    { 908, "68549", null, null, false, "PINCHOTE", 21 },
                    { 909, "68572", null, null, false, "PUENTE NACIONAL", 21 },
                    { 910, "68573", null, null, false, "PUERTO PARRA", 21 },
                    { 911, "68575", null, null, false, "PUERTO WILCHES", 21 },
                    { 912, "68615", null, null, false, "RIONEGRO", 21 },
                    { 913, "68655", null, null, false, "SABANA DE TORRES", 21 },
                    { 914, "68669", null, null, false, "SAN ANDRÉS", 21 },
                    { 915, "68673", null, null, false, "SAN BENITO", 21 },
                    { 916, "68679", null, null, false, "SAN GIL", 21 },
                    { 917, "68682", null, null, false, "SAN JOAQUÍN", 21 },
                    { 918, "68684", null, null, false, "SAN JOSÉ DE MIRANDA", 21 },
                    { 919, "68686", null, null, false, "SAN MIGUEL", 21 },
                    { 920, "68689", null, null, false, "SAN VICENTE DE CHUCURÍ", 21 },
                    { 921, "68705", null, null, false, "SANTA BÁRBARA", 21 },
                    { 922, "68720", null, null, false, "SANTA HELENA DEL OPÓN", 21 },
                    { 923, "68745", null, null, false, "SIMACOTA", 21 },
                    { 924, "68755", null, null, false, "SOCORRO", 21 },
                    { 925, "68770", null, null, false, "SUAITA", 21 },
                    { 926, "68773", null, null, false, "SUCRE", 21 },
                    { 927, "68780", null, null, false, "SURATÁ", 21 },
                    { 928, "68820", null, null, false, "TONA", 21 },
                    { 929, "68855", null, null, false, "VALLE DE SAN JOSÉ", 21 },
                    { 930, "68861", null, null, false, "VÉLEZ", 21 },
                    { 931, "68867", null, null, false, "VETAS", 21 },
                    { 932, "68872", null, null, false, "VILLANUEVA", 21 },
                    { 933, "68895", null, null, false, "ZAPATOCA", 21 },
                    { 934, "70001", null, null, false, "SINCELEJO", 22 },
                    { 935, "70110", null, null, false, "BUENAVISTA", 22 },
                    { 936, "70124", null, null, false, "CAIMITO", 22 },
                    { 937, "70204", null, null, false, "COLOSÓ", 22 },
                    { 938, "70215", null, null, false, "COROZAL", 22 },
                    { 939, "70221", null, null, false, "COVEÑAS", 22 },
                    { 940, "70230", null, null, false, "CHALÁN", 22 },
                    { 941, "70233", null, null, false, "EL ROBLE", 22 },
                    { 942, "70235", null, null, false, "GALERAS", 22 },
                    { 943, "70265", null, null, false, "GUARANDA", 22 },
                    { 944, "70400", null, null, false, "LA UNIÓN", 22 },
                    { 945, "70418", null, null, false, "LOS PALMITOS", 22 },
                    { 946, "70429", null, null, false, "MAJAGUAL", 22 },
                    { 947, "70473", null, null, false, "MORROA", 22 },
                    { 948, "70508", null, null, false, "OVEJAS", 22 },
                    { 949, "70523", null, null, false, "PALMITO", 22 },
                    { 950, "70670", null, null, false, "SAMPUÉS", 22 },
                    { 951, "70678", null, null, false, "SAN BENITO ABAD", 22 },
                    { 952, "70702", null, null, false, "SAN JUAN DE BETULIA", 22 },
                    { 953, "70708", null, null, false, "SAN MARCOS", 22 },
                    { 954, "70713", null, null, false, "SAN ONOFRE", 22 },
                    { 955, "70717", null, null, false, "SAN PEDRO", 22 },
                    { 956, "70742", null, null, false, "SAN LUIS DE SINCÉ", 22 },
                    { 957, "70771", null, null, false, "SUCRE", 22 },
                    { 958, "70820", null, null, false, "SANTIAGO DE TOLÚ", 22 },
                    { 959, "70823", null, null, false, "SAN JOSÉ DE TOLUVIEJO", 22 },
                    { 960, "73001", null, null, false, "IBAGUÉ", 23 },
                    { 961, "73024", null, null, false, "ALPUJARRA", 23 },
                    { 962, "73026", null, null, false, "ALVARADO", 23 },
                    { 963, "73030", null, null, false, "AMBALEMA", 23 },
                    { 964, "73043", null, null, false, "ANZOÁTEGUI", 23 },
                    { 965, "73055", null, null, false, "ARMERO", 23 },
                    { 966, "73067", null, null, false, "ATACO", 23 },
                    { 967, "73124", null, null, false, "CAJAMARCA", 23 },
                    { 968, "73148", null, null, false, "CARMEN DE APICALÁ", 23 },
                    { 969, "73152", null, null, false, "CASABIANCA", 23 },
                    { 970, "73168", null, null, false, "CHAPARRAL", 23 },
                    { 971, "73200", null, null, false, "COELLO", 23 },
                    { 972, "73217", null, null, false, "COYAIMA", 23 },
                    { 973, "73226", null, null, false, "CUNDAY", 23 },
                    { 974, "73236", null, null, false, "DOLORES", 23 },
                    { 975, "73268", null, null, false, "ESPINAL", 23 },
                    { 976, "73270", null, null, false, "FALAN", 23 },
                    { 977, "73275", null, null, false, "FLANDES", 23 },
                    { 978, "73283", null, null, false, "FRESNO", 23 },
                    { 979, "73319", null, null, false, "GUAMO", 23 },
                    { 980, "73347", null, null, false, "HERVEO", 23 },
                    { 981, "73349", null, null, false, "HONDA", 23 },
                    { 982, "73352", null, null, false, "ICONONZO", 23 },
                    { 983, "73408", null, null, false, "LÉRIDA", 23 },
                    { 984, "73411", null, null, false, "LÍBANO", 23 },
                    { 985, "73443", null, null, false, "SAN SEBASTIÁN DE MARIQUITA", 23 },
                    { 986, "73449", null, null, false, "MELGAR", 23 },
                    { 987, "73461", null, null, false, "MURILLO", 23 },
                    { 988, "73483", null, null, false, "NATAGAIMA", 23 },
                    { 989, "73504", null, null, false, "ORTEGA", 23 },
                    { 990, "73520", null, null, false, "PALOCABILDO", 23 },
                    { 991, "73547", null, null, false, "PIEDRAS", 23 },
                    { 992, "73555", null, null, false, "PLANADAS", 23 },
                    { 993, "73563", null, null, false, "PRADO", 23 },
                    { 994, "73585", null, null, false, "PURIFICACIÓN", 23 },
                    { 995, "73616", null, null, false, "RIOBLANCO", 23 },
                    { 996, "73622", null, null, false, "RONCESVALLES", 23 },
                    { 997, "73624", null, null, false, "ROVIRA", 23 },
                    { 998, "73671", null, null, false, "SALDAÑA", 23 },
                    { 999, "73675", null, null, false, "SAN ANTONIO", 23 },
                    { 1000, "73678", null, null, false, "SAN LUIS", 23 },
                    { 1001, "73686", null, null, false, "SANTA ISABEL", 23 },
                    { 1002, "73770", null, null, false, "SUÁREZ", 23 },
                    { 1003, "73854", null, null, false, "VALLE DE SAN JUAN", 23 },
                    { 1004, "73861", null, null, false, "VENADILLO", 23 },
                    { 1005, "73870", null, null, false, "VILLAHERMOSA", 23 },
                    { 1006, "73873", null, null, false, "VILLARRICA", 23 },
                    { 1007, "76001", null, null, false, "SANTIAGO DE CALI", 24 },
                    { 1008, "76020", null, null, false, "ALCALÁ", 24 },
                    { 1009, "76036", null, null, false, "ANDALUCÍA", 24 },
                    { 1010, "76041", null, null, false, "ANSERMANUEVO", 24 },
                    { 1011, "76054", null, null, false, "ARGELIA", 24 },
                    { 1012, "76100", null, null, false, "BOLÍVAR", 24 },
                    { 1013, "76109", null, null, false, "BUENAVENTURA", 24 },
                    { 1014, "76111", null, null, false, "GUADALAJARA DE BUGA", 24 },
                    { 1015, "76113", null, null, false, "BUGALAGRANDE", 24 },
                    { 1016, "76122", null, null, false, "CAICEDONIA", 24 },
                    { 1017, "76126", null, null, false, "CALIMA", 24 },
                    { 1018, "76130", null, null, false, "CANDELARIA", 24 },
                    { 1019, "76147", null, null, false, "CARTAGO", 24 },
                    { 1020, "76233", null, null, false, "DAGUA", 24 },
                    { 1021, "76243", null, null, false, "EL ÁGUILA", 24 },
                    { 1022, "76246", null, null, false, "EL CAIRO", 24 },
                    { 1023, "76248", null, null, false, "EL CERRITO", 24 },
                    { 1024, "76250", null, null, false, "EL DOVIO", 24 },
                    { 1025, "76275", null, null, false, "FLORIDA", 24 },
                    { 1026, "76306", null, null, false, "GINEBRA", 24 },
                    { 1027, "76318", null, null, false, "GUACARÍ", 24 },
                    { 1028, "76364", null, null, false, "JAMUNDÍ", 24 },
                    { 1029, "76377", null, null, false, "LA CUMBRE", 24 },
                    { 1030, "76400", null, null, false, "LA UNIÓN", 24 },
                    { 1031, "76403", null, null, false, "LA VICTORIA", 24 },
                    { 1032, "76497", null, null, false, "OBANDO", 24 },
                    { 1033, "76520", null, null, false, "PALMIRA", 24 },
                    { 1034, "76563", null, null, false, "PRADERA", 24 },
                    { 1035, "76606", null, null, false, "RESTREPO", 24 },
                    { 1036, "76616", null, null, false, "RIOFRÍO", 24 },
                    { 1037, "76622", null, null, false, "ROLDANILLO", 24 },
                    { 1038, "76670", null, null, false, "SAN PEDRO", 24 },
                    { 1039, "76736", null, null, false, "SEVILLA", 24 },
                    { 1040, "76823", null, null, false, "TORO", 24 },
                    { 1041, "76828", null, null, false, "TRUJILLO", 24 },
                    { 1042, "76834", null, null, false, "TULUÁ", 24 },
                    { 1043, "76845", null, null, false, "ULLOA", 24 },
                    { 1044, "76863", null, null, false, "VERSALLES", 24 },
                    { 1045, "76869", null, null, false, "VIJES", 24 },
                    { 1046, "76890", null, null, false, "YOTOCO", 24 },
                    { 1047, "76892", null, null, false, "YUMBO", 24 },
                    { 1048, "76895", null, null, false, "ZARZAL", 24 },
                    { 1049, "81001", null, null, false, "ARAUCA", 25 },
                    { 1050, "81065", null, null, false, "ARAUQUITA", 25 },
                    { 1051, "81220", null, null, false, "CRAVO NORTE", 25 },
                    { 1052, "81300", null, null, false, "FORTUL", 25 },
                    { 1053, "81591", null, null, false, "PUERTO RONDÓN", 25 },
                    { 1054, "81736", null, null, false, "SARAVENA", 25 },
                    { 1055, "81794", null, null, false, "TAME", 25 },
                    { 1056, "85001", null, null, false, "YOPAL", 26 },
                    { 1057, "85010", null, null, false, "AGUAZUL", 26 },
                    { 1058, "85015", null, null, false, "CHÁMEZA", 26 },
                    { 1059, "85125", null, null, false, "HATO COROZAL", 26 },
                    { 1060, "85136", null, null, false, "LA SALINA", 26 },
                    { 1061, "85139", null, null, false, "MANÍ", 26 },
                    { 1062, "85162", null, null, false, "MONTERREY", 26 },
                    { 1063, "85225", null, null, false, "NUNCHÍA", 26 },
                    { 1064, "85230", null, null, false, "OROCUÉ", 26 },
                    { 1065, "85250", null, null, false, "PAZ DE ARIPORO", 26 },
                    { 1066, "85263", null, null, false, "PORE", 26 },
                    { 1067, "85279", null, null, false, "RECETOR", 26 },
                    { 1068, "85300", null, null, false, "SABANALARGA", 26 },
                    { 1069, "85315", null, null, false, "SÁCAMA", 26 },
                    { 1070, "85325", null, null, false, "SAN LUIS DE PALENQUE", 26 },
                    { 1071, "85400", null, null, false, "TÁMARA", 26 },
                    { 1072, "85410", null, null, false, "TAURAMENA", 26 },
                    { 1073, "85430", null, null, false, "TRINIDAD", 26 },
                    { 1074, "85440", null, null, false, "VILLANUEVA", 26 },
                    { 1075, "86001", null, null, false, "MOCOA", 27 },
                    { 1076, "86219", null, null, false, "COLÓN", 27 },
                    { 1077, "86320", null, null, false, "ORITO", 27 },
                    { 1078, "86568", null, null, false, "PUERTO ASÍS", 27 },
                    { 1079, "86569", null, null, false, "PUERTO CAICEDO", 27 },
                    { 1080, "86571", null, null, false, "PUERTO GUZMÁN", 27 },
                    { 1081, "86573", null, null, false, "PUERTO LEGUÍZAMO", 27 },
                    { 1082, "86749", null, null, false, "SIBUNDOY", 27 },
                    { 1083, "86755", null, null, false, "SAN FRANCISCO", 27 },
                    { 1084, "86757", null, null, false, "SAN MIGUEL", 27 },
                    { 1085, "86760", null, null, false, "SANTIAGO", 27 },
                    { 1086, "86865", null, null, false, "VALLE DEL GUAMUEZ", 27 },
                    { 1087, "86885", null, null, false, "VILLAGARZÓN", 27 },
                    { 1088, "88001", null, null, false, "SAN ANDRÉS", 28 },
                    { 1089, "88564", null, null, false, "PROVIDENCIA", 28 },
                    { 1090, "91001", null, null, false, "LETICIA", 29 },
                    { 1091, "91263", null, null, false, "EL ENCANTO", 29 },
                    { 1092, "91405", null, null, false, "LA CHORRERA", 29 },
                    { 1093, "91407", null, null, false, "LA PEDRERA", 29 },
                    { 1094, "91430", null, null, false, "LA VICTORIA", 29 },
                    { 1095, "91460", null, null, false, "MIRITÍ - PARANÁ", 29 },
                    { 1096, "91530", null, null, false, "PUERTO ALEGRÍA", 29 },
                    { 1097, "91536", null, null, false, "PUERTO ARICA", 29 },
                    { 1098, "91540", null, null, false, "PUERTO NARIÑO", 29 },
                    { 1099, "91669", null, null, false, "PUERTO SANTANDER", 29 },
                    { 1100, "91798", null, null, false, "TARAPACÁ", 29 },
                    { 1101, "94001", null, null, false, "INÍRIDA", 30 },
                    { 1102, "94343", null, null, false, "BARRANCOMINAS", 30 },
                    { 1103, "94883", null, null, false, "SAN FELIPE", 30 },
                    { 1104, "94884", null, null, false, "PUERTO COLOMBIA", 30 },
                    { 1105, "94885", null, null, false, "LA GUADALUPE", 30 },
                    { 1106, "94886", null, null, false, "CACAHUAL", 30 },
                    { 1107, "94887", null, null, false, "PANA PANA", 30 },
                    { 1108, "94888", null, null, false, "MORICHAL", 30 },
                    { 1109, "95001", null, null, false, "SAN JOSÉ DEL GUAVIARE", 31 },
                    { 1110, "95015", null, null, false, "CALAMAR", 31 },
                    { 1111, "95025", null, null, false, "EL RETORNO", 31 },
                    { 1112, "95200", null, null, false, "MIRAFLORES", 31 },
                    { 1113, "97001", null, null, false, "MITÚ", 32 },
                    { 1114, "97161", null, null, false, "CARURÚ", 32 },
                    { 1115, "97511", null, null, false, "PACOA", 32 },
                    { 1116, "97666", null, null, false, "TARAIRA", 32 },
                    { 1117, "97777", null, null, false, "PAPUNAHUA", 32 },
                    { 1118, "97889", null, null, false, "YAVARATÉ", 32 },
                    { 1119, "99001", null, null, false, "PUERTO CARREÑO", 33 },
                    { 1120, "99524", null, null, false, "LA PRIMAVERA", 33 },
                    { 1121, "99624", null, null, false, "SANTA ROSALÍA", 33 },
                    { 1122, "99773", null, null, false, "CUMARIBO", 33 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CategoryId", "IsActive", "Name", "Password", "TerminalId", "UserName" },
                values: new object[,]
                {
                    { new Guid("229c4d76-0bf2-45ce-b0e8-f51d0373bd29"), 1, true, "Sociedad Portuaria de Buenaventura (SPB)", "Contraseña123", null, "spb@unal.edu.co" },
                    { new Guid("3b02d1a6-f927-4c61-afb6-50d6c00f5add"), 4, true, "Colombian Logistics Solutions (CLS)", "Contraseña123", null, "cls@unal.edu.co" },
                    { new Guid("7c53c90e-2990-4a54-ac38-2aa981288f9e"), 2, true, "Sociedad Portuaria Regional de Cartagena (SPRC)", "Contraseña123", null, "sprc@unal.edu.co" },
                    { new Guid("ea956473-865a-490b-abbf-767b0b67fd7c"), 1, true, "Cristian Moreno", "Contraseña123", null, "crmorenob@unal.edu.co" },
                    { new Guid("fa0f0ff8-f46f-41e9-9ae0-43144b7289b7"), 3, true, "TCC (Transporte de Carga Colombiano)", "Contraseña123", null, "tcc@unal.edu.co" }
                });

            migrationBuilder.InsertData(
                table: "Drivers",
                columns: new[] { "DriverId", "IdentificationNumber", "IdentificationTypeId", "IsActive", "LicenceNumber", "Notes", "Phone", "UserId" },
                values: new object[] { new Guid("9f9e3f43-0a60-4cdc-a9e0-bf4f0197172a"), "1234567890", 1, true, "1234567890", null, "(+57) 3011234567", new Guid("ea956473-865a-490b-abbf-767b0b67fd7c") });

            migrationBuilder.InsertData(
                table: "Providers",
                columns: new[] { "ProviderId", "ContactName", "ContactPhone", "FiscalAddress", "FiscalNumber", "IsActive", "Notes", "UserId" },
                values: new object[,]
                {
                    { new Guid("2369a424-35b5-4999-855a-b322e8c06f7b"), "Raul Castro", "3108745324", "Calle Faalsa 123", "1122448", true, null, new Guid("fa0f0ff8-f46f-41e9-9ae0-43144b7289b7") },
                    { new Guid("2d23aa6c-f504-4b18-9e4e-256632d84b08"), "Luis Mazorca", "3101234567", "5° Avenue, green house tower", "9632587", true, null, new Guid("229c4d76-0bf2-45ce-b0e8-f51d0373bd29") },
                    { new Guid("cb7a5166-b31d-483d-ac91-6bff3b3c7acf"), "Nicolas Laiton", "3107412589", "Calle 123 #125", "7845963", true, null, new Guid("7c53c90e-2990-4a54-ac38-2aa981288f9e") }
                });

            migrationBuilder.InsertData(
                table: "SuperPowers",
                columns: new[] { "SuperPowerId", "CreatedDate", "CreatedUserId", "IsActive", "LastUpdatedDate", "LastUpdatedUserId", "MinutesDuaration", "MultiplierFactor", "Name" },
                values: new object[,]
                {
                    { new Guid("1513d304-55c4-4066-b74d-01177c23e965"), new DateTime(2025, 2, 28, 1, 32, 39, 133, DateTimeKind.Utc).AddTicks(196), new Guid("ea956473-865a-490b-abbf-767b0b67fd7c"), false, null, null, 86400, 0.15m, "Turbito 15%" },
                    { new Guid("a8461b80-3d84-4622-b6c5-0fd42ca07852"), new DateTime(2025, 2, 28, 1, 32, 39, 133, DateTimeKind.Utc).AddTicks(194), new Guid("ea956473-865a-490b-abbf-767b0b67fd7c"), false, null, null, 172800, 0.1m, "Turbito 10%" }
                });

            migrationBuilder.InsertData(
                table: "Terminals",
                columns: new[] { "TerminalId", "GeographicLocationCityId", "IsActive", "Name", "OperatorId", "Url" },
                values: new object[,]
                {
                    { 1, 150, true, "Terminal de Contenedores de Cartagena (Contecar)", 1L, "https://www.puertocartagena.com/es/sprc-online" },
                    { 2, 1013, true, "Terminal de Contenedores de Buenaventura (TCBUEN)", 2L, "https://www.apmterminals.com/es/buenaventura" },
                    { 3, 658, true, "Terminal de Contenedores de Santa Marta (TCSM)", 3L, "https://www.spsm.com.co/terminales/terminales" },
                    { 4, 126, true, "Terminal de Contenedores de Barranquilla (TCPA)", 4L, "https://www.puertodebarranquilla.com/" },
                    { 5, 126, true, "Terminal de Contenedores de la Costa Atlántica (TCA)", 5L, "https://www.globalpsa.com/" },
                    { 6, 113, true, "Terminal de Contenedores de Turbo (TCT)", 6L, "https://puertoantioquia.com.co/" },
                    { 7, 778, true, "Terminal de Contenedores de Tumaco (TCTUM)", 7L, "https://www.ani.gov.co/zonas-portuarias/zona-portuaria-de-tumaco" }
                });

            migrationBuilder.InsertData(
                table: "WalletUsers",
                columns: new[] { "UserId", "WalletId", "Balance" },
                values: new object[] { new Guid("ea956473-865a-490b-abbf-767b0b67fd7c"), new Guid("ee2b3a84-43b1-46cf-b29e-7ad4db5a2000"), 10m });

            migrationBuilder.InsertData(
                table: "AppointmentStates",
                columns: new[] { "AppointmentStateId", "AllowChanges", "IsActive", "IsReserve", "Name", "TerminalId" },
                values: new object[,]
                {
                    { 1, true, true, true, "Asignada", 1 },
                    { 2, true, true, false, "Aprobada", 1 },
                    { 3, false, true, false, "Cumplida", 1 },
                    { 4, false, true, false, "Incumplida", 1 },
                    { 5, false, true, false, "Cancelada", 1 },
                    { 6, false, true, false, "Cancelada", 1 },
                    { 8, true, true, true, "Asinada", 2 },
                    { 9, true, true, false, "Aprobada", 2 },
                    { 10, true, true, false, "Cancelada", 2 }
                });

            migrationBuilder.InsertData(
                table: "Calendars",
                columns: new[] { "CalendarId", "Description", "FinishTime", "HasOverlaping", "IsActive", "Name", "StartTime", "TerminalId" },
                values: new object[,]
                {
                    { new Guid("20bc58ed-cd6a-4053-ad7b-fc5f0706d555"), "Unica opción", new TimeSpan(0, 23, 0, 0, 0), true, true, "Premium", new TimeSpan(0, 3, 0, 0, 0), 2 },
                    { new Guid("ac0a14cc-547e-47f8-8ec8-32bb7aecd4dc"), "Calendario diseñado para el uso de clientes ocasionales", new TimeSpan(0, 22, 0, 0, 0), true, true, "General 1", new TimeSpan(0, 6, 0, 0, 0), 1 },
                    { new Guid("d78d5862-ec55-4222-96bb-507a660d8f3a"), "Calendario diseñado para el uso de clientes premium", new TimeSpan(0, 23, 0, 0, 0), true, true, "Premium", new TimeSpan(0, 3, 0, 0, 0), 1 },
                    { new Guid("e6b4ebe7-625b-4e16-ad1c-8a3b85c475e9"), "Calendario diseñado para el uso de clientes ocasionales", new TimeSpan(0, 22, 0, 0, 0), true, true, "General 2", new TimeSpan(0, 6, 0, 0, 0), 1 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "FisicalLocation", "IsActive", "Name", "TerminalId" },
                values: new object[,]
                {
                    { 1, "MZ1 Bodega 1", true, "Gate 1.1", 1 },
                    { 2, "MZ1 Bodega 2", true, "Gate 1.2", 1 },
                    { 3, "MZ1 Bodega 3", true, "Gate 2.1", 1 },
                    { 4, "Bodega 1", true, "Puerto 1", 2 },
                    { 5, "Bodega 2", true, "Puerto 1", 2 },
                    { 6, "Bodega 1", true, "Puerto 2", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CategoryId", "IsActive", "Name", "Password", "TerminalId", "UserName" },
                values: new object[] { new Guid("8f7ef30e-ff2a-447b-9677-c866240d366f"), 9, true, "Cindy Orjuela", "Contraseña123", 1, "corjuelaa@unal.edu.co" });

            migrationBuilder.InsertData(
                table: "Missions",
                columns: new[] { "MissionId", "CreatedDate", "CreatedUserId", "Description", "IsActive", "LastUpdatedDate", "LastUpdatedUserId", "Points" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 28, 1, 32, 39, 133, DateTimeKind.Utc).AddTicks(341), new Guid("8f7ef30e-ff2a-447b-9677-c866240d366f"), "Llegar a tiempo", true, null, null, 10m },
                    { 2, new DateTime(2025, 2, 28, 1, 32, 39, 133, DateTimeKind.Utc).AddTicks(343), new Guid("8f7ef30e-ff2a-447b-9677-c866240d366f"), "Salir a tiempo", true, null, null, 10m },
                    { 3, new DateTime(2025, 2, 28, 1, 32, 39, 133, DateTimeKind.Utc).AddTicks(344), new Guid("8f7ef30e-ff2a-447b-9677-c866240d366f"), "Documentación completa", true, null, null, 10m }
                });

            migrationBuilder.InsertData(
                table: "TerminalOperators",
                columns: new[] { "TerminalOperatorId", "IsActive", "UserId" },
                values: new object[] { new Guid("02180a26-859c-487f-b6c1-580b41c47e71"), true, new Guid("8f7ef30e-ff2a-447b-9677-c866240d366f") });

            migrationBuilder.InsertData(
                table: "WalletUsers",
                columns: new[] { "UserId", "WalletId", "Balance" },
                values: new object[] { new Guid("8f7ef30e-ff2a-447b-9677-c866240d366f"), new Guid("2767eaa8-b36c-4b28-85ff-64aca70aac5c"), 200m });

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
                name: "IX_SuperPowers_CreatedUserId",
                table: "SuperPowers",
                column: "CreatedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_SuperPowers_LastUpdatedUserId",
                table: "SuperPowers",
                column: "LastUpdatedUserId");

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

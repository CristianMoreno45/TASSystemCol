using UnalColombia.Logistic.TAS.Domain.Entities;
using UnalColombia.Logistic.TAS.Domain.Repositories;
using UnalColombia.Logistic.TAS.Infrastructure.Repositories;
using UnalColombia.Logistic.TAS.Shared.Requests.MissionAppointment;

namespace UnalColombia.Logistic.TAS.Api.Handlers
{
    public class MissionAppointmentHandler : IMissionAppointmentHandler
    {
        private readonly ILogger _logger;
        private readonly IMissionAppointmentRepository _missionAppoinmentRepository;
        private readonly IAppointmentHandler _appointmentService;
        private readonly IWalletUserHandler _walletUserHandler;

        public MissionAppointmentHandler(ILogger logger,
            IMissionAppointmentRepository missionAppoinmentRepository,
            IAppointmentHandler appointmentService,
            IWalletUserHandler walletUserHandler
            )
        {
            _logger = logger;
            _missionAppoinmentRepository = missionAppoinmentRepository;
            _appointmentService = appointmentService;
            _walletUserHandler = walletUserHandler;
        }

        public async Task<bool> SetComplaingStatusMission(SetComplaingStatusMissionRequest request)
        {
            var appointmentId = request.Missions.Select(x => x.AppointmentId).FirstOrDefault();
            var missionAppointment = _missionAppoinmentRepository.GetMissionAppointmetByIdWalletInfo(appointmentId).ToList();
            if (missionAppointment == null || missionAppointment.Count == 0) return false;

            var userId = missionAppointment.FirstOrDefault().Appointment.Driver.User.UserId;
            var walletId = missionAppointment.FirstOrDefault().Appointment.Driver.User.WalledByUsers.FirstOrDefault().WalletId;

            foreach (var ms in request.Missions)
            {
                var mission = missionAppointment.Where(x => x.MissionId == ms.MissionId).FirstOrDefault();
                if (mission != null)
                {
                    mission.IsAchieved = ms.IsAchieved;
                    if (mission.IsAchieved)
                        if (!await _walletUserHandler.DepositPoints(walletId, userId, mission.Mission.Points, $"Ganaste {mission.Mission.Points} kilómetros por {mission.Mission.Description}"))
                        {
                            //TODO: handle error

                        }
                };
            }

            missionAppointment.ForEach(ms =>
            {
                _missionAppoinmentRepository.UpdateAsync(ms).Wait();
            });

            await _appointmentService.SetComplaingStatusMission(appointmentId);
            await _missionAppoinmentRepository.SaveChangesAsync();

            return true;
        }

    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NFLPicker.Utilities;
using DataAccess;
using NFLPicker.Errors;

namespace NFLPicker.Drivers
{
    public class ScheduleDriver
    {
        IRepository<Schedule> _scheduleRepos;
        IRepository<Settings> _settingsRepos;

        public ScheduleDriver(IRepository<Schedule> scheduleRepos, IRepository<Settings> settingsRepos)
        {
            _scheduleRepos = scheduleRepos;
            _settingsRepos = settingsRepos;
        }

        public async Task<Schedule> GetCurrentScheduleAsync()
        {
            var settings = await _settingsRepos.FindAllAsync();
            var currentSeason = settings.First().CurrentSeason;

            var schedule = await _scheduleRepos.FindAsync(s => s.SeasonName == currentSeason);

            return schedule.First();
        }

        public async Task<IEnumerable<Schedule>> GetAllSchedulesAsync()
        {
            return await _scheduleRepos.FindAllAsync();
        }

        public async Task<Schedule> GetScheduleAsync(string id)
        {
            if (!Validators.IsValidBSONId(id))
                throw new InvalidDataException("Invalid schedule id");

            return await _scheduleRepos.FindByIdAsync(id);
        }

        public async Task SaveScheduleAsync(Schedule schedule)
        {
            await _scheduleRepos.SaveAsync(schedule);
        }
    }
}

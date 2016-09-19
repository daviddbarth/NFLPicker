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

        public ScheduleDriver(IRepository<Schedule> scheduleRepos)
        {
            _scheduleRepos = scheduleRepos;
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

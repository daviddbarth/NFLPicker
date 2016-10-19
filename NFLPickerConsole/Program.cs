using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using NFLPicker;
using NFLPicker.Drivers;

namespace NFLPickerConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            SaveTeam().Wait();

        }

        private static async Task SaveTeam()
        {
            var repos = new MongoRepository<Schedule>();
            var schedule = await repos.FindByIdAsync("57e9e1323b3be91f740fc64c");

            schedule.Weeks = new List<Week>();
            schedule.Weeks.Add(new Week { Name = "Week 1" });
            schedule.Weeks.Add(new Week { Name = "Week 2" });

            await repos.SaveAsync(schedule);



        }
    }
}

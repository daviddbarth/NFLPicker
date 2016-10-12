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
            var setting = new Settings();

            setting.CurrentSeason = "2016-2017";

            var repos = new MongoRepository<Settings>();
            await repos.SaveAsync(setting);

            //var driver = new TeamDriver(new MongoRepository<Team>());

            //var team = new Team() { City = "Houston", Name = "Texans", LogoUrl = string.Empty };
            //await driver.SaveTeamAsync(team);
            
        }
    }
}

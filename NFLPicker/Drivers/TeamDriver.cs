using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace NFLPicker.Drivers
{
    public class TeamDriver
    {
        private IRepository<Team> _teamRepos;

        public TeamDriver(IRepository<Team> teamRepos)
        {
            _teamRepos = teamRepos;
        }

        public async Task<Team> GetTeamAsync(string id)
        {
            return await _teamRepos.FindByIdAsync(id);
        }

        public async Task SaveTeamAsync(Team team)
        {
            await _teamRepos.SaveAsync(team);
        }
    }
}

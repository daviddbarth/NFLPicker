using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using NFLPicker.Utilities;
using NFLPicker.Errors;

namespace NFLPicker.Drivers
{
    public class TeamDriver
    {
        private IRepository<Team> _teamRepos;

        public TeamDriver(IRepository<Team> teamRepos)
        {
            _teamRepos = teamRepos;
        }

        public async Task<IEnumerable<Team>> GetAllTeamsAsync()
        {
            return await _teamRepos.FindAllAsync();
        }

        public async Task<Team> GetTeamAsync(string id)
        {
            if (!Validators.IsValidBSONId(id))
                throw new InvalidDataException("Invalid team id.");

            return await _teamRepos.FindByIdAsync(id);
        }

        public async Task SaveTeamAsync(Team team)
        {
            await _teamRepos.SaveAsync(team);
        }
    }
}

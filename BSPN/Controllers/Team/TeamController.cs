using System;
using System.Web.Http;
using System.Threading.Tasks;
using NFLPicker.Drivers;
using NFLPicker.Errors;

namespace BSPN.Controllers
{ 
    public class TeamController : ApiController
    {
        TeamDriver _teamDriver;
        ErrorDriver _errorDriver;

        public TeamController(TeamDriver teamDriver, ErrorDriver errorDriver)
        {
            _teamDriver = teamDriver;
            _errorDriver = errorDriver;
        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var teams = await _teamDriver.GetAllTeamsAsync();
                return Ok(teams);
            }
            catch(Exception ex)
            {
                await _errorDriver.LogError(ex);
                return InternalServerError();
            }
        }

        public async Task<IHttpActionResult> Get(string id)
        {
            try
            {
                var team = await _teamDriver.GetTeamAsync(id);
                return Ok(team);
            }
            catch(InvalidDataException ix)
            {
                return BadRequest(ix.Message);
            }
            catch (Exception ex)
            {
                await _errorDriver.LogError(ex);
                return InternalServerError();
            }
        }
    }
}

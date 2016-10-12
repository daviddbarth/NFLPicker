using NFLPicker.Drivers;
using NFLPicker.Errors;
using NFLPicker;
using System;
using System.Threading.Tasks;
using System.Web.Http;

namespace BSPN.Controllers
{
    public class ScheduleController : ApiController
    {
        ScheduleDriver _scheduleDriver;
        ErrorDriver _errorDriver;

        public ScheduleController(ScheduleDriver scheduleDriver, ErrorDriver errorDriver)
        {
            _scheduleDriver = scheduleDriver;
            _errorDriver = errorDriver;
        }

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var schedule = await _scheduleDriver.GetCurrentScheduleAsync();
                return Ok(schedule);
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
                var schedule = await _scheduleDriver.GetScheduleAsync(id);
                return Ok(schedule);
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

        public async Task<IHttpActionResult> Put(Schedule schedule)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("Invalid Data");

                await _scheduleDriver.SaveScheduleAsync(schedule);

                return Ok();
            }
            catch(Exception ex)
            {
                await _errorDriver.LogError(ex);
                return InternalServerError();
            }
        }
    }
}

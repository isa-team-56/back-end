using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers
{
    [Authorize(Policy = "allRolesPolicy")]
    [Route("api/appointment")]
    public class AppointmentController : BaseApiController
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }


        [HttpGet]
        public ActionResult<PagedResult<AppointmentDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _appointmentService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [Authorize(Policy = "administratorcPolicy")]
        [HttpPost]
        public ActionResult<AppointmentDto> Create([FromBody] AppointmentDto appointment)
        {
            var result = _appointmentService.Create(appointment);
            return CreateResponse(result);
        }

        [Authorize(Policy = "administratorcPolicy")]
        [HttpPut("{id:int}")]
        public ActionResult<AppointmentDto> Update([FromBody] AppointmentDto appointment)
        {
            var result = _appointmentService.Update(appointment);
            return CreateResponse(result);
        }

        [Authorize(Policy = "administratorcPolicy")]
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _appointmentService.Delete(id);
            return CreateResponse(result);
        }

        [Authorize(Policy = "staffPolicy")]
        [HttpGet("reserveAppointment/{id}")]
        public ActionResult ChangeReservedStatus(int id)
        {
            return CreateResponse(_appointmentService.ChangeReservedStatus(id));


        }

        [HttpPut("getAppointmentsByCompany")]
        public ActionResult<AppointmentDto> GetAppointmentsByCompany([FromBody] CompanyDto company)
        {
            return CreateResponse(_appointmentService.GetAppointmentsByCompany(company));
        }
        



    }
}

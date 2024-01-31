using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.UseCases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Explorer.API.Controllers
{
    [Authorize(Policy = "allRolesPolicy")]
    [Route("api/reservation")]
    public class ReservationController : BaseApiController
    {
        private readonly IReservationService _reservationService;

        public ReservationController(IReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        
        [HttpGet]
        public ActionResult<PagedResult<ReservationDto>> GetAll([FromQuery] int page, [FromQuery] int pageSize)
        {
            var result = _reservationService.GetPaged(page, pageSize);
            return CreateResponse(result);
        }

        [HttpPost]
        public ActionResult<ReservationDto> Create([FromBody] ReservationDto reservation)
        {
            Console.WriteLine($"Received appointmentId: {reservation.ReservedAppointment}");
            var result = _reservationService.Create(reservation);

            return CreateResponse(result);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ReservationDto> Update([FromBody] ReservationDto reservation)
        {
            var result = _reservationService.Update(reservation);
            return CreateResponse(result);
        }

        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            var result = _reservationService.Delete(id);
            return CreateResponse(result);
        }

        [HttpGet("cancelReservation/{id}")]
        public ActionResult CancelReservation(int id)
        {
            return CreateResponse(_reservationService.CancelReservation(id));


        }

        [HttpPost("reservationConfirmation")]
        public ActionResult<bool> SendReservationConfirmationEmail([FromQuery] string email, [FromBody] ReservationDto reservation)
        {
            try
            {
                _reservationService.SendReservationConfirmationEmail(email, reservation);
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }
        }



    }
}

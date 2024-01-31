using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public;

public interface IReservationService
{
    Result<PagedResult<ReservationDto>> GetPaged(int page, int pageSize);
    Result<ReservationDto> Create(ReservationDto reservation);
    Result<ReservationDto> Update(ReservationDto reservation);
    Result Delete(int id);
    Result<ReservationDto> CancelReservation(int id);
    // Result<List<int>> GetCanceledAppointmentsByUserId(int userId);
    public void SendReservationConfirmationEmail(string recipientEmail);

}


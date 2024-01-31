using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases;

public class ReservationService : CrudService<ReservationDto, Reservation>, IReservationService
{
    private readonly ICrudRepository<Appointment> _appointmentRepository;
    private readonly IAppointmentService _appointmentService;
    private readonly ICrudRepository<Person> _personRepository;
    private readonly IPersonService _personService;


    public ReservationService(ICrudRepository<Reservation> repository, IMapper mapper, ICrudRepository<Appointment> repositoryA, IAppointmentService appointmentService, ICrudRepository<Person> repositoryP, IPersonService personService) : base(repository, mapper) {
                        _appointmentRepository = repositoryA;
                        _appointmentService = appointmentService;
                        _personRepository = repositoryP;
                        _personService = personService;
    }
    public Result<ReservationDto> CancelReservation(int id)
    {
        var reservationDb = CrudRepository.Get(id);
        
        if (reservationDb.State == "in progress")
        {
            reservationDb.State = "canceled";
            var app = _appointmentRepository.Get(reservationDb.ReservedAppointment);
            _appointmentService.ChangeReservedStatus((int)app.Id);

            TimeSpan timeDifference = app.Start - DateTime.Now;

            
            int quantity = (timeDifference.TotalHours < 24) ? 2 : 1;
            _personService.changePenaltyPoints(reservationDb.UserId,quantity);
        }
        
        CrudRepository.Update(reservationDb);
        return MapToDto(reservationDb);
    }

    


    /*
    public Result<List<AppointmentDto>> GetAppointmentsByCompany1(CompanyDto company, UserDto user)
    {
        var companyId = company.Id;
        var currentDateTime = DateTime.Now;
        var canceledAppointmentIds = GetCanceledAppointmentsByUserId((int)user.Id).Value;

        
        var allAppointmentsResult = _appointmentRepository.GetPaged(0, 0).Results;
        var resultAppointments = allAppointmentsResult
         .Where(appointment => appointment.CompanyId == companyId
                              && !appointment.IsReserved
                              && appointment.Start >= currentDateTime
                              && !canceledAppointmentIds.Contains((int)appointment.Id))
         .Select(appointment => MapToDto(appointment))
         .ToList();
        return resultAppointments;
    }



    public Result<List<int>> GetCanceledAppointmentsByUserId(int userId)
    {
        var canceledReservations = CrudRepository.GetPaged(0, 0).Results;

        // Filtriraj rezervacije prema UserId i "canceled" statusu
        var canceledAppointments = canceledReservations
            .Where(reservation => reservation.UserId == userId && reservation.State == "canceled")
            .Select(reservation => reservation.ReservedAppointment)
            .ToList();

        return Result.Ok(canceledAppointments);
    }*/

}
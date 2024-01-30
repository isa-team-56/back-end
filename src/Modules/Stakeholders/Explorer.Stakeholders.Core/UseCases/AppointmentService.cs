using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases;

public class AppointmentService : CrudService<AppointmentDto, Appointment>, IAppointmentService
{

    public AppointmentService(ICrudRepository<Appointment> repository, IMapper mapper) : base(repository, mapper) { }


    public Result<AppointmentDto> ChangeReservedStatus(int id)
    {
        var appointmentDb = CrudRepository.Get(id);
       
        if (appointmentDb.IsReserved == false) {
            appointmentDb.IsReserved = true;
        }
        else if (appointmentDb.IsReserved == true)
        {
            appointmentDb.IsReserved = false;
        }
        CrudRepository.Update(appointmentDb);
        return MapToDto(appointmentDb);
    }
   

    public Result<List<AppointmentDto>> GetAppointmentsByCompany(CompanyDto company)
    {
        var companyId = company.Id;
        var currentDateTime = DateTime.Now;

        var allAppointmentsResult = CrudRepository.GetPaged(0, 0).Results;
        var resultAppointments = allAppointmentsResult
              .Where(appointment => appointment.CompanyId == companyId
                                   && !appointment.IsReserved
                                   && appointment.Start >= currentDateTime)
              .Select(appointment => MapToDto(appointment))
              .ToList();
        return resultAppointments;
    }



}


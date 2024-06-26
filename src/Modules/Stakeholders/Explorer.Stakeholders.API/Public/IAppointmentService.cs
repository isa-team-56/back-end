﻿using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public;

public interface IAppointmentService
{
    Result<PagedResult<AppointmentDto>> GetPaged(int page, int pageSize);
   
    Result<AppointmentDto> Create(AppointmentDto appointment);
    Result<AppointmentDto> Update(AppointmentDto appointment);
    Result Delete(int id);
    Result<AppointmentDto> ChangeReservedStatus(int id);
    Result<List<AppointmentDto>> GetAppointmentsByCompany(CompanyDto company);


}



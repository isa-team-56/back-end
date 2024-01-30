using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Public;

    public interface ICompanyService
    {
    Result<PagedResult<CompanyDto>> GetPaged(int page, int pageSize);
    Result<CompanyDto> Create(CompanyDto company);
    Result<CompanyDto> Update(CompanyDto company);
    Result Delete(int id);
    Result<List<CompanyDto>> GetCompaniesByEquipment(EquipmentDto equipment);
    }


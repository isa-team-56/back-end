using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Converters;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.RepositoryInterfaces;
using Explorer.Stakeholders.Core.Domain.Users;
using FluentResults;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.UseCases;

public class CompanyService : CrudService<CompanyDto, Company>, ICompanyService
{
   
    public CompanyService(ICrudRepository<Company> repository, IMapper mapper) : base(repository, mapper) { }

    public Result<List<CompanyDto>> GetCompaniesByEquipment(EquipmentDto equipment)
    {
        var equipmentIds = equipment.CompanyIds;

        var allCompanyResult = CrudRepository.GetPaged(0, 0).Results;
        var resultCompanies = new List<CompanyDto>();

        foreach (var company in allCompanyResult)
        {
            if (equipmentIds.Contains((int)company.Id))
            {
                var companyDto = MapToDto(company);
                resultCompanies.Add(companyDto);
            }
        }

        return resultCompanies;
    }





}


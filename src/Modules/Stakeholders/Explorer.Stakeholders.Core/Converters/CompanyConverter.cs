using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.Core.Domain;
using Explorer.Stakeholders.Core.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Converters
{
    public static class CompanyConverter
    {
        public static CompanyDto ToDto(this Company company)
        {
            if (company == null)
            {
                return null;
            }
            return new CompanyDto
            {
                 Id = (int)company.Id,
                 Name = company.Name,
                 Address=company.Address,
                 Description=company.Description,
                 AverageGrade=company.AverageGrade,
                 CompanyAdministrators=company.CompanyAdministrators
                
            };
        }

        public static Company ToDomain(this CompanyDto companyDto)
        {
            return companyDto == null ? null :
            new Company(companyDto.Name, companyDto.Address, companyDto.Description, companyDto.AverageGrade, companyDto.CompanyAdministrators);
        }
    }
}
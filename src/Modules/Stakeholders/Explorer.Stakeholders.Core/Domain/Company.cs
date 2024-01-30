using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class Company : Entity
    {
        public string Name { get; init; }

        public string Address { get; init; }

        public string Description { get; init; }
        public float AverageGrade { get; init; }
        public List<int> CompanyAdministrators { get; init; }


        public Company(string name, string address, string description, float averageGrade, List<int> companyAdministrators)
        {
            Name = name;
            Address = address;
            Description = description;
            AverageGrade = averageGrade;
            CompanyAdministrators = companyAdministrators ?? new List<int>();
        }


    }
}

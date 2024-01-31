using Explorer.BuildingBlocks.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.Core.Domain
{
    public class Appointment : Entity
    {
        public DateTime Start { get; private set; }
        public int Duration { get; set; }
        public int CompanyId { get; init; }
        public string AdminName { get; init; }
        public string AdminSurname { get; init; }

        public bool IsReserved { get; set; }
        public int AdminId { get; private set; }



        public Appointment(DateTime start, int duration,int companyId,string adminName,string adminSurname,bool isReserved,int adminId)
        {
            
            Start = start;
            Duration = duration;
            CompanyId = companyId;
            AdminName = adminName;
            AdminSurname = adminSurname;
            IsReserved = isReserved;
            AdminId = adminId;
           
           
        }
    }
}

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
        public DateTime Start { get; init; }
        public DateTime End { get; init; }

        public string AdminName { get; init; }
        public string AdminSurname { get; init; }
        public bool IsReserved { get; init; }

        public int? StaffId { get; init; }


        public Appointment(DateTime start, DateTime end,string adminName,string adminSurname,bool isReserved, int? staffId)
        {
            
            Start = start;
            End = end;
            AdminName = adminName;
            AdminSurname = adminSurname;
            IsReserved = isReserved;
            StaffId = staffId;
        }
    }
}

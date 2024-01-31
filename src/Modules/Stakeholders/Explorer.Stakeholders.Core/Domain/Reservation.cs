using Explorer.BuildingBlocks.Core.Domain;
using System;

namespace Explorer.Stakeholders.Core.Domain
{
    public class Reservation : Entity
    {
        public int ReservedAppointment { get;  set; }
       

        public int UserId { get; set; }
        public string State { get; set; }

        public int EquipmentId { get; set; }
        public int CompanyId { get; set; }



        public Reservation(int reservedAppointment, int userId, string state,int equipmentId,int companyId)
        {
            ReservedAppointment = reservedAppointment;
            UserId = userId;
            SetState(state);
            EquipmentId = equipmentId;
            CompanyId = companyId;
        }

        public void SetState(string state)
        {
            if (state == "in progress" || state == "finished" || state == "canceled")
            {
                State = state;
            }
            else
            {
                throw new ArgumentException("Invalid state value");
            }
        }
    }
}

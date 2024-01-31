using Explorer.BuildingBlocks.Core.Domain;
using System;

namespace Explorer.Stakeholders.Core.Domain
{
    public class Reservation : Entity
    {
        public int ReservedAppointment { get; private set; }
       

        public int UserId { get; private set; }
        public string State { get; set; }

        public int EquipmentId { get; set; }



        public Reservation(int reservedAppointment, int userId, string state,int equipmentId)
        {
            ReservedAppointment = reservedAppointment;
            UserId = userId;
            SetState(state);
            EquipmentId = equipmentId;
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

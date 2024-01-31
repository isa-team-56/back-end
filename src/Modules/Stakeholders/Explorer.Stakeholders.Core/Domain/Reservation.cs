using Explorer.BuildingBlocks.Core.Domain;
using System;

namespace Explorer.Stakeholders.Core.Domain
{
    public class Reservation : Entity
    {
        public int ReservedAppointment { get; private set; }
        
        public int UserId { get; private set; }
        public string State { get; set; }

        private Reservation() { }

        
        public Reservation(int reservedAppointment, int userId, string state)
        {
            ReservedAppointment = reservedAppointment;
            UserId = userId;
            SetState(state);
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

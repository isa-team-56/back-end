using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Explorer.Stakeholders.API.Dtos;

    public class ReservationDto
    {
    public int Id { get; set; }
     public int ReservedAppointment { get; set; }
     public int UserId { get; set; }

     public string State { get; set; }
     public int EquipmentId { get; set; }
}


   


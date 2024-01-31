using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Explorer.Stakeholders.API.Dtos;

public class AppointmentDto
{
    public int Id { get; set; }
    public DateTime Start { get; set; }
    public int Duration { get; set; }
    public int CompanyId { get; set; }
    public string AdminName { get; set; }
    public string AdminSurname { get; set; }

    public bool IsReserved { get; set; }
    public int AdminId { get; set; }

}

using AutoMapper;
using Explorer.BuildingBlocks.Core.UseCases;
using Explorer.Stakeholders.API.Dtos;
using Explorer.Stakeholders.API.Public;
using Explorer.Stakeholders.Core.Domain;
using FluentResults;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using Newtonsoft.Json;
using System.Drawing;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using System.Net.Mime;
using Explorer.Stakeholders.Core.Domain.Users;

namespace Explorer.Stakeholders.Core.UseCases;

public class ReservationService : CrudService<ReservationDto, Reservation>, IReservationService
{
    private readonly ICrudRepository<Appointment> _appointmentRepository;
    private readonly IAppointmentService _appointmentService;
    private readonly ICrudRepository<Person> _personRepository;
    private readonly IPersonService _personService;
    private readonly string _smtpServer = "smtp.gmail.com";
    private readonly int _port = 587;
    private readonly string _email = "isa.team56@gmail.com";
    private readonly string _password = "crcf sdjs dstl nsxa";
   


    public ReservationService(ICrudRepository<Reservation> repository, IMapper mapper, ICrudRepository<Appointment> repositoryA, IAppointmentService appointmentService, ICrudRepository<Person> repositoryP, IPersonService personService) : base(repository, mapper) {
                        _appointmentRepository = repositoryA;
                        _appointmentService = appointmentService;
                        _personRepository = repositoryP;
                        _personService = personService;
    }
    public Result<ReservationDto> CancelReservation(int id)
    {
        var reservationDb = CrudRepository.Get(id);
        
        if (reservationDb.State == "in progress")
        {
            reservationDb.State = "canceled";
            var app = _appointmentRepository.Get(reservationDb.ReservedAppointment);
            _appointmentService.ChangeReservedStatus((int)app.Id);

            TimeSpan timeDifference = app.Start - DateTime.Now;

            
            int quantity = (timeDifference.TotalHours < 24) ? 2 : 1;
            _personService.changePenaltyPoints(reservationDb.UserId,quantity);
        }
        
        CrudRepository.Update(reservationDb);
        return MapToDto(reservationDb);
    }



    public void SendReservationConfirmationEmail(string recipientEmail)
    {
        //var reservationDomain = MapToDomain(reservation);
        string localImagePath = "C:\\Users\\Katarina\\Desktop\\isa7days\\qr.png";

        using (MailMessage mail = new MailMessage())
        {
            mail.From = new MailAddress(_email);
            mail.To.Add(recipientEmail);
            mail.Subject = "Reservation Confirmation";

            // Attach the local image file to the email
            Attachment attachment = new Attachment(localImagePath, "image/png");
            mail.Attachments.Add(attachment);

            // Include a message and reservation details in the email body
            // mail.Body = $"Your reservation details:\n{JsonConvert.SerializeObject(reservation)}";
             mail.Body = $"Your reservation details:";
            mail.IsBodyHtml = true;

            using (SmtpClient smtp = new SmtpClient(_smtpServer, _port))
            {
                smtp.Credentials = new NetworkCredential(_email, _password);
                smtp.EnableSsl = true;
                try
                {
                    smtp.Send(mail);
                    Console.WriteLine("Email with attachment successfully sent!");
                }
                catch (SmtpException ex)
                {
                    Console.WriteLine("SMTP Error: " + ex.StatusCode);
                    Console.WriteLine("Error: " + ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }
    }








}
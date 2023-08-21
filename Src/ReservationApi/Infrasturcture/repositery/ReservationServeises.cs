using Azure.Messaging.ServiceBus;
using Microsoft.Azure.Amqp.Framing;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ReservationApi.Data;
using ReservationApi.Infrasturcture.Domain;
using ReservationApi.Model;
using System.Net;
using System.Net.Http;
using System.Net.Mail;

namespace ReservationApi.Infrasturcture.repositery
{
    public class ReservationServeises : IReservation
    {
        private readonly ApiDbContext _context;
        public ReservationServeises()
        {
            _context = new ApiDbContext();
        }
        public async Task<List<Reservation>> GetAllReservation()
        {
            string connectionString = "Endpoint=sb://mall123.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=BYSgibsTkLpA9w8cvvfPMSX4SUpIuFRhZ+ASbMEbhzg=";
            string queueName = "ank";
            await using var client = new ServiceBusClient(connectionString);
            var reciver = client.CreateReceiver(queueName);
            IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await reciver.ReceiveMessagesAsync(10);
            if (receivedMessages == null)
            {
                return null;
            }
            foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
            {
                string body = receivedMessage.Body.ToString();
                var messageCreated = JsonConvert.DeserializeObject<Reservation>(body);
                await  _context.Reservation.AddAsync(messageCreated);
                await _context.SaveChangesAsync();
                await reciver.CompleteMessageAsync(receivedMessage);
            }
           
            return await  _context.Reservation.ToListAsync();    
        }
        // first fecth the data from aziure servises and then populate in the db 


        public async Task UpdateMailStatus(int id)
        {
            var result = await _context.Reservation.FindAsync(id);
            if (result != null && result.IsMailSent == false)
            {
                var smtpclient = new SmtpClient("smtp-mail.outlook.com")
                {
                    Port = 587,
                    Credentials = new NetworkCredential("ankur@avinex.in", "Yol71414"),
                    EnableSsl = true,
                };
                smtpclient.Send("ankur@avinex.in", result.Email, "Vehicle Test Drive", "Your test drive is reserved");
                result.IsMailSent = true;
                await _context.SaveChangesAsync();
            }
        }
      


    }
}

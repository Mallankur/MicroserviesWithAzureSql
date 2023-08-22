using Azure.Messaging.ServiceBus;
using CustomerApi.Data;
using CustomerApi.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CustomerApi.Infrastructure.Repo
{
    
    public class CustomerServises : Icustumer
    { 
    private ApiDbContext _dbC;

        public CustomerServises()
        {
            _dbC = new ApiDbContext();
        }

        public async Task  CreateAsync(Customer customer)
        {
           var res =  await _dbC.vihicles.FirstOrDefaultAsync(X=>X.Id == customer.vehicleid);

            if (res == null)
            {
                await _dbC.vihicles.AddAsync(customer.vehicle)
                    .ConfigureAwait(false);
               await  _dbC.SaveChangesAsync ();
            }

            customer.vehicle = null;

            await _dbC.Customers.AddAsync(customer);
            await _dbC.SaveChangesAsync();
            string connectionString = "Endpoint=sb://mall123.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=BYSgibsTkLpA9w8cvvfPMSX4SUpIuFRhZ+ASbMEbhzg=";
            string queueName = "ankurmall";
            await using var client = new ServiceBusClient(connectionString);
            var objectAsText = JsonConvert.SerializeObject(customer);

            ServiceBusSender sender = client.CreateSender(queueName);

            ServiceBusMessage message = new ServiceBusMessage(objectAsText);

            await sender.SendMessageAsync(message);


        }
    }
    
}

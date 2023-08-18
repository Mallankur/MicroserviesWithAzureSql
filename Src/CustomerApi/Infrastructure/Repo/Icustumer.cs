using CustomerApi.Model;

namespace CustomerApi.Infrastructure.Repo
{
    public interface Icustumer
    {
        Task<Customer> CreateAsync(Customer customer);  


    }
}

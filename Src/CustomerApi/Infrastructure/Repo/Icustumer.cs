using CustomerApi.Model;

namespace CustomerApi.Infrastructure.Repo
{
    public interface Icustumer
    {
        Task  CreateAsync(Customer customer);  


    }
}

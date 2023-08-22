using ReservationApi.Model;

namespace ReservationApi.Infrasturcture.Domain
{
    public interface IReservation
    {
        Task<List<Reservation>> GetAllReservation();
        Task UpdateMailStatus(int id);


    }
}

using XYZHotelManagementSystem.Models;

namespace XYZHotelManagementSystem.Repository
{
    public interface IHotelServices
    {
        Task<List<Hotel>> GetHotels();

        Task<string> PostHotels(Hotel hotels);

        Task<List<Bufferby>> GetHotelsLocation(string location);

        Task<List<Bufferby>> GetHotelsPrice(float Minprice, float Maxprice);

        Task<List<Hotel>> PutHotels(int id, Hotel hotels);

        Task<string> DeleteHotels(int id);
    }
}

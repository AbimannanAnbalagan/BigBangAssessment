using Microsoft.EntityFrameworkCore;
using XYZHotelManagementSystem.Models;

namespace XYZHotelManagementSystem.Repository
{
    public class HotelServices : IHotelServices
    {

        private readonly FinalDbContext _context;

        public HotelServices(FinalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Hotel>> GetHotels()
        {

            return await _context.Hotels.ToListAsync();

        }

        public async Task<string> PostHotels(Hotel hotels)
        {
            await _context.Hotels.AddAsync(hotels);
            await _context.SaveChangesAsync();
            return "Row Added Successfully";
        }

        public async Task<List<Bufferby>> GetHotelsLocation(string location)
        {


            var det = await _context.Hotels.FirstOrDefaultAsync(x => x.Location == location);
            if (det == null)
            {
                throw new Exception("No hotels in applied Location");
            }
            var details = await (from H in _context.Hotels
                                 join R in _context.Rooms on H.HotelId equals R.HotelId
                                 where R.AvalabilityStatus == "Available" && H.Location == location
                                 select new Bufferby()
                                 {
                                     HotelId = H.HotelId,
                                     HotelName = H.HotelName,
                                     Location = H.Location,
                                     price = R.price,
                                     Available_Rooms = _context.Rooms.Count(s => s.AvalabilityStatus == "Available")
                                 }).Distinct().ToListAsync();


            return details;

        }

        public async Task<List<Bufferby>> GetHotelsPrice(float Minprice, float Maxprice)
        {

            var details = await (from H in _context.Hotels
                                 join R in _context.Rooms on H.HotelId equals R.HotelId
                                 where R.AvalabilityStatus == "Available" && R.price >= Minprice && R.price <= Maxprice

                                 select new Bufferby()
                                 {
                                     HotelId = H.HotelId,
                                     HotelName = H.HotelName,
                                     Location = H.Location,
                                     price = R.price,

                                     Available_Rooms = _context.Rooms.Count(s => s.AvalabilityStatus == "Available" && s.price >= Minprice && s.price <= Maxprice)
                                 }).Distinct().ToListAsync();

            return details;
        }

        public async Task<List<Hotel>> PutHotels(int id, Hotel hotels)
        {
            var det = await _context.Hotels.FindAsync(id);
            if (det == null)
            {
                throw new Exception("No matches");
            }
            det.HotelName = hotels.HotelName;
            det.Location = hotels.Location;
            det.Rooms = hotels.Rooms;

            await _context.SaveChangesAsync();
            return await _context.Hotels.Where(x => x.HotelId == id).ToListAsync();
        }

        public async Task<string> DeleteHotels(int id)
        {
            var det = await _context.Hotels.FindAsync(id);
            _context.Hotels.Remove(det);
            await _context.SaveChangesAsync();
            return $"Details of {det.HotelName} Hotel is deleted Successfully";
        }

    }
}

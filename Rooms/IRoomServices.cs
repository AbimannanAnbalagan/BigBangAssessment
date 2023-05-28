using Microsoft.AspNetCore.Mvc;
using XYZHotelManagementSystem.Models;

namespace XYZHotelManagementSystem.Repository.Rooms
{
    public interface IRoomServices
    {
        Task<ActionResult<List<Room>>> GetRooms();

        Task<ActionResult<List<Room>>> GetRoom(int id);

        Task<ActionResult<List<Room>>> PutRoom(int Roomid, Room room);

        Task<string> DeleteRoom(int id);
    }
}

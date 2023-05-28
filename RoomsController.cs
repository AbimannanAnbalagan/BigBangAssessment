using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using XYZHotelManagementSystem.Models;
using XYZHotelManagementSystem.Repository.Rooms;

namespace XYZHotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomServices _context;

        public RoomsController(IRoomServices context)
        {
            _context = context;
        }

        // GET: api/Rooms
        [HttpGet]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<List<Room>>> GetRooms()
        {

            try
            {
                return await _context.GetRooms();

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }

        
        // GET: api/Rooms/5
        [HttpGet("{Hotelid}")]
        public async Task<ActionResult<List<Room>>> GetRoom(int id)
        {
            try
            {
                return await _context.GetRoom(id);
            }
            catch 
            {
                throw new Exception("Unable to Update");
            }
          
        }


        
        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{Roomid}")]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<List<Room>>> PutRoom(int Roomid, Room room)
        {
            try
            {
                return await _context.PutRoom(Roomid, room);
            }
            catch
            {
                throw new Exception("Unable to Update");
            }

        }

        
        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<String>> PostRoom(Room room)
        {

            try
            {
                return CreatedAtAction("GetRoom", new { id = room.RoomId }, room);
            }
            catch 
            {
                return "Unable to Add Room Details";
            }
        }

        
        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        [Authorize(Roles ="admin")]
        public async Task<string> DeleteRoom(int id)
        {
            try
            {
                return await _context.DeleteRoom(id);
            }
            catch
            {
                return ("No matches");
            }
        }
    }
}

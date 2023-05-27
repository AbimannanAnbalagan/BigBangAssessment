using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XYZHotelManagementSystem.Models;
using XYZHotelManagementSystem.Repository;

namespace XYZHotelManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly IHotelServices _context;

        public HotelsController(IHotelServices context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Hotel>>> GetHotels()
        {

            try
            {
                return await _context.GetHotels();

            }
            catch (Exception ex)
            {
                return new BadRequestObjectResult(ex);
            }

        }

        [HttpPost]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<string>> PostHotels(Hotel hotels)
        {
            try
            {
                var res = await _context.PostHotels(hotels);
                return Ok(res);
            }
            catch (ArithmeticException ex)
            {
                return NotFound(ex.Message);

            }

        }


        [HttpGet("ByLocation{location}")]
        public async Task<List<Bufferby>> GetHotelsLocation(string location)
        {

            try
            {
                return await _context.GetHotelsLocation(location);
            }
            catch 
            {
                throw new Exception( "No matches");

            }
        }

        [HttpGet("ByPrice")]
        public async Task<List<Bufferby>> GetHotelsPrice(float Minprice, float Maxprice)
        {
            
            try
            {
   
                return await _context.GetHotelsPrice(Minprice, Maxprice);
            }
            catch 
            {
                throw new Exception("No matches");

            }
        }

        [HttpPut("{id}")]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<List<Hotel>>> PutHotels(int id, Hotel hotels)
        {
            //return await _context.PutHotels(id, hotels);

            try
            {
                var res =  await _context.PutHotels(id, hotels); ;
                return Ok(res);
            }
            catch 
            {
                return BadRequest("No Matches");

            }
        }

        [HttpDelete("{id}")]
        [Authorize(Roles ="admin")]
        public async Task<ActionResult<string>> DeleteHotels(int id)
        {
            try
            {

                return Ok(await _context.DeleteHotels(id)) ;
            }
            catch
            {
                throw new Exception("No matches");

            }
        }

    }
}   

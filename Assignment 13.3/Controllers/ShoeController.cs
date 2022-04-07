using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Assignment_13._3.Models;

namespace Assignment_13._3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoeController : ControllerBase
    {
        
        private List<Shoe> shoe = new List<Shoe>();
        public ShoeController()
        {
            shoe.Add(new Shoe()
            {
                Id = 1,
                Name = "Jordan 11 Concord",
                Size = 9.5M,
                Color = "Black",
                material = Models.Material.Leather
            }); 
        }
        //returns all default shoe data with no values assigned to them
        [HttpGet()]
        public List<Shoe> GetShoe()
        {
            return this.shoe;
        }
        //gets the exact shoe associated with the Id and returns all of the values associated with the data
        [HttpGet("{id}")]
        public ActionResult<Shoe>GetShoebyId(int id)
        {
            var shoe = this.shoe.Find(x=>x.Id == id);
            if(shoe == null)
            {
                return NotFound();
            }
            return Ok(shoe);
        }
    }
}

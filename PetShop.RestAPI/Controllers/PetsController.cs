using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetShop.Core.Entities;
using PetShop.Infrastructure.Data;

namespace PetShop.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetsController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Pet>> Get()
        {
            var pets = new List<Pet>();
            var pet = new Pet();
            pet.Id = 0;
            pet.Name = FakeDB.GenerateName(12);
            pet.Type = FakeDB.GenerateType();
            pet.Color = FakeDB.GenerateColor();
            pet.Birthdate = FakeDB.GenerateDate(new DateTime(1990, 1, 1));
            pet.PreviousOwner = new Owner("Lars", "Madsen", "Kronprinsensgade 143, 6700, Esbjerg", "lars.madsen@gmail.com", "40 37 27 63");
            pet.SoldDate = FakeDB.GenerateDate(pet.Birthdate);
            pet.Price = FakeDB.GeneratePrice(pet.Type);
            pets.Add(pet);
            return pets;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

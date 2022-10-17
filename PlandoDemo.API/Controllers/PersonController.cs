﻿using Microsoft.AspNetCore.Mvc;
using PlandoDemo.API.Models;
using PlandoDemo.API.Repositories;

namespace PlandoDemo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonRepo _personRepo;

        public PersonController(IPersonRepo personRepo)
        {
            _personRepo = personRepo;
        }

        [HttpGet]
        public IActionResult GetAllPeople()
        {
            return Ok(_personRepo.GetPeople());
        }

        [HttpPost("add-person")]
        public IActionResult AddPerson(Person person)
        {
            _personRepo.Add(person);

            return Ok();
        }

        [HttpPost("update-person")]
        public IActionResult UpdatePerson(Person person)
        {
            _personRepo.Update(person);

            return Ok();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using PlandoDemo.MVC.Http;
using PlandoDemo.MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlandoDemo.MVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IHttpPersonApi _httpClient;

        public PersonController(IHttpPersonApi httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<Person> people = await _httpClient.GetPeopleAsync();
            return View(people);
        }

        [HttpGet("add-person")]
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddPersonAsync(Person person)
        {
            await _httpClient.AddPersonToAPIAsync(person);
            return Redirect("[controller]");
        }

        [HttpGet("get-person")]
        public async Task<IActionResult> GetPersonAsync(int id)
        {
            Person person = await _httpClient.GetPersonAsync(id);
            return View(person);
        }

        [HttpGet("update-person")]
        public async Task<IActionResult> UpdateAsync(int id)
        {
            Person person = await _httpClient.GetPersonAsync(id);
            return View(person);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(Person person)
        {
            await _httpClient.UpdatePersonAsync(person);
            return Redirect("[controller]");
        }
    }
}

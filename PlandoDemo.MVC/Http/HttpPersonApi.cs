using Microsoft.Extensions.Configuration;
using PlandoDemo.MVC.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PlandoDemo.MVC.Http
{
    public class HttpPersonApi : IHttpPersonApi
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;

        public HttpPersonApi(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task AddPersonToAPIAsync(Person person)
        {
            StringContent httpContent = new StringContent(
                    JsonSerializer.Serialize(person),
                    Encoding.UTF8,
                    "application/json"
                );

            HttpResponseMessage response = await _httpClient.PostAsync(_configuration["AddPerson"], httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to PlandoDemo.API was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync POST to PlandoDemo.API was NOT OK!");
            }
        }

        public async Task<IEnumerable<Person>> GetPeopleAsync()
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_configuration["GetPeople"]);

            string result = await response.Content.ReadAsStringAsync();
            
            IEnumerable<Person> people = JsonSerializer.Deserialize<IEnumerable<Person>>(result, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync GET to PlandoDemo.API was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync GET to PlandoDemo.API was NOT OK!");
            }

            return people;
        }

        public async Task<Person> GetPersonAsync(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync(_configuration["GetPerson"] + "/" + id);

            Person person = JsonSerializer.Deserialize<Person>(await response.Content.ReadAsStringAsync(), new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync GET to PlandoDemo.API was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync GET to PlandoDemo.API was NOT OK!");
            }

            return person;
        }

        public async Task UpdatePersonAsync(Person person)
        {
            StringContent httpContent = new StringContent(
                    JsonSerializer.Serialize(person),
                    Encoding.UTF8,
                    "application/json"
                );

            HttpResponseMessage response = await _httpClient.PostAsync(_configuration["UpdatePerson"], httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to PlandoDemo.API was OK!");
            }
            else
            {
                Console.WriteLine("--> Sync POST to PlandoDemo.API was NOT OK!");
            }
        }
    }
}

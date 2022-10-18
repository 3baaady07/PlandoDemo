using PlandoDemo.MVC.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PlandoDemo.MVC.Http
{
    public interface IHttpPersonApi
    {
        Task AddPersonToAPIAsync(Person person);
        Task<IEnumerable<Person>> GetPeopleAsync();
        Task<Person> GetPersonAsync(int id);
        Task UpdatePersonAsync(Person person);
    }
}
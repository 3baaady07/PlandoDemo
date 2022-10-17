using PlandoDemo.API.Models;
using System.Collections.Generic;

namespace PlandoDemo.API.Repositories
{
    public interface IPersonRepo
    {
        IEnumerable<Person> GetPeople();
        void Add(Person person);
        void Update(Person person);
    }
}
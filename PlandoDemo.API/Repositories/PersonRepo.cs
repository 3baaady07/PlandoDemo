using PlandoDemo.API.Data;
using PlandoDemo.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace PlandoDemo.API.Repositories
{
    public class PersonRepo : IPersonRepo
    {
        private readonly PersonDbContext _context;

        public PersonRepo(PersonDbContext context)
        {
            _context = context;
        }

        public void Add(Person person)
        {
            _context.People.Add(person);
            _context.SaveChanges();
        }

        public IEnumerable<Person> GetPeople()
        {
            return _context.People.ToList();
        }

        public Person GetPerson(int id)
        {
            return _context.People.Where(p => p.Id == id).FirstOrDefault();
        }

        public void Update(Person person)
        {
            try
            {
                _context.People.Update(person);
                _context.SaveChanges();

            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }
}

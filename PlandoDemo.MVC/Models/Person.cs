using System.ComponentModel.DataAnnotations;

namespace PlandoDemo.MVC.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Address { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaCRUD.Persons.Creates
{
    public class CreatePersonRequest
    {
        public const string Route = "/persons";

        [Required]
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime Created_Date { get; set; } = DateTime.Now;
    }
}

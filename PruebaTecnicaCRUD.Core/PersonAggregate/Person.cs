using Ardalis.GuardClauses;
using Ardalis.SharedKernel;
using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaCRUD.Core.PersonAggregate
{
    public class Person : IAggregateRoot
    {
        [Key]
        public int id_person { get; set; }
        public string Name { get; private set; }
        public string Lastname { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime? Created_Date { get; set; }
        public DateTime? Last_Modified_Date { get; set; }

        public Person(string name, string lastname, string identification, string email, string phone, string address)
        {
            Name = Guard.Against.NullOrEmpty(name, nameof(name));
            Lastname = Guard.Against.NullOrEmpty(lastname, nameof(lastname));
            Identification = Guard.Against.NullOrEmpty(identification, nameof(identification));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));
            Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
            Address = Guard.Against.NullOrEmpty(address, nameof(address));
            Created_Date = DateTime.Now;
        }

        public void UpdateName(string newName, string newLastname, string identification, string email, string phone, string address)
        {
            Name = Guard.Against.NullOrEmpty(newName, nameof(newName));
            Lastname = Guard.Against.NullOrEmpty(newLastname, nameof(newLastname));
            Identification = Guard.Against.NullOrEmpty(identification, nameof(identification));
            Email = Guard.Against.NullOrEmpty(email, nameof(email));
            Phone = Guard.Against.NullOrEmpty(phone, nameof(phone));
            Address = Guard.Against.NullOrEmpty(address, nameof(address));
            Last_Modified_Date = DateTime.Now;
        }
    }
}

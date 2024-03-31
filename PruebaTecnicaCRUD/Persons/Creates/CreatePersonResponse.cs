namespace PruebaTecnicaCRUD.Persons.Creates
{
    public class CreatePersonResponse
    {
        public CreatePersonResponse(int id, string name, string lastname, string identification, string email, string phone, string address)
        {
            Id = id;
            Name = name;
            LastName = lastname;
            Identification = identification;
            Email = email;
            Phone = phone;
            Address = address;

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Identification { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}

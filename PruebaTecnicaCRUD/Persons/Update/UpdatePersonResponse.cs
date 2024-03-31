using PruebaTecnicaCRUD.Persons;

namespace PruebaTecnicaCRUD.Persons;

public class UpdatePersonResponse
{
    public UpdatePersonResponse(PersonRecord person)
    {
        Person = person;
    }
    public PersonRecord Person { get; set; }
}

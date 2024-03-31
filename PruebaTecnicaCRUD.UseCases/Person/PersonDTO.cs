
namespace PruebaTecnicaCRUD.UseCases.Person;

public record PersonDTO(
     int Id
    , string Name
    , string LastName
    , string? Identification
    , string? Email
    , string? Phone
    , string? Address
    , DateTime? Created_Date
    , DateTime? Last_Modified_Date
    );



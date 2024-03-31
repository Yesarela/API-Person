namespace PruebaTecnicaCRUD.Persons;

public record PersonRecord(int Id, string Name, string LastName, string? Identification, string? Email, string? Phone, string? Address, DateTime? Created_Date, DateTime? Last_Modified_Date);

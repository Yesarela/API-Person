using System.ComponentModel.DataAnnotations;

namespace PruebaTecnicaCRUD.Persons;

public class UpdatePersonRequest
{
    public const string Route = "/persons/{PersonId:int}";
    public static string BuildRoute(int PersonId) => Route.Replace("{PersonId:int}", PersonId.ToString());

    [Required]
    public int PersonId { get; set; }

    [Required]
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public string Identification { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public DateTime Last_Modified_Date { get; set; } = DateTime.Now;
}

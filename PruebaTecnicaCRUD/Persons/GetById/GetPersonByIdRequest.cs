namespace PruebaTecnicaCRUD.Persons.GetById
{
    public class GetPersonByIdRequest
    {
        public const string Route = "/persons/{PersonId:int}";
        public static string BuildRoute(int personId) => Route.Replace("{PersonId:int}", personId.ToString());

        public int PersonId { get; set; }
    }
}

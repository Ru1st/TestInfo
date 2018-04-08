namespace TestInfoTecs.Models
{
    public class CitiesRepos : BaseRepo<City>
    {
        public CitiesRepos() => Table = Context.Cities;
    }
}
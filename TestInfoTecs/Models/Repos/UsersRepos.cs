namespace TestInfoTecs.Models
{
    public class UsersRepos : BaseRepo<User>
    {
        public UsersRepos() => Table = Context.Users;
    }
}
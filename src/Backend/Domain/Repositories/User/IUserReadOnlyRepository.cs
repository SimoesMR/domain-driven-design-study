namespace Domain.Repositories.User
{
    public interface IUserReadOnlyRepository
    {
        public Task<bool> ExisteActiveUserWithEmail(string email);
    }
}

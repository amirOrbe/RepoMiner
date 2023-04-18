using RepoMinerAnalysis.Models.Domain;

namespace RepoMinerWeb.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(Guid id);
        User Create(User user);
        User? Delete(Guid id);
        User Update(Guid id, User user);
    }
}

using RepoMinerAnalysis.Models.Domain;

namespace RepoMinerWeb.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync();
    }
}

using RepoMinerAnalysis.Models.Domain;
using RepoMinerAnalysis.Data;
using Microsoft.EntityFrameworkCore;

namespace RepoMinerWeb.Repositories
{
    public class SqlUserRepository : IUserRepository
    {
        private readonly RepoMinerDbContext dbContext;

        public SqlUserRepository(RepoMinerDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await dbContext.Users.ToListAsync();
        }
    }
}

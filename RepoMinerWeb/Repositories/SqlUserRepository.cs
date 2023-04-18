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

        public User Create(User user)
        {
            dbContext.Add(user);
            dbContext.SaveChanges();
            return user;
        }

        public User? Delete(Guid id)
        {
            var existingUser = dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (existingUser == null) return null;

            dbContext.Users.Remove(existingUser);
            dbContext.SaveChanges();
            return existingUser;
        }

        public List<User> GetAll()
        {
            return dbContext.Users.Include("Role").ToList();
        }

        public User? GetById(Guid id)
        {
            var user = dbContext.Users.Include("Role").FirstOrDefault(u => u.Id == id);
            if (user == null) return null;
            return user;
        }

        public User? Update(Guid id, User user)
        {
            var existingUser = dbContext.Users.FirstOrDefault(x => x.Id == id);

            if (existingUser == null) return null;

            existingUser.Name = user.Name;
            existingUser.UserName = user.UserName;
            existingUser.Email = user.Email;
            existingUser.RoleId = user.RoleId;

            dbContext.SaveChanges();
            return existingUser;
        }
    }
}

using System.Data;
using RepoMinerAnalysis.Models.Domain;


namespace RepoMinerWeb.Models.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }

        public Roles Role { get; set; }
    }
}

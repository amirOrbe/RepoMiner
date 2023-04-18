namespace RepoMinerWeb.Models.DTO
{
    public class UpdateUserDto
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }
    }
}

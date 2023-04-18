using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RepoMinerAnalysis.Models.Domain
{
    public class User
    {
        //Nombre(e.g.Agustín Ramos)
        //Nombre de Usuario(e.g.MachinesAreUs)
        //Email(e.g.agustin @bunsan.io)
        //Role(admin, collaborator)

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public Guid RoleId { get; set; }

        public Roles Role { get; set; }
    }
}

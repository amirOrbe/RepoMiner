using AutoMapper;
using RepoMinerAnalysis.Models.Domain;
using RepoMinerWeb.Models.DTO;

namespace RepoMinerWeb.Mapping
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}

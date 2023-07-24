using AutoMapper;
using JornadaMilhasAPI.Dtos;
using JornadaMilhasAPI.Models;

namespace JornadaMilhasAPI.Profiles
{
    public class DepoimentoProfile:Profile
    {
        public DepoimentoProfile()
        {
            CreateMap<DepoimentoDto,Depoimento>().ReverseMap();
        }
    }
}

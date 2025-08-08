using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Spa.Models;
using SpaAPI.Dtos;

namespace SpaAPI.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Cliente, ClienteDTO>().ReverseMap();
            CreateMap<Cliente, ClienteDetalhesDto>().ReverseMap();

            CreateMap<Serviço, ServicoDTO>().ReverseMap();
        }
    }
}
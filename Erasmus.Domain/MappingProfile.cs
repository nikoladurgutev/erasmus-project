using AutoMapper;
using Erasmus.Domain.DomainModels;
using Erasmus.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Erasmus.Domain
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<NonGovProject, CreateNonGovProjectDto>()
                .ForMember(z => z.SelectedCityId, o => o.MapFrom(z => z.CityId));
            CreateMap<CreateNonGovProjectDto, NonGovProject>()
                .ForMember(z => z.CityId, o => o.MapFrom(z => z.SelectedCityId));
        }
    }
}

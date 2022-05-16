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
            CreateMap<NonGovProject, NonGovProjectDto>()
                .ForMember(z => z.SelectedCityId, o => o.MapFrom(z => z.CityId))
                .ForMember(z => z.ProjectId, o => o.MapFrom(z => z.Id));
            CreateMap<NonGovProjectDto, NonGovProject>()
                .ForMember(z => z.CityId, o => o.MapFrom(z => z.SelectedCityId));

            CreateMap<NonGovProject, ProjectDetailsDto>()
                 .ForMember(z => z.SelectedCityId, o => o.MapFrom(z => z.CityId))
                 .ForMember(z => z.ProjectId, o => o.MapFrom(z => z.Id));
        }
    }
}

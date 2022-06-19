using AutoMapper;
using Erasmus.Domain.Domain;
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

            CreateMap<NonGovProject, ApplyToEventDto>()
                .ForMember(z => z.ProjectId, o => o.MapFrom(z => z.Id));

            CreateMap<ErasmusUser, OrganizerProfileDto>()
                .ForMember(z => z.Location, o => o.Ignore())
                .ForMember(z => z.OrganizationContact, o => o.Ignore())
                .ForMember(z => z.OrganizerId, o => o.Ignore())
                .ForMember(z => z.ProfilePicture , o=> o.MapFrom(z => z.Photo));

            CreateMap<ErasmusUser, ParticipantProfileDto>()
                .ForMember(z => z.ParticipantId, o => o.Ignore())
                .ForMember(z => z.ProfilePicture, o => o.MapFrom(z=>z.Photo));

            CreateMap<Organizer, OrganizerProfileDto>()
                .ForMember(z => z.OrganizerId, o => o.MapFrom(z => z.UserId));

            CreateMap<Participant, ParticipantProfileDto>()
               .ForMember(z => z.ParticipantId, o => o.MapFrom(z => z.UserId));

            CreateMap<OrganizerProfileDto, Organizer>();
            CreateMap<ParticipantProfileDto, Participant>();

            CreateMap<OrganizerProfileDto, ErasmusUser>()
                .ForMember(z => z.OrganizerId, o => o.Ignore());
            CreateMap<ParticipantProfileDto, ErasmusUser>()
                .ForMember(z => z.ParticipantId, o => o.Ignore());
        }
    }
}

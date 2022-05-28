using AutoMapper;
using HelpDesk.Domain.Entities;
using HelpDesk.Domain.Responses;

namespace HelpDesk.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Ticket, TicketResponse>()
                .ForMember(d => d.State, o => o.MapFrom(s => s.State.Name))
                .ForMember(d => d.Source, o => o.MapFrom(s => s.Source.Name))
                .ForMember(d => d.Priority, o => o.MapFrom(s => s.Priority.Name))
                .ForMember(d => d.Group, o => o.MapFrom(s => s.Group.Name))
                .ForMember(d => d.Type, o => o.MapFrom(s => s.Type.Name))
                .ForMember(d => d.AgentEmail, o => o.MapFrom(s => s.Agent.Email))
                .ForMember(d => d.AgentFullName, o => o.MapFrom(s => $"{s.Agent.FirstName} {s.Agent.LastName}"));
        }
    }
}

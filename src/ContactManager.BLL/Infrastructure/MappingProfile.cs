using AutoMapper;
using ContactManager.BLL.DTO;
using ContactManager.DAL.Entities;

namespace ContactManager.BLL.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Contact, ContactDto>();
            CreateMap<ContactDto, Contact>();
        }
    }
}

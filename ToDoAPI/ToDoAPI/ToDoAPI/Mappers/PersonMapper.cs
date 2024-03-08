using API.Data.Models;
using API.DataTransferObjects;
using AutoMapper;

namespace API.Mappers
{
    public class PersonMapper : Profile
    {
        public PersonMapper() 
        {
            CreateMap<Person, GetPersonDTO>();
            CreateMap<InsertUpdatePersonDTO, Person>();
        }
    }
}

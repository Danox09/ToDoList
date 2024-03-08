using API.Data.Models;
using API.DataTransferObjects;
using AutoMapper;

namespace API.Mappers
{
    public class AssingmnentMapper : Profile
    {
        public AssingmnentMapper()
        {
            CreateMap<Assignment, GetAssignmentDTO>();
            CreateMap<InsertUpdateAssignmentDTO, Assignment>();
        }
    }
}

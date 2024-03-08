using API.Data.Models;
using API.DataTransferObjects;
using AutoMapper;

namespace API.Mappers
{
    public class AssignmentStatusMapper : Profile
    {
        public AssignmentStatusMapper()
        {
            CreateMap<AssignmentStatus, GetAssignmentStatusDTO>();
        }
    }
}

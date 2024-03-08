using API.Data.Models;
using API.DataTransferObjects;

namespace API.Services.AssignmentService
{
    public interface IAssignmentService
    {
        IQueryable<Assignment> ListAssignments(int id);
        Task<Assignment?> FindAssignment(int id);
        Task InsertAssignment(Assignment entity);
        Task UpdateAssignment(Assignment entity);
    }
}

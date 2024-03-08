using API.Data;
using API.Data.Models;
using API.DataTransferObjects;
using Microsoft.EntityFrameworkCore;

namespace API.Services.AssignmentService
{
    public class AssignmentService : IAssignmentService
    {
        private readonly ToDoDB _database;
        public AssignmentService(ToDoDB database)
        {
            this._database = database;
        }
        public IQueryable<Assignment> ListAssignments(int id)
        {
            return this._database.Assignment
            .Include(a => a.Person)
            .Include(a => a.Status)
            .Where(a => a.PersonId == id);
        }
        public async Task<Assignment?> FindAssignment(int id)
        {
            return await this._database
                              .Assignment
                              .Include(a => a.Status)
                              .Include(a => a.Person)
                              .Include(a => a.Status)
                              .FirstOrDefaultAsync(a => a.Id == id);
        }
        public async Task InsertAssignment(Assignment entity)
        {
            this._database.Assignment.Add(entity);
            await this._database.Entry(entity).Reference(a => a.Status).LoadAsync();
            await this._database.Entry(entity).Reference(a => a.Person).LoadAsync();
            await this._database.SaveChangesAsync();
        }
        public async Task UpdateAssignment(Assignment entity)
        {
            this._database.Assignment.Update(entity);
            await this._database.SaveChangesAsync();
        }

    }
}
using API.Data;
using API.Data.Models;
using API.Services.AssignmentService;
using Microsoft.EntityFrameworkCore;

namespace API.Services.PersonService
{
    public class PersonService : IPersonService
    {
        private readonly ToDoDB _database;
        private readonly IAssignmentService _assignmentService;

        public PersonService(ToDoDB database, IAssignmentService assignmentService)
        {
           this. _database = database;
            this._assignmentService = assignmentService;

        }
        public IQueryable<Person> ListPersons()
        {
            return this._database.Person;
        }

        public async Task<Person?> FindPerson(int id)
        {
            return await this._database
                              .Person
                              .FirstOrDefaultAsync(p => p.Id == id);
        }
        public async Task InsertPerson(Person entity)
        {
           this._database.Person.Add(entity);
           await this._database.SaveChangesAsync();
        }
        public async Task UpdatePerson(Person entity)
        {
            this._database.Person.Update(entity);
            await this._database.SaveChangesAsync();
        }
        public async Task DeletePerson(Person entity, bool loadAssignments = false)
        {
            // Use the ListAssignments function to check if the person has assignments

            if(loadAssignments)
            {
                await this._database.Entry(entity).Collection(p => p.Assignment).LoadAsync();
            }

            foreach (Assignment assignment in entity.Assignment)
            {
                this._database.Assignment.Remove(assignment);
            }

            // Delete the person
            _database.Person.Remove(entity);
            await _database.SaveChangesAsync();
        }
    }
}

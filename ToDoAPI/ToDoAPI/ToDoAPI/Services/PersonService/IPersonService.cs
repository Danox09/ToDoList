using API.Data;
using API.Data.Models;


namespace API.Services.PersonService
{
    public interface IPersonService
    {
        IQueryable<Person> ListPersons();
        Task<Person> FindPerson(int id);
        Task InsertPerson(Person entity);
        Task UpdatePerson(Person entity);
        Task DeletePerson(Person entity, bool loadAssignments = false);
    }
}

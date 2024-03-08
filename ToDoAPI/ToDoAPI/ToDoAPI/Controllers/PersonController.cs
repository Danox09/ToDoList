using API.Data.Models;
using API.DataTransferObjects;
using API.Services.PersonService;
using API.Validators;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/persons")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IPersonService _personService;
        private readonly IPersonValidator _personValidator;

        public PersonController(IMapper mapper, IPersonService personService, IPersonValidator personValidator)
        {
            this._mapper = mapper;
            this._personService = personService;
            this._personValidator = personValidator;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListPerson()
        {
            List<Person> list = await this._personService
                                            .ListPersons()
                                            .ToListAsync();

            APIResponse response = new()
            {
                Data = list.Select(p => this._mapper.Map<Person, GetPersonDTO>(p))
            };

            return response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> FindPerson(int id)
        {
            Person? person = await this._personService.FindPerson(id);
            if (person == null)
            {
                return HttpErrors.NotFound("Persona no existe en el sistema");
            }
            APIResponse response = new()
            {
                Data = this._mapper.Map<Person, GetPersonDTO>(person)
            };

            return response;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> InsertPerson(InsertUpdatePersonDTO data)
        {
            APIResponse response = new();
            response.Success = this._personValidator.ValidateInsert(data, response.Messages);

            if (response.Success)
            {
                Person person = this._mapper.Map<InsertUpdatePersonDTO, Person>(data);
                await this._personService.InsertPerson(person);

                response.Data = this._mapper.Map<Person, GetPersonDTO>(person);
                response.Messages.Add("Persona ha sido insertada");
            }
            return response;
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> UpdatePerson(int id, InsertUpdatePersonDTO data)
        {
            Person? person = await this._personService.FindPerson(id);
            if (person == null)
            {
                return HttpErrors.NotFound("Persona no existe en el sistema");
            }

            APIResponse response = new();
            response.Success = this._personValidator.ValidateUpdate(data, response.Messages);

            if (response.Success)
            {
                await this._personService.UpdatePerson(this._mapper.Map(data, person));
                response.Data = this._mapper.Map<Person, GetPersonDTO>(person);
                response.Messages.Add("Persona ha sido actualizada");
            }
            return response;
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<APIResponse>> DeletePerson(int id)
        {
            Person? person = await this._personService.FindPerson(id);
            if (person == null)
            {
                return HttpErrors.NotFound("Persona no existe en el sistema");
            }

            APIResponse response = new();
            await this._personService.DeletePerson(person, true);
            response.Data = this._mapper.Map<Person, GetPersonDTO>(person);
            response.Messages.Add("Persona ha sido borrada");

            return response;
        }

    }
}
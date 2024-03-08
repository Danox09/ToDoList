using API.Data.Models;
using API.DataTransferObjects;
using API.Services.AssignmentService;
using API.Services.PersonService;
using API.Validators;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace API.Controllers
{
    [Route("api/persons/{userId}/tasks")]
    [ApiController]
    public class AssignmentController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAssignmentService _assignmentService;
        private readonly IAssignmentValidator _assignmentValidator;
        private readonly IPersonService _personService;

        public AssignmentController(IMapper mapper, IAssignmentService assignmentService, IAssignmentValidator assingmentValidator, IPersonService personService)
        {
            this._mapper = mapper;
            this._assignmentService = assignmentService;
            this._assignmentValidator = assingmentValidator;
            this._personService = personService;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> ListAssignments(int userId)
        {
            Person? person = await this._personService.FindPerson(userId);
            if (person == null)
            {
                return HttpErrors.NotFound("Persona no existe en el sistema");
            }
            List<Assignment> list = await this._assignmentService
                                            .ListAssignments(userId)
                                            .ToListAsync();

            APIResponse response = new()
            {
                Data = list.Select(a => this._mapper.Map<Assignment, GetAssignmentDTO>(a))
            };
            return response;
        }

        [HttpGet]
        [Route("{taskId}")]
        public async Task<ActionResult<APIResponse>> FindAssingment(int taskId, int userId)
        {
            Person? person = await this._personService.FindPerson(userId);
            if (person == null)
            {
                return HttpErrors.NotFound("Persona no existe en el sistema");
            }
            Assignment? assignment = await this._assignmentService.FindAssignment(taskId);
            if (assignment == null || assignment.PersonId != userId)
            {
                return HttpErrors.NotFound("Tarea no existe en el sistema o pertenece a otro usuario");
            }
            APIResponse response = new()
            {
                Data = this._mapper.Map<Assignment?, GetAssignmentDTO>(assignment)
            };

            return response;
        }

        [HttpPost]
        public async Task<ActionResult<APIResponse>> InsertAssingment(InsertUpdateAssignmentDTO data, int userId)
        {
            Person? person = await this._personService.FindPerson(userId);
            if (person == null)
            {
                return HttpErrors.NotFound("Persona no existe en el sistema");
            }
            APIResponse response = new();
            response.Success = this._assignmentValidator.ValidateInsert(data, response.Messages);

            if (response.Success)
            {
                data.StatusId = 1;
                data.PersonId = userId;
                Assignment assignment = this._mapper.Map<InsertUpdateAssignmentDTO, Assignment>(data);
                await this._assignmentService.InsertAssignment(assignment);

                response.Data = this._mapper.Map<Assignment, GetAssignmentDTO>(assignment);
                response.Messages.Add("Tarea ha sido insertada");
            }
            return response;
        }

        [HttpPut]
        [Route("{taskId}")]
        public async Task<ActionResult<APIResponse>> UpdateAssignment(int taskId, int userId, InsertUpdateAssignmentDTO data)
        {
            Person? person = await this._personService.FindPerson(userId);
            if (person == null)
            {
                return HttpErrors.NotFound("Persona no existe en el sistema");
            }

            Assignment? assignment = await this._assignmentService.FindAssignment(taskId);
            if (assignment == null || assignment.PersonId != userId)
            {
                return HttpErrors.NotFound("Tarea no existe en el sistema o pertenece a otro usuario");
            }

            APIResponse response = new();
            response.Success = this._assignmentValidator.ValidateUpdate(data, response.Messages);

            if (response.Success)
            {
                data.PersonId = userId;
                await this._assignmentService.UpdateAssignment(this._mapper.Map(data, assignment));
                response.Data = this._mapper.Map<Assignment, GetAssignmentDTO>(assignment);
                response.Messages.Add("Tarea ha sido actualizada");
            }
            return response;
        }
    }
}
        

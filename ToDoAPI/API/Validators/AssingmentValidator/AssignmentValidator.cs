using API.Data;
using API.DataTransferObjects;

namespace API.Validators.AssingmentValidator
{
    public class AssignmentValidator : IAssignmentValidator
    {
        private readonly ToDoDB _database;

        public AssignmentValidator(ToDoDB database)
        {
            this._database = database;
        }

        public bool ValidateInsert(InsertUpdateAssignmentDTO data, List<string> messages)
        {
            List<string> innerMessages = new();
            //PersonId

            //AssignmentName
            if (string.IsNullOrWhiteSpace(data.AssignmentName))
            {
                innerMessages.Add("Nombre es requerido");
            }
            else if (data.AssignmentName.Length > 50)
            {
                innerMessages.Add("Nombre no puede contener más de 50 caracteres");
            }
            //AssignmentDescription
            if (string.IsNullOrWhiteSpace(data.AssignmentDescription))
            {
                innerMessages.Add("Descripción es requerida");
            }
            else if (data.AssignmentDescription.Length > 300)
            {
                innerMessages.Add("Descripción no puede contener más de 50 caracteres");
            }
            //AssignmentDate
            if (data.AssignmentDate == null)
            {
                innerMessages.Add("Fecha es requerida");
            }
            else if (data.AssignmentDate <= DateTime.Now)
            {
                innerMessages.Add("Tarea no puede tener una fecha anterior a la fecha actual");
            }

            messages.AddRange(innerMessages);
            return !innerMessages.Any();
        }

        public bool ValidateUpdate(InsertUpdateAssignmentDTO data, List<string> messages)
        {
            List<string> innerMessages = new();

            //AssignmentName
            if (string.IsNullOrWhiteSpace(data.AssignmentName))
            {
                innerMessages.Add("Nombre es requerido");
            }
            else if (data.AssignmentName.Length > 50)
            {
                innerMessages.Add("Nombre no puede contener más de 50 caracteres");
            }
            //AssignmentDescription
            if (string.IsNullOrWhiteSpace(data.AssignmentDescription))
            {
                innerMessages.Add("Descripción es requerida");
            }
            else if (data.AssignmentDescription.Length > 300)
            {
                innerMessages.Add("Descripción no puede contener más de 50 caracteres");
            }
            //AssignmentDate
            if (data.AssignmentDate == null)
            {
                innerMessages.Add("Fecha es requerida");
            }
            else if (data.AssignmentDate <= DateTime.Now)
            {
                innerMessages.Add("Tarea no puede tener una fecha anterior a la fecha actual");
            }
            //AssignmentStatus
            if (!data.StatusId.HasValue)
            {
                innerMessages.Add("Estatus es requerido");
            }
            else if (!this._database.AssignmentStatus.Any(s => s.Id == data.StatusId))
            {
                innerMessages.Add("Debe seleccionar un estatus que exista en el sistema");
            }
            messages.AddRange(innerMessages);
            return !innerMessages.Any();
        }
    }
}
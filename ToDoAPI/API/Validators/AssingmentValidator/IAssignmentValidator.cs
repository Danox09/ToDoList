using API.DataTransferObjects;

namespace API.Validators
{
    public interface IAssignmentValidator
    {
        bool ValidateInsert(InsertUpdateAssignmentDTO data, List<string> messages);

        bool ValidateUpdate(InsertUpdateAssignmentDTO data, List<string> messages);
    }
}

using API.DataTransferObjects;

namespace API.Validators
{
    public interface IPersonValidator
    {
        bool ValidateInsert(InsertUpdatePersonDTO data, List<string> messages);
        bool ValidateUpdate(InsertUpdatePersonDTO data, List<string> messages);
    }
}

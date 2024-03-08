namespace API.DataTransferObjects
{
    public class GetPersonDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public int Id { get; set; }


    }

    public class InsertUpdatePersonDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}

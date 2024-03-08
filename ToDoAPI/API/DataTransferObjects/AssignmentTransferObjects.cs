namespace API.DataTransferObjects
{
    public class GetAssignmentDTO
    {
        public int Id { get; set; }
        public string? AssignmentName { get; set; }
        public string? AssignmentDescription { get; set; }
        public DateTime AssignmentDate { get; set; }
        public GetAssignmentStatusDTO? Status { get; set; }
        public GetPersonDTO? Person { get; set; }
    }
    public class InsertUpdateAssignmentDTO
    {
        public string? AssignmentName { get; set;}
        public string? AssignmentDescription { get; set;}
        public DateTime? AssignmentDate { get; set; }
        public int? StatusId { get; set; } 
        public int? PersonId { get; set; }
    }
}
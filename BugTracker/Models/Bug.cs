namespace BugTracker.Models
{
    public class Bug
    {
        public Guid Id { get; set; }
        public string? Project { get; set; }
        public string? Type { get; set; }
        public string? Assignee { get; set; }
        public string? Reporter { get; set; }
        public string? State { get; set; }
        public string? Priority { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public DateTime? Date { get; set; }
    }
}

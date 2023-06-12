namespace BugTracker.Models
{
    public class Project
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Bug> Bugs { get; set; }
    }
}

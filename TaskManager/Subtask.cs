namespace TaskManager
{
    public class Subtask
    {
        public int Id { get; }
        public string Description { get; }
        public bool IsCompleted { get; set; }

        public Subtask(int id, string description)
        {
            Id = id;
            Description = description;
        }
    }
}
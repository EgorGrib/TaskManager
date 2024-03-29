using System.Collections.Generic;

namespace TaskManager
{
    public class TaskGroup
    {
        public int Id { get; }
        public string Title { get; }
        public List<Task> Tasks { get; }

        public TaskGroup(int id, string title)
        {
            Id = id;
            Title = title;
            Tasks = new List<Task>();
        }
    }
}
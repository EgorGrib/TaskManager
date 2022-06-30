using System;
using System.Collections.Generic;

namespace TaskManager
{
    public class Task
    {
        public int Id { get; }
        public string Description { get; }
        public bool IsCompleted { get; set; }
        public DateTime Deadline { get; set; }
        public List<Subtask> Subtasks { get; set; }

        public Task(int id, string description)
        {
            Id = id;
            Description = description;
            Subtasks = new List<Subtask>();
            Deadline = DateTime.MaxValue;
        }

        /*
        public void Print()
        {
            var checkbox = IsCompleted ? "[x]" : "[ ]";
            Console.WriteLine($"{checkbox} ({Deadline:dd.MM.yyyy}) {{{Id}}} {Description}");
            foreach (var subTask in Subtasks)
            {
                Console.WriteLine($"\t[ ] {{{subTask.Id}}} {subTask.Description}");
            }
        }
        */
    }
}
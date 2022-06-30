using System;
using System.Collections.Generic;

namespace TaskManager
{
    public class TaskGroup
    {
        public int Id { get; }
        public string Title { get; }
        public List<Task> Tasks { get; set; }

        public TaskGroup(int id, string title)
        {
            Id = id;
            Title = title;
            Tasks = new List<Task>();
        }
        
        /*
        public void Print()
        {
            Console.WriteLine("Group: " + Title);
            foreach (var t in Tasks)
            {
                t.Print();
            }
        }
        */
    }
}
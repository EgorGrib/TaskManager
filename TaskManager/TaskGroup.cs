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
        public void AddToGroup(Task task)
        {
            Tasks.Add(task);
        }

        public void DeleteFromGroup(int id)
        {
            for (int i = 0; i < Tasks.Count; i++)
            {
                if (Tasks[i].Id == id)
                {
                    Tasks.RemoveAt(i);
                }
            }
        }*/

        public void Print()
        {
            Console.WriteLine("Group: " + Title);
            foreach (var t in Tasks)
            {
                t.Print();
            }
        }
    }
}
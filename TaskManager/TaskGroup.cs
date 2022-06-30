using System;
using System.Collections.Generic;

namespace TaskManager
{
    public class TaskGroup
    {
        private readonly int _id;
        public int Id => _id;
        private readonly string _title;
        private List<Task> _tasks = new List<Task>();

        public TaskGroup(int id, string title)
        {
            _id = id;
            _title = title;
        }

        public void AddToGroup(Task task)
        {
            _tasks.Add(task);
        }

        public void DeleteFromGroup(int id)
        {
            for (int i = 0; i < _tasks.Count; i++)
            {
                if (_tasks[i].Id == id)
                {
                    _tasks.RemoveAt(i);
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("Group: " + _title);
            foreach (var t in _tasks)
            {
                t.Print();
            }
        }
    }
}
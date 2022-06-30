using System;
using System.Collections.Generic;

namespace TaskManager
{
    public class Task
    {
        private readonly int _id;
        public int Id => _id;
        private readonly string _information;
        private bool _isCompleted = false;
        private DateTime _deadline = DateTime.MaxValue;
        public List<Subtask> subtasks = new List<Subtask>();

        public Task(int id, string information)
        {
            this._id = id;
            this._information = information;
        }

        public void MarkCompleted()
        {
            _isCompleted = true;
        }

        public void AddDeadline(DateTime deadline)
        {
            _deadline = deadline;
        }

        public void AddSubtask(int id, string information)
        {
            subtasks.Add(new  Subtask(id, information));
        }

        public void Print()
        {
            var checkbox = _isCompleted ? "[x]" : "[ ]";
            Console.WriteLine($"{checkbox} ({_deadline:dd.MM.yyyy}) {{{_id}}} {_information}");
            foreach (var subTask in subtasks)
            {
                Console.WriteLine($"\t[ ] {{{subTask.Id}}} {subTask.Info}");
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace TaskManager
{
    public class Commander
    {
        private List<Task> _tasks;
        private List<TaskGroup> _groups;
        private int _id;
        private int _groupId;

        public Commander()
        {
            _id = 1;
            _groupId = 1;
            _tasks = new List<Task>();
            _groups = new List<TaskGroup>();
        }

        public void AddTask(string taskTitle)
        {
            Task task = new Task(_id, taskTitle);
            _tasks.Add(task);
            _id++;
        }

        public void AddSubtask(int id, string subtaskTitle)
        {
            Task task = _tasks.First(x => x.Id == id);
            Subtask subtask = new Subtask(_id, subtaskTitle);
            task.Subtasks.Add(subtask);
            _id++;
        }

        public void DeleteTask(int id)
        {
            _tasks.Remove(_tasks.First(x => x.Id == id));
        }

        public void CompleteTask(int id)
        {
            _tasks.First(x => x.Id == id).IsCompleted = true;
        }

        public void CompleteSubtask(int id)
        {
            _tasks.Select(x => x.Subtasks.First(y => y.Id == id)).First().IsCompleted = true;
        }

        public string IsSubtask(int id)
        {
            if (_tasks.Find(x => x.Id == id) != null) return "false";
            foreach (var task in _tasks)
            {
                foreach (var subtask in task.Subtasks)
                {
                    if (subtask.Id == id)
                    {
                        return "true";
                    }
                }
            }
            return "not founded";

        }

        public void CreateGroup(string title)
        {
            _groups.Add(new TaskGroup(_groupId, title));
            _groupId++;
        }

        public void DeleteGroup(int groupId)
        {
            _groups.Remove(_groups.First(x => x.Id == _groupId));
        }

        public void AddToGroup(int groupId, int id)
        {
            _groups.First(x => x.Id == groupId).Tasks.Add(_tasks.First(x => x.Id == id));
        }

        public void DeleteFromGroup(int groupId, int id)
        {
            _groups.First(x => x.Id == groupId).Tasks.Remove(_tasks.First(x => x.Id == id));
        }

        public void AddDeadline(int id, string date)
        {
            string[] dateSplitted = date.Split(".");
            _tasks.First(x => x.Id == id).Deadline = new DateTime(int.Parse(dateSplitted[2]), 
                int.Parse(dateSplitted[1]), int.Parse(dateSplitted[0]));
        }
        
        public void Save(string filePath)
        {
            if (_groups.Count == 0)
            {
                string json = JsonSerializer.Serialize(_tasks);
                File.WriteAllText(filePath, json);
            }
            else
            {
                string json = JsonSerializer.Serialize(_groups);
                File.WriteAllText(filePath, json);
            }
        }

        public void Load(string filePath)
        {
            var file = File.ReadAllText(filePath);
            _tasks = JsonSerializer.Deserialize<List<Task>>(file);
        }

        public void ShowAll()
        {
            foreach (var task in _tasks)
            {
                var checkbox = task.IsCompleted ? "[x]" : "[ ]";
                var date = task.Deadline == DateTime.MaxValue ? "" : $"{task.Deadline:dd.MM.yyyy}";
                Console.WriteLine($"{checkbox} ({date}) {{{task.Id}}} {task.Description}");
                foreach (var subTask in task.Subtasks)
                {
                    checkbox = subTask.IsCompleted ? "[x]" : "[ ]";
                    Console.WriteLine($"\t{checkbox} {{{subTask.Id}}} {subTask.Description}");
                }
            }
            Console.WriteLine();
        }
    }
}
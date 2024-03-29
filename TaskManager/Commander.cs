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
            ConsolePrinter.TaskAdded(_id);
            _id++;
        }

        public void AddSubtask(int id, string subtaskTitle)
        {
            Task task = _tasks.First(x => x.Id == id);
            Subtask subtask = new Subtask(_id, subtaskTitle);
            task.Subtasks.Add(subtask);
            ConsolePrinter.TaskAdded(_id);
            _id++;
        }

        public void DeleteTask(int id)
        {
            _tasks.Remove(_tasks.First(x => x.Id == id));
            ConsolePrinter.TaskDeleted();
        }

        public void CompleteTask(int id)
        {
            _tasks.First(x => x.Id == id).IsCompleted = true;
            ConsolePrinter.TaskCompleted(id);
        }

        public void CompleteSubtask(int id)
        {
            _tasks.Select(x => x.Subtasks.First(y => y.Id == id)).First().IsCompleted = true;
            ConsolePrinter.TaskCompleted(id);
        }

        public string IsSubtask(int id)
        {
            if (_tasks.Find(x => x.Id == id) != null) return "false";
            return _tasks.Any(task => task.Subtasks.Any(subtask => subtask.Id == id)) ? "true" : "not founded";
        }

        public void CreateGroup(string title)
        {
            _groups.Add(new TaskGroup(_groupId, title));
            ConsolePrinter.GroupCreated(_groupId);
            _groupId++;
        }

        public void DeleteGroup(int groupId)
        {
            _groups.Remove(_groups.First(x => x.Id == groupId));
            ConsolePrinter.GroupDeleted(groupId);
        }

        public void AddToGroup(int groupId, int id)
        {
            _groups.First(x => x.Id == groupId).Tasks.Add(_tasks.First(x => x.Id == id));
            ConsolePrinter.AddedToGroup(id, _groups.First(x => x.Id == groupId).Title);
        }

        public void DeleteFromGroup(int groupId, int id)
        {
            _groups.First(x => x.Id == groupId).Tasks.Remove(_tasks.First(x => x.Id == id));
            ConsolePrinter.DeletedFromGroup(id, _groups.First(x => x.Id == groupId).Title);
        }

        public void AddDeadline(int id, string date)
        {
            string[] dateSplitted = date.Split(".");
            _tasks.First(x => x.Id == id).Deadline = new DateTime(int.Parse(dateSplitted[2]), 
                int.Parse(dateSplitted[1]), int.Parse(dateSplitted[0]));
            ConsolePrinter.DeadlineSetted();
        }
        
        public void Save(string filePath)
        {
            string json = JsonSerializer.Serialize(_tasks);
            File.WriteAllText(filePath, json);
            ConsolePrinter.TasksSaved();
        }

        public void Load(string filePath)
        {
            var json = File.ReadAllText(filePath);
            _tasks = JsonSerializer.Deserialize<List<Task>>(json);
            ConsolePrinter.TasksLoaded();
        }

        public void ShowAll()
        {
            foreach (var group in _groups)
            {
                ConsolePrinter.ShowGroup(group);
            }
            foreach (var task in _tasks.Select(x => x).Where(y => !HasGroup(y.Id)))
            {
                ConsolePrinter.ShowTask(task);
            }
            Console.WriteLine();
        }

        public void ShowGroups()
        {
            foreach (var group in _groups)
            {
                ConsolePrinter.ShowGroup(group);
            }
        }

        private bool HasGroup(int id)
        {
            return _groups.Any(x => x.Tasks.Contains(_tasks.First(y => y.Id == id)));
        }

        public void Completed()
        {
            foreach (var task in _tasks.Where(task => task.IsCompleted))
            {
                ConsolePrinter.ShowTask(task);
            }
            Console.WriteLine();
        }
        
        public void Today()
        {
            foreach (var task in _tasks.Where(task => task.Deadline.Day == DateTime.Now.Day && 
                                                      task.Deadline.Month == DateTime.Now.Month && 
                                                      task.Deadline.Year == DateTime.Now.Year))
            {
                ConsolePrinter.ShowTask(task);
            }
            Console.WriteLine();
        }
    }
}
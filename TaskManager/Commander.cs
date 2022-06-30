using System;
using System.Collections.Generic;
using System.Linq;

namespace TaskManager
{
    public class Commander
    {
        private List<Task> _tasks = new List<Task>();
        private List<TaskGroup> _groups = new List<TaskGroup>();
        private int _id;
        private int _groupId;

        public Commander()
        {
            _id = 1;
            _groupId = 1;
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
            task.AddSubtask(_id, subtaskTitle);
            _id++;
        }

        public void DeleteTask(int id)
        {
            _tasks.Remove(_tasks.First(x => x.Id == id));
        }

        public void CompleteTask(int id)
        {
            _tasks.First(x => x.Id == id).MarkCompleted();
        }

        public void CompleteSubtask(int id)
        {
            Subtask subtask = _tasks.Select(x => x.subtasks.First(x => x.Id == id)).First();
            subtask.MarkCompleted();
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
            _groups.First(x => x.Id == groupId).AddToGroup(_tasks.First(x => x.Id == id));
        }

        public void DeleteFromGroup(int groupId, int id)
        {
            _groups.First(x => x.Id == groupId).DeleteFromGroup(id);
        }

        public void SetDeadline(int id, string date)
        {
            string[] dateSplitted = date.Split(".");
            _tasks.First(x => x.Id == id).AddDeadline(new DateTime(int.Parse(dateSplitted[0]), 
                int.Parse(dateSplitted[1]), int.Parse(dateSplitted[2])));
        }


        public void Save(string fileName)
        {
            
        }
    }
}
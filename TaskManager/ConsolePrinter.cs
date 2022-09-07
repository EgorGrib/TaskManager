using System;

namespace TaskManager
{
    public static class ConsolePrinter
    {
        public static void ShowTask(Task task)
        {
            var checkbox = task.IsCompleted ? "[x]" : "[ ]";
            Console.WriteLine(task.Deadline == DateTime.MaxValue
                ? $"{checkbox} {{{task.Id}}} {task.Description}"
                : $"{checkbox} ({task.Deadline:dd.MM.yyyy}) {{{task.Id}}} {task.Description}");
            foreach (var subTask in task.Subtasks)
            {
                checkbox = subTask.IsCompleted ? "[x]" : "[ ]";
                Console.WriteLine($"  - {checkbox} {{{subTask.Id}}} {subTask.Description}");
            }
        }

        public static void ShowGroup(TaskGroup group)
        {
            Console.WriteLine($"Group: {group.Title}");
            foreach (var task in group.Tasks)
            {
                Console.Write("  ");
                ShowTask(task);
            }
        }

        public static void TaskAdded(int id)
        {
            Console.WriteLine($"Task created. Id: {id}");
        }
        
        public static void TaskDeleted()
        {
            Console.WriteLine("Task deleted.");
        }
        
        public static void TaskCompleted(int id)
        {
            Console.WriteLine($"Task {id} completed.");
        }
        
        public static void GroupCreated(int id)
        {
            Console.WriteLine($"Group created. GroupId: {id}");
        }
        
        public static void GroupDeleted(int id)
        {
            Console.WriteLine($"Group {id} deleted.");
        }
        
        public static void AddedToGroup(int taskId, string groupName)
        {
            Console.WriteLine($"Task {taskId} added to group {groupName}");
        }
        
        public static void DeletedFromGroup(int taskId, string groupName)
        {
            Console.WriteLine($"Task {taskId} deleted from group {groupName}");
        }
        
        public static void DeadlineSetted()
        {
            Console.WriteLine("Deadline for the task setted.");
        }
        
        public static void TasksSaved()
        {
            Console.WriteLine("Tasks saved to file.");
        }
        
        public static void TasksLoaded()
        {
            Console.WriteLine("Tasks loaded from file.");
        }
    }
}
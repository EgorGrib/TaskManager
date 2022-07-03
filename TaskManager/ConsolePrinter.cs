using System;

namespace TaskManager
{
    public static class ConsolePrinter
    {
        public static void ShowTask(Task task)
        {
            var checkbox = task.IsCompleted ? "[x]" : "[ ]";
            var date = task.Deadline == DateTime.MaxValue ? "" : $"{task.Deadline:dd.MM.yyyy}";
            Console.WriteLine($"{checkbox} ({date}) {{{task.Id}}} {task.Description}");
            foreach (var subTask in task.Subtasks)
            {
                checkbox = subTask.IsCompleted ? "[x]" : "[ ]";
                Console.WriteLine($"  {checkbox} {{{subTask.Id}}} {subTask.Description}");
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
    }
}
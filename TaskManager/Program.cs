using System;

namespace TaskManager
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task1 = new Task(1, "Do test task");
            task1.AddDeadline(new DateTime(2022, 7, 3));
            task1.AddSubTask(1, "do thing 1");
            task1.AddSubTask(2, "do thing 2");
            task1.Print();
        }
    }
}

namespace TaskManager
{
    static class Program
    { 
        
        static void Main(string[] args)
        {
            /*Task task1 = new Task(1, "Do test task");
            task1.AddDeadline(new DateTime(2022, 7, 3));
            task1.AddSubtask(1, "do thing 1");
            task1.AddSubtask(2, "do thing 2");
            task1.MarkCompleted();
            //task1.Print();
            Task task2 = new Task(2, "Do tasdsafdfsf sdfsdfk");
            TaskGroup taskGroup = new TaskGroup(1, "Studies");
            taskGroup.AddToGroup(task1);
            taskGroup.AddToGroup(task2);
            //task1.Print();
            //task2.Print();
            string json = JsonSerializer.Serialize(task1);
            taskGroup.Print();
            Console.WriteLine("=================");
            taskGroup.DeleteFromGroup(2);
            taskGroup.DeleteFromGroup(1);
            taskGroup.Print();
            Console.WriteLine(json);*/
            
            
            Commander commander = new Commander();
            commander.AddTask("something");
            commander.AddSubtask(1, "task 1");
            commander.AddSubtask(1, "task 2");
            commander.Save(@"D:\test.json");
        }
    }
}
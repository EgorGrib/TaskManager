
namespace TaskManager
{
    static class Program
    { 
        
        static void Main(string[] args)
        {
            Commander commander = new Commander();
            commander.AddTask("something");
            commander.AddSubtask(1, "subtask 1");
            commander.AddSubtask(1, "subtask 2");
            commander.CompleteSubtask(2);
            commander.CompleteSubtask(3);
            commander.CompleteTask(1);
            
            commander.AddTask("very imortant");
            commander.AddSubtask(4, "do homework");
            commander.AddDeadline(4, "02.07.2022");

            commander.Save(@"D:\test.json");
            
        }
    }
}
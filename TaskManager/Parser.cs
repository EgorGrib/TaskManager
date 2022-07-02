using System;

namespace TaskManager
{
    public class Parser
    {
        private readonly Commander _commander;
        private bool _run = true;
        public Parser()
        {
            _commander = new Commander();
        }

        public void Run()
        {
            while (_run)
            {
                string[] input = Console.ReadLine().Split(" ");
                string args = String.Join(' ', input, 1, input.Length - 1);
                switch (input[0])
                {
                    case "/add":
                        _commander.AddTask(args);
                        break;
                    
                    case "/delete":
                        _commander.DeleteTask(Convert.ToInt32(args));
                        break;
                    
                    case "/add-subtask":
                        var subtaskArgs = args.Split(" ");
                        var title = String.Join(' ', subtaskArgs, 1, subtaskArgs.Length - 1);
                        _commander.AddSubtask(Convert.ToInt32(subtaskArgs[0]), title);
                        break;
                    
                    case "/complete":
                        var id = Convert.ToInt32(args);
                        string isSub = _commander.IsSubtask(id);
                        if (isSub == "true")
                            _commander.CompleteSubtask(id);
                        else if (isSub == "false")
                            _commander.CompleteTask(id);
                        //else not founded
                        break;
                    
                    case "/complete-sub":
                        _commander.CompleteSubtask(Convert.ToInt32(args));
                        break;
                    
                    case "/create-group":
                        _commander.CreateGroup(args);
                        break;
                    
                    case "/delete-group":
                        _commander.DeleteGroup(Convert.ToInt32(args));
                        break;
                    
                    case "/add-to-group":
                        var groupArgs = args.Split(" ");
                        _commander.AddToGroup(Convert.ToInt32(groupArgs[0]), Convert.ToInt32(groupArgs[1]));
                        break;
                    
                    case "/delete-from-group":
                        var argsSplitted = args.Split(" ");
                        _commander.DeleteFromGroup(Convert.ToInt32(argsSplitted[0]), Convert.ToInt32(argsSplitted[1]));
                        break;
                    
                    case "/set-deadline":
                        var argsDate = args.Split(" ");
                        _commander.AddDeadline(Convert.ToInt32(argsDate[0]), argsDate[1]);
                        break;
                        
                    case "/save":
                        _commander.Save(args);
                        break;
                    
                    case "/load":
                        _commander.Load(args);
                        break;
                    
                    case "/all":
                        _commander.ShowAll();
                        break;
                    
                    case "/exit":
                        _run = false;
                        break;
                }
            }
        }
    }
}
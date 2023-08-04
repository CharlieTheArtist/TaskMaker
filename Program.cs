using System.Security.Cryptography.X509Certificates;
using System.IO;


namespace TaskMaker
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string Input = " ";
            var taskList = TaskListManager.LoadList();

            Console.WriteLine("Hello! ");
            while (Input.ToLower() != "exit")
            {

                Console.WriteLine(" \n Task List Menu: \n 1. View Tasks \n 2. Add Task \n 3. Mark Task Complete \n 4. Delete Task \n Type Save to commit changes and quit the application \n ");

                Input = Console.ReadLine();

                switch (Input.ToLower())
                {
                    case "1":
                        {
                            TaskListManager.ViewTask(taskList);
                            break;
                        }
                    case "2":
                        {
                            TaskListManager.AddTask(taskList);
                            break;
                        }
                    case "3":
                        {
                            TaskListManager.CompleteTask(taskList);
                            break;
                        }
                    case "4":
                        {
                            TaskListManager.RemoveTask(taskList);
                            break;
                        }
                    case "save":
                        {
                            TaskListManager.SaveList(taskList);
                            Input = "exit";
                            break;
                        }
                    default:
                        {
                            Console.WriteLine(" \n Not a valid option \n ");
                            break;
                        }
                }
            }
        }
    }
}
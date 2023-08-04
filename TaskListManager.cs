using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TaskMaker
{

    public static class TaskListManager
    {
        private static string fileName = "ListOfTasks.json";

        // save list to JSON
        public static void SaveList(List<Task> list)
        {
            string jsonString = JsonSerializer.Serialize(list);

            // write the JSON to the file
            File.WriteAllText(fileName, jsonString);
        }

        // load list from JSON
        public static List<Task> LoadList()
        {
            List<Task>? taskList = null;

            try
            {
                if (File.Exists(fileName))
                {
                    string jsonString = File.ReadAllText(fileName);
                    taskList = JsonSerializer.Deserialize<List<Task>>(jsonString);
                }
                else
                {
                    taskList = new List<Task>();
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(" \n Error loading saved task list: " + ex.Message + "\n ");

                taskList = new List<Task>();
            }

            return taskList;
        }

        public static void ViewTask(List<Task> taskList)
        {
            //roll through list and display tasks
            //also display their index in a human readable format
            //using a ternary conditional operator to list the status of the task


            //checks to see if tasks exist and informs user if they don't
            if (taskList.Count == 0)
            {
                Console.WriteLine(" \n No tasks to show :( \n ");
            }
            else
            {
                for (int i = 0; i < taskList.Count; i++)
                {
                    Task task = taskList[i];

                    Console.WriteLine($" \n {i + 1}. {task.Name} ({(task.IsComplete ? "Completed" : "Not Completed")}) \n ");
                }
            }


            Console.WriteLine(" ");
        }


        public static void AddTask(List<Task> taskList)
        {
            //prompts user for task name and adds task to list
            var task = new Task();
            Console.WriteLine(" \n Please enter your task");

            task.Name = Console.ReadLine();

            taskList.Add(task);

            Console.WriteLine(" \n Task Added! \n ");

        }

        public static void RemoveTask(List<Task> taskList)
        {
            //prompt which task to remove based on numerical ID
            //retrieve task index by subtracting 1 and then feed into .RemoveAt method
            string? _input = null;

            Console.WriteLine(" \n Which task would you like to remove? Please enter the numerical ID \n ");

            _input = Console.ReadLine();

            int i;
            bool success = int.TryParse(_input, out i);

            int taskIndex = i - 1;

            //makes sure its at least zero and not a negative number
            if (taskIndex >= 0 && taskIndex < taskList.Count)
            {
                if (taskList[taskIndex].IsComplete != true)
                {
                    Console.WriteLine("Task not completed! Are you sure? \n Yes/No");

                    _input = Console.ReadLine();

                    if (_input.ToLower() == "yes")
                    {
                        taskList.RemoveAt(i - 1);

                        Console.WriteLine(" \n Task removed! \n ");
                    }
                    else if (_input.ToLower() == "no")
                    {
                        Console.WriteLine("Task will not be removed. ");
                    }


                }
                //if completed simply removes and notifies user
                else
                {
                    taskList.RemoveAt(i - 1);

                    Console.WriteLine(" \n Task removed! \n ");
                }

            }
            else { Console.WriteLine(" \n Not a valid option \n "); }
            //checks if task is completed
            //if not it asks if they're sure and acts based on decision

        }


        public static void CompleteTask(List<Task> taskList)
        {
            //prompts for task and retrieves task based on index, then ticks bool to show completed
            string? _input = null;

            Console.WriteLine(" \n Which task has been completed? Please enter the numerical ID \n ");

            _input = Console.ReadLine();

            int i;
            bool success = int.TryParse(_input, out i);
            int taskIndex = i - 1;

            //makes sure its a valid option
            if (taskIndex >= 0 && taskIndex < taskList.Count)
            {
                taskList[taskIndex].IsComplete = true;

                Console.WriteLine(" \n Task Completed! Great work! \n ");
            }
            else { Console.WriteLine("Not a valid option"); }

        }
    }
}
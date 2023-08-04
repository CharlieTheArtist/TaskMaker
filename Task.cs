using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace TaskMaker
{
    public class Task
    {
        public string? Name { get; set; }
        public bool IsComplete { get; set; }

        

        public Task()
        {
            
        }
        public Task(string name)
        {
            Name = name;

            IsComplete = false;

        }
        public Task(string name, bool isComplete)
        {
            Name = name;
            IsComplete = isComplete;
        }
    }
}

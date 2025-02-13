using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TaskTraker.Models;
using static TaskTraker.Models.TaskItem;

namespace TaskTraker.Business
{
    public class TaskManager
    {
        private const string FilePath = "tasks.json";
        private List<TaskItem> tasks = new();
        public TaskManager()
        {
            LoadTask();
        }

        public void LoadTask()
        {
            if (File.Exists(FilePath))
            {
                var json = File.ReadAllText(FilePath);
                tasks = JsonSerializer.Deserialize<List<TaskItem>>(json) ?? new List<TaskItem>();

            }
        }
        public void SaveTask()
        {
            var json = JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(FilePath, json);
        }

        public void AddTask(string description)
        {
            int newId = tasks.Any() ? tasks.Max(t => t.Id) + 1 : 1;
            var newTask = new TaskItem { Id = newId, Description = description, TaskStatus = TaskItem.Status.Todo  };
            tasks.Add(newTask);
            SaveTask();
            Console.WriteLine($"Task {newId} added");
        }


        public void UpdateTask(int id, string newDescription)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if(tasks == null)
            {
                Console.WriteLine($"Task {id} not found");
                return;
            }
            task.Description = newDescription;
            task.UpdatedAt = DateTime.Now;
            SaveTask();
            Console.WriteLine($"Task {id} updated");

        }

        public void DeleteTask(int id)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }
            tasks.Remove(task);
            SaveTask();
            Console.WriteLine("Task deleted successfully.");
        }

        public void ChangeTaskStatus(int id, Status status)
        {
            var task = tasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                Console.WriteLine("Task not found.");
                return;
            }
            task.TaskStatus = status;
            task.UpdatedAt = DateTime.UtcNow;
            SaveTask();
            Console.WriteLine($"Task status updated to {status}.");
        }

        public void ListTasks()
        {

            if (!tasks.Any())
            {
                Console.WriteLine("No tasks found.");
                return;
            }

            foreach (var task in tasks)
            {
                Console.WriteLine($"[{task.Id}] {task.Description} - {task.TaskStatus} (Created: {task.CreatedAt}, Updated: {task.UpdatedAt})");
            }
        }


    }
}

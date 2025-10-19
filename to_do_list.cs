using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

public class Task
{
    public int Id { get; set; }
    public string Description { get; set; }
    public bool Completed { get; set; }
    public string CreatedAt { get; set; }
}

public class TodoList
{
    private List<Task> tasks;
    private const string JsonFilePath = "todos.json";

    public TodoList()
    {
        tasks = new List<Task>();
        LoadTasks();
    }

    private void LoadTasks()
    {
        if (File.Exists(JsonFilePath))
        {
            try
            {
                string jsonString = File.ReadAllText(JsonFilePath);
                tasks = JsonSerializer.Deserialize<List<Task>>(jsonString) ?? new List<Task>();
                Console.WriteLine("Tasks loaded successfully.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error loading tasks: {e.Message}");
                tasks = new List<Task>();
            }
        }
    }

    private void SaveTasks()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(tasks, options);
            File.WriteAllText(JsonFilePath, jsonString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"Error saving tasks: {e.Message}");
        }
    }

    public void AddTask()
    {
        Console.Write("Enter task description: ");
        string description = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(description))
        {
            Console.WriteLine("Task description cannot be empty.");
            return;
        }

        int taskId = tasks.Count > 0 ? tasks.Max(t => t.Id) + 1 : 1;
        var newTask = new Task
        {
            Id = taskId,
            Description = description,
            Completed = false,
            CreatedAt = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        };

        tasks.Add(newTask);
        SaveTasks();
        Console.WriteLine($"Task '{description}' added successfully!");
    }

    public void ViewTasks()
    {
        if (tasks.Count == 0)
        {
            Console.WriteLine("\nNo tasks in your to-do list.");
            return;
        }

        Console.WriteLine("\n=== Your To-Do List ===");
        foreach (var task in tasks)
        {
            string status = task.Completed ? "✓" : "○";
            string description = task.Completed ? $"[DONE] {task.Description}" : task.Description;
            Console.WriteLine($"{task.Id}. {status} {description} (Created: {task.CreatedAt})");
        }
    }

    public void CompleteTask()
    {
        Console.Write("Enter task ID to mark as complete: ");
        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                task.Completed = true;
                SaveTasks();
                Console.WriteLine($"Task '{task.Description}' marked as complete!");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void RemoveTask()
    {
        Console.Write("Enter task ID to remove: ");
        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                tasks.Remove(task);
                RenumberTasks();
                SaveTasks();
                Console.WriteLine($"Task '{task.Description}' removed successfully!");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void ClearCompletedTasks()
    {
        int count = tasks.RemoveAll(t => t.Completed);
        if (count > 0)
        {
            RenumberTasks();
            SaveTasks();
            Console.WriteLine($"{count} completed task(s) cleared!");
        }
        else
        {
            Console.WriteLine("No completed tasks to clear.");
        }
    }

    public void GetTaskStatus()
    {
        Console.Write("Enter task ID to check status: ");
        if (int.TryParse(Console.ReadLine(), out int taskId))
        {
            var task = tasks.FirstOrDefault(t => t.Id == taskId);
            if (task != null)
            {
                string status = task.Completed ? "Completed (True)" : "Not Completed (False)";
                Console.WriteLine($"\nTask ID {taskId}: {task.Description}");
                Console.WriteLine($"Status: {status}");
            }
            else
            {
                Console.WriteLine("Task not found.");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    public void GetTaskAtIndex()
    {
        Console.Write("Enter index (0-based): ");
        if (int.TryParse(Console.ReadLine(), out int index))
        {
            if (index >= 0 && index < tasks.Count)
            {
                var task = tasks[index];
                Console.WriteLine($"\n--- Task at Index {index} ---");
                Console.WriteLine($"ID: {task.Id}");
                Console.WriteLine($"Description: {task.Description}");
                Console.WriteLine($"Completed: {task.Completed}");
                Console.WriteLine($"Created At: {task.CreatedAt}");
            }
            else
            {
                Console.WriteLine($"Index out of range. Valid range: 0-{tasks.Count - 1}");
            }
        }
        else
        {
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    private void RenumberTasks()
    {
        for (int i = 0; i < tasks.Count; i++)
        {
            tasks[i].Id = i + 1;
        }
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine("\n=== To-Do List Menu ===");
            Console.WriteLine("1. Add Task");
            Console.WriteLine("2. View Tasks");
            Console.WriteLine("3. Mark Task as Complete");
            Console.WriteLine("4. Remove Task");
            Console.WriteLine("5. Clear Completed Tasks");
            Console.WriteLine("6. Check Task Status");
            Console.WriteLine("7. Get Task at Index");
            Console.WriteLine("8. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddTask();
                    break;
                case "2":
                    ViewTasks();
                    break;
                case "3":
                    CompleteTask();
                    break;
                case "4":
                    RemoveTask();
                    break;
                case "5":
                    ClearCompletedTasks();
                    break;
                case "6":
                    GetTaskStatus();
                    break;
                case "7":
                    GetTaskAtIndex();
                    break;
                case "8":
                    tasks.Clear();
                    SaveTasks();
                    Console.WriteLine("All tasks cleared. Goodbye!");
                    return;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        var todoList = new TodoList();
        todoList.Run();
    }
}
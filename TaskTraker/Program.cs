using System.CommandLine;
using TaskTraker.Business;
using TaskTraker.Models;

var taskManager = new TaskManager();
var rootCommand = new RootCommand("Task Tracker CLI");

var addCommand = new Command("add", "Add a new task")
{
    new Argument<string>("description", "Task description")
};
addCommand.SetHandler((description) => taskManager.AddTask(description), new Argument<string>("description"));
rootCommand.AddCommand(addCommand);

var updateCommand = new Command("update", "Update a task")
{
    new Argument<int>("id", "Task ID"),
    new Argument<string>("description", "New task description")
};
updateCommand.SetHandler((id, description) => taskManager.UpdateTask(id, description),
    new Argument<int>("id"),
    new Argument<string>("description"));
rootCommand.AddCommand(updateCommand);

var deleteArgument = new Argument<int>("id", "Task ID");
var deleteCommand = new Command("delete", "Delete a task");
deleteCommand.AddArgument(deleteArgument);
deleteCommand.SetHandler((id) => taskManager.DeleteTask(id), deleteArgument); 
rootCommand.AddCommand(deleteCommand);

var markInProgressCommand = new Command("mark-in-progress", "Mark a task as in-progress")
{
    new Argument<int>("id", "Task ID")
};
markInProgressCommand.SetHandler((id) => taskManager.ChangeTaskStatus(id, TaskItem.Status.InProgress), new Argument<int>("id"));
rootCommand.AddCommand(markInProgressCommand);

var markDoneCommand = new Command("mark-done", "Mark a task as done")
{
    new Argument<int>("id", "Task ID")
};
markDoneCommand.SetHandler((id) => taskManager.ChangeTaskStatus(id, TaskItem.Status.Done), new Argument<int>("id"));
rootCommand.AddCommand(markDoneCommand);

var listCommand = new Command("list", "List tasks");
listCommand.SetHandler(() => taskManager.ListTasks());
rootCommand.AddCommand(listCommand);

var clearCommand = new Command("clear", "Clear all tasks");
clearCommand.SetHandler(() => Console.Clear());
rootCommand.AddCommand(clearCommand);

while (true)
{
    Console.Write("\ntask-cli> ");
    var input = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(input)) continue; 
    if (input.ToLower() == "exit") break;
    rootCommand.Invoke(input);
}

Console.WriteLine("Task Tracker CLI finalizado.");

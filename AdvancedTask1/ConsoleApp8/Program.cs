using System.IO;
string filepath = "C:\\Users\\HP\\source\\repos\\ConsoleApp8\\ConsoleApp8\\file.csv";
FileInfo fileInfo = new FileInfo(filepath);
async void AddNewTask(Task task)
{
    if (task == null)
    {
        Console.WriteLine("Empty task.");
        return;
    }
    try
    {
        using (StreamWriter writer = new StreamWriter(filepath, append: true))
        {
            await writer.WriteLineAsync($"{task.Name}, {task.Description}, {task.Category}, {task.IsCompleted}");
        }
    }
    catch (Exception e)
    {
        Console.WriteLine(e.Message);
    }
}

async void ShowTasks()
    {
        Console.WriteLine("Task List");
   
        if (fileInfo.Length == 0)
        {
            Console.WriteLine("No Tasks in the file.");
            return;
        }
        using (StreamReader reader = new StreamReader(filepath))
        {
            string line;
            while((line = await reader.ReadLineAsync()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }

async void ShowTasksByCategory(Categories type)
{
    FileInfo fileInfo = new FileInfo(filepath);
    if (fileInfo.Length == 0)
    {
        Console.WriteLine("No Tasks in the file.");
        return;
    }
    using (StreamReader reader = new StreamReader(filepath))
    {
        bool avialable = false;
        string line;
        while ((line = await reader.ReadLineAsync()) != null)
        {
            string[] values = line.Split(",");
            string currType = values[2].Trim();
            string chosenType = type.ToString();
            if (currType.Equals(chosenType))
            {
                Console.WriteLine(line);
                avialable = true;
            }          
        }
        if (!avialable)
        {
            Console.WriteLine("No Task under the category chosen.");
        }
    }
}

    while (true)
    {
        try
        {
            Console.WriteLine($"1)Add New Task\n2)Show All Tasks\n3)Show Tasks Based On Categories");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Input Name.");
                    string name = Console.ReadLine();
                    Console.WriteLine("Input Description.");
                    string description = Console.ReadLine();
                    Console.WriteLine("Input Category. 0 for Personal, 1 for Work , 2 for Errands.");
                    int type = Convert.ToInt32(Console.ReadLine());
                    if (type == null || (type != null && type != 0 && type != 1 && type != 2))
                    {
                        throw new Exception("Wrong Entry");
                    }
                    Categories category = (Categories)Enum.Parse(typeof(Categories), type.ToString());
                    Console.WriteLine("Is the task completed? Input y/Y is YES n/N if NO");
                    char checkCompletion = Convert.ToChar(Console.ReadLine());
                    bool isCompleted = false;
                    if (checkCompletion == 'y' || checkCompletion == 'Y')
                    {
                        isCompleted = true;
                    }
                    AddNewTask(new Task() { Name = name, Category = category, Description = description, IsCompleted = isCompleted });
                    break;
                case 2:
                    ShowTasks();
                    break;
                case 3:
                    Console.WriteLine("Input Category. 0 for Personal, 1 for Work , 2 for Errands.");
                    int type1 = Convert.ToInt32(Console.ReadLine());
                    if (type1 == null || (type1 != null && type1 != 0 && type1 != 1 && type1 != 2))
                    {
                        throw new Exception("Wrong Entry");
                    }
                    Categories category1 = (Categories)Enum.Parse(typeof(Categories), type1.ToString());
                    ShowTasksByCategory(category1);
                    break;
                default:
                    Console.WriteLine("Wrong Entry!!");
                    break;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }


public enum Categories
{
    Personal,
    Work,
    Errands
}
public class Task
{
    string name;
    string description;
    Categories category;
    bool isCompleted;

    public string Name { set; get; }
    public string Description { set; get; }
    public Categories Category { set; get; }
    public bool IsCompleted { set; get; }
}



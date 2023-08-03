using System.Threading.Tasks;

public class Service : ITask
{
    private string directoryPath = "C:\\Users\\hp\\Documents\\A2SV\\.NET Course";
    private string fileName = "data.csv";
    
    public async Task AddTask(MyTask newTask)
    {
        string filePath = Path.Combine(directoryPath, fileName);

        List<MyTask> previousTasks = await Task.Run(() => CSVFile.ReadCSV(filePath));
        previousTasks.Add(newTask);
        await Task.Run(() => CSVFile.WriteCSV(filePath, previousTasks));
    }


    public async Task GetAllTasks()
    {
        string filePath = Path.Combine(directoryPath, fileName);
        List<MyTask> allTasks = await Task.Run(() => CSVFile.ReadCSV(filePath));

        if (allTasks != null && allTasks.Count > 0)
        {
            DisplayTasks(allTasks);
        }
        else
        {
            Console.WriteLine("Task is not Found, Please try-again");
        }
    }

    public async Task GetTasksByCategory(string category)
    {

        string filePath = Path.Combine(directoryPath, fileName);
        List<MyTask> allTasks = await Task.Run(() => CSVFile.ReadCSV(filePath));

        List<MyTask> categoryTasks = allTasks.Where(task => task.Category == category).ToList();

        if (categoryTasks != null && categoryTasks.Count > 0)
        {
            DisplayTasks(categoryTasks);
        }
        else
        {
            Console.WriteLine("Task is not Found, Please try-again");
        }
        
    }

    private static void DisplayTasks(List<MyTask> tasks)
    {
        foreach (MyTask task in tasks)
        {
            string taskDetail =
                $"Name : {task.Name}\n" +
                $"Description : {task.Description}\n" +
                $"Category : {task.Category}\n" +
                $"Completed : {task.IsCompeleted}\n";

            Console.WriteLine(taskDetail);
        }
    }
}

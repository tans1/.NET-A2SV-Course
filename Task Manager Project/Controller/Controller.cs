public class Controller : Service
{
    
    public static async void AddTask()
    {
        Service service = new Service();

        string taskName;
        string taskDescription;
        int categoryNumber;
    
        Console.Write("Name : ");
        taskName = Console.ReadLine();
        Console.Write("Description : ");
        taskDescription = Console.ReadLine();

        do
        {
            Console.WriteLine("Choose the categories' number\n1-Personal\t2-Work  \t3-Reading \t4-Entertainment\t5-Sport");
        }
        while ((!int.TryParse(Console.ReadLine(), out categoryNumber)) || (categoryNumber <= 0 || categoryNumber > 5));


        Enum.TryParse($"{categoryNumber}", out Categories category);
        MyTask newTask = new MyTask() {
            Name = taskName,
            Description = taskDescription,
            Category = category.ToString(),
            IsCompeleted = "No"
        };

        await service.AddTask(newTask);
        Console.WriteLine("Successfully Created");
    }
    
    public static async void GetAllTasks() {
        Service service = new Service();
        await service.GetAllTasks();
    }

    public static async void  GetTasksByCategory() {
        Service service = new Service();
        int categoryNumber;
        do
        {
            Console.WriteLine("Choose the Categories' Number\n1-Personal\t2-Work\t3-Reading\t4-Entertainment\t5-Sport");
        }
        while (!int.TryParse(Console.ReadLine(), out categoryNumber) && categoryNumber <= 0 && categoryNumber > 5);

        Categories category = (Categories)categoryNumber;

        await service.GetTasksByCategory(category.ToString());
    }
}


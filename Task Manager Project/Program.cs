public enum Categories
{
    Personal = 1,
    Work = 2,
    Reading = 3,
    Entertainment = 4,
    Sport = 5
}
class Program : Controller
{
    public static void Main(string[] args)
    {
        string greetings = "WELCOME TO TASK MANAGER\n" +
            "***************************************";
        Console.WriteLine(greetings);

        while (true)
        {
            int instruction = DisplayInstructions();
            switch (instruction)
            {
                case 1:
                    GetAllTasks();

                    break;
                case 2:
                    GetTasksByCategory();
                    break;
                case 3:
                    AddTask();
                    break;

            }
        }
        

    }

    private static int DisplayInstructions()
    {
        int instructionChoice;
        string menuOptions =
            "-----------------------------------------\n" +
            "1. See all your Tasks\n" +
            "2. See Task by Category\n" +
            "3. Add new Task\n";
        Console.WriteLine(menuOptions);
        
        while (!int.TryParse(Console.ReadLine(), out instructionChoice) && (instructionChoice <= 0 && instructionChoice > 3)){
            Console.WriteLine("Please , choose appropriate instruction and, try-again");

        }
        Console.WriteLine("_________________________________________");
        return instructionChoice;

    }
}
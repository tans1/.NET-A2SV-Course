

using System.Xml.Linq;

class GradeCalculator
{
    public  static void Main(string[] args)
    {
        string name;
        int numberOfSubjects;

        Console.WriteLine("WELCOME TO STUDENT'S GRADE CALCULATOR");
        Console.WriteLine("***************************************");
        Console.WriteLine("PLEASE PROVIDE THE FOLLOWING DATA");

        Console.Write("NAME : ");
        name = Console.ReadLine().ToUpper();

        Console.Write("NUMBER OF SUBJECTS :");
        var numSubjects = Console.ReadLine();

        if (int.TryParse(numSubjects, out numberOfSubjects))
        {
            if (0 < numberOfSubjects & numberOfSubjects <= 15)
            {
                Calcultor.HandleCalculation(numberOfSubjects, name!);
            }
            else
            {
                Console.WriteLine("It is impossible to take such amount of courses, please re-try");
            }
        }
        else
        {
            Console.Write("please provide valid number of sujects");
        }

        
    }
}


class Calcultor
{
    public static void HandleCalculation(int numberOfSubjects, string studentName)
    {
        Dictionary<string, int> subjects = new Dictionary<string, int>();
        int grade;
        for (var i =0; i < numberOfSubjects; i++)
        {
            Console.Write("SUBJECT NAME : ");
            var subjectName = Console.ReadLine();
            

            Console.Write("Points : ");
            var points = Console.ReadLine();

            if (int.TryParse(points, out grade))
            {
                if (0 <= grade & grade <= 100)
                {
                    subjects.Add(subjectName, grade);
                }
                else
                {
                    Console.WriteLine("It is impossible to take such amount of grade points, please re-try");
                    break;
                }
            }
            else
            {
                Console.Write("please provide valid grade, and re-try");
                break;
            }
        }
        int total = subjects.Values.Sum();
        DisplayTheResult(subjects, total, studentName);

    }

    public static void DisplayTheResult(Dictionary<string, int> subjects, int total, string studentName)
    {

        double average = (double)total / subjects.Count;
        Console.WriteLine("*************************************************");
        Console.WriteLine($"NAME : {studentName}");
        foreach (KeyValuePair<string, int> kvp in subjects)
        {
            Console.WriteLine($"{kvp.Key}______________________{kvp.Value}");

        }
        Console.WriteLine();
        Console.WriteLine($"total________________________{total}");
        Console.WriteLine($"average______________________{average}");
        Console.WriteLine("THANK YOU");

    }
}
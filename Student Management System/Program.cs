class Program
{
    public static void Main(string[] args)
    {
        string instruction = "1.See All Students\n" +
                             "2.Add new Student\n" +
                             "3.Search Student by Id\n" +
                             "4.Search Student by Name";
        Console.WriteLine("WELCOME TO STUDENT MANAGEMENT System");
        Console.WriteLine("************************************");

        while (true)
        {
            int choice;
            Console.WriteLine("Please follow the instrucation");
            Console.WriteLine(instruction);
            
            while(!int.TryParse(Console.ReadLine(), out choice) && choice < 0 && choice > 4)
            {
                Console.WriteLine("Provide valid instruction, number");
            }

            switch (choice)
            {
                case 1:
                    List<Student> students = StudentList.GetStudents();
                    displayStudents(students);
                    break;
                case 2:
                    Student newStudent = getStudentData();
                    StudentList.AddStudent<Student>(newStudent);
                    break;
                case 3:
                    int id;
                    Console.Write("ID : ");
                    while (!int.TryParse(Console.ReadLine(), out id) && id <= 0)
                    {
                        Console.WriteLine("Provide valid instruction, id");
                        Console.Write("ID : ");
                    }
                    StudentList.SearchStudentById(id);
                    break;

                case 4:
                    Console.Write("NAME : ");
                    var name = Console.ReadLine().Trim();
                    StudentList.SearchStudentByName(name);
                    break;
            }
        }
    }

    public static Student getStudentData()
    {
        string name;
        int age;
        string grade;
        int rollnumber;

        Console.Write("Name : ");
        name = Console.ReadLine();

        Console.Write("AGE : ");
        while (!int.TryParse(Console.ReadLine(), out age) && age <= 10)
        {
            Console.WriteLine("Provide valid instruction, age");
            Console.Write("AGE : ");
        }
        Console.Write("Grade : ");
        grade = Console.ReadLine();

        Console.Write("RollNumber : ");
        while (!int.TryParse(Console.ReadLine(), out rollnumber) && rollnumber <= 0)
        {
            Console.WriteLine("Provide valid instruction, RollNumber");
            Console.Write("RollNumber : ");
        }

        Student newStudent = new Student(name, age, grade, rollnumber);
        return newStudent;
    }
    public static void displayStudents(List<Student> students)
    {
        
        foreach(var student in students)
        {

            string data = $"Name : {student.Name}\n" +
                           $"Age : {student.Age}\n" +
                           $"RollNumber : {student.RollNumber}\n" +
                           $"ID : {student.ID}\n" +
                           $"RollNumber : {student.RollNumber}";
            Console.WriteLine(data);
            Console.WriteLine("____________________________________");
        }
        
    }
}
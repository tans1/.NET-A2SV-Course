

public class StudentList
{
    private static string filePath = @"C:\Users\hp\Documents\A2SV\.NET Course\.NET-A2SV-Course\jsonFile.json";

    public static void AddStudent<T>(T student)
    {
        try
        {
            var jsonResult = Newtonsoft.Json.JsonConvert.SerializeObject(student);
            File.AppendAllLines(filePath,new List<string>() { jsonResult });
            Console.WriteLine("created successfully");
        }
        catch {
            Console.WriteLine("Unable to create Student");
        }
    }

    public static List<Student> GetStudents()
    {
        List<Student> studentsList = new List<Student>();
        try
        {   
            IEnumerable<string> allData = File.ReadAllLines(filePath);
            foreach(var item in allData)
            {
                if ((item != null) && (item.Trim().Length > 0))
                {
                    var student = Newtonsoft.Json.JsonConvert.DeserializeObject<Student>(item);
                    studentsList.Add(student);
                }
            }
            return studentsList;
        }
        catch
        {
            Console.WriteLine("Unable to read");
            return studentsList;
        }
    }

    public static void SearchStudentById(int id)
    {
        List<Student> allStudents = GetStudents();
        var result = from student in allStudents
                        where student.ID == id
                        select student;
        if ((result != null) && (result.ToList().Count > 0))
        {

            Student student = result.ToList()[0];
            Console.WriteLine("____________________________________");
            Console.WriteLine($"Name : {student.Name}\nAge : {student.Age}\nRollNumber : {student.RollNumber}\nGrade : {student.Grade}");
            Console.WriteLine("____________________________________");
        }
        else
        {
            Console.WriteLine("Student not found");
        }
        
    }

    public static void SearchStudentByName(string name)
    {
        List<Student> allStudents = GetStudents();
        var result = from student in allStudents
                     where student.Name == name
                     select student;
        if ((result != null) && (result.ToList().Count > 0))
        {

            List<Student> students = result.ToList();
            Program.displayStudents(students);
        }
        else
        {
            Console.WriteLine("Student not found");
        }

    }

}
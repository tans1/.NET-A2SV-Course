public class Student
{

    public int ID;
    public string Name;
    public int Age;
    public string Grade;
    public readonly int RollNumber;

    public Student(string name, int age, string grade, int rollnumber)
    {
        ID = new Random().Next(1,100);
        Name = name;
        Age = age;
        Grade = grade;
        RollNumber = rollnumber;
    }

}


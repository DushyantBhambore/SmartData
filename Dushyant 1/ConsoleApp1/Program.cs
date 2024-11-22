
using ConsoleApp1;

internal class Program
{
    private static void Main(string[] args)
    {

        var student = GetStudent();

        Console.WriteLine("Age is "+ShowExtension1.CollegeAge(student));
    }

    private static Student GetStudent()
    {
        return new Student()
        {
            StudentId = 1,
            Student_name = "test",
            DateofBirth = new DateTime(1999, 09, 01),
        };
    }
}
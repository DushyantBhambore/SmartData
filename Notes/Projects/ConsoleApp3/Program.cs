using ConsoleApp3;

internal class Program
{
    private static void Main(string[] args)
    {

        var student = GetStudent();

        Console.WriteLine(ShowExtension.CollegeAge(student));
    }

    private static Student GetStudent()
    {
       return new Student(DateTime.Now)
        {
           studentId = 1,
           student_Name = "Test",
           DOB = new DateTime(1999-09-01)
        };
    }
}
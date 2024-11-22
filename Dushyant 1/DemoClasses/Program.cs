using C_PracticethroughMicrosoft.AccesModifier;

public class Program
{
     static void Main(string[] args)
    {
        BadClass bd = new BadClass();
        bd.ADDHARNumber = "123456489712";
        Console.WriteLine($"Your Aaddhar Number is {bd.ADDHARNumber}");

        // Console.WriteLine("Hello, World!");
    }
}
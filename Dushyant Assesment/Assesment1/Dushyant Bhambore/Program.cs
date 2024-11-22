using Assesment1;
using Assesment1.Question1;
using Assesment1.question2;
using Assesment1.Question4;

public class Program
{
    private static void Main(string[] args)
    {
        // Questio4.listFunction();
        Question2.DepartmentList();
        //Question3.SquareExample();
    }

    

    // calll GetFibonacciSeries
    private static void Question1()
    {
        // get number from user
        Console.WriteLine("Enter a Number =");
        var num = Convert.ToInt32(Console.ReadLine());
        fibonachi.GetFibonacciSeries(num);

        Console.WriteLine("Fibonaci series are =");
        foreach (var item in fibonachi.GetFibonacciSeries(num))
        {
            Console.WriteLine(item);
        }
    }
    

   


  


}

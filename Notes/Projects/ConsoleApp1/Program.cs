using Basics;
using Basics.Abstraction;
using Basics.AnonymousFunction;
using Basics.AnonymousType;
using Basics.Assignment;
using Basics.Collection;
using Basics.Constructor;
using Basics.Delegates;
using Basics.Encapsulation;
using Basics.Factorial;
using Basics.FUNC;
using Basics.Generics;
using Basics.PrimeNumber;
using ConsoleApp1;
using static Basics.Delegates.DelegateExample;


public class Program
{
    private static void Main(string[] args)
    {

        ArrayInput obj = new ArrayInput();
        obj.Test();
        //  Strings.Test();
        //Numbers.Test();
        //Numbers obj = new Numbers();
        //obj.Test();

        //Cars obj = new Cars();
        //obj.color();

        // Single Cast Delegates 
        //Mydelegate obj = new Mydelegate(DelegateExample.MyFunction);
        //obj.Invoke();

        //Valuedelegate obj1 = new Valuedelegate(DelegateExample.Add);
        //Console.WriteLine($"Addition is {obj1(10,20)}");

        //// Multiple Delegats 
        //MultipleDelegate obj2 = new MultipleDelegate(DelegateExample.Cube);
        //obj2 += DelegateExample.Table;
        //obj2.Invoke(2);

        //MultipleDelegate obj3 = new MultipleDelegate(DelegateExample.Table);
        //obj3.Invoke(2);

        //Valuedelegate obj2 = new(DelegateExample.Modulo);
        //obj2 += DelegateExample.Division;
        //obj2.Invoke(10, 20);

        //   MessageDelegate hellcall = new MessageDelegate(Hello);
        //   Console.WriteLine("Hello Function is invoke");
        //   hellcall.Invoke("A");

        //   MessageDelegate callback = new MessageDelegate(Goodbye);
        //   Console.WriteLine("Goodbye Function is  invoke");
        //   callback.Invoke("B");

        //   MessageDelegate message;
        //   MessageDelegate obj;


        //   message = hellcall + callback;
        //   Console.WriteLine($"The Combination of two Function {message}");
        //   message.Invoke("C");

        //   obj = callback - message;
        //Console.WriteLine($"Subtract by Message Object {obj}");
        //   obj.Invoke("D");

        //Basics.AnonymousFunction.Example.Valuedelegat obj = delegate (int val)
        //{
        //    Console.WriteLine($"The Anonymous Method is {val}");
        //};
        //obj.Invoke(100);

        //Basics.AnonymousFunction.Example.Number(delegate (int val)
        //{
        //    Console.WriteLine($"Anumonymous  Function {val}");
        //},100);

        //  FactorialExample.Test();
        //checkPrimeNumber.Test();

        //Console.WriteLine("Enter a Number =");
        //var num = Convert.ToInt32(Console.ReadLine());
        //PriimeorNot obj = new PriimeorNot();
        //obj.Isprime(num);


        //AnonymousExample.Test();
        //AssignmentExample.Test();

        //Basics.Encapsulation.Example obj = new Basics.Encapsulation.Example();
        //obj.MyProperty1 = "ABc";
        //obj.MyProperty2 = 34;
        //Console.WriteLine($"My name is {obj.MyProperty1} \n My Age is {obj.MyProperty2}");

        //obj.Add(10, 5);
        //obj.Sub(20, 10);
        //Console.WriteLine($"Addiiton is  {obj.Add(10,5)} \n Subtration is {obj.Sub(20,10)}");

        //BankBalance bank = new BankBalance();
        //bank.Balance(1000);
        //bank.Deposite(1000);
        //bank.Withdraw(1000);


        //AbstractonExample[] obj1 = new AbstractonExample[] { new AbsactioImplementation(), new Dog() };

        //foreach(AbstractonExample ab in obj1 )
        //{
        //    Console.WriteLine($"The Animal Type {ab.GetType()} goes {ab.sound} ");
        //    ab.Walking();
        //}
        //AbsactioImplementation obj = new AbsactioImplementation();
        //int result =  obj.Add(10, 20);
        //Console.WriteLine($"The Addition {result}");
        // AbtractExample ex = new AbtractExample();
        // ex.MyProperty = "Bil Gates";
        // Console.WriteLine($"Myproperty Output ={ex.MyProperty}");
        //var result = ex.Add(10, 20);
        // Console.WriteLine($"Addition is {result}");
        // ex.MyName("Harvard Stark");

        //GenericExample<string> ex = new GenericExample<string>();
        //ex.Key = "Hello Generics";
        //Console.WriteLine($"The value of Key {ex.Key}");

        //GenericExample<int > ex2 = new GenericExample<int>();
        //ex2.Value = 221;
        //Console.WriteLine($"The Value {ex2.Value}");


        //GenericExample2<string> cities = new GenericExample2<string>();
        //cities.AddorUpdate(0, "Mumbai");
        //cities.AddorUpdate(1, "Nagpur");
        //cities.AddorUpdate(2, "Pune");
        //cities.AddorUpdate(3, "Deheradun");

        //Prints<string> prints = new Prints<string>();
        //prints.Print("Hello Gauvar");

        //ArrayListExample obj = new ArrayListExample();
        //obj.Example();


        //  Student std = new Student(DateTime.Now); //  error :No Parameter 
        //  std.StudentId = 1;
        //  std.StudentName = "AbC";
        //  std.DateOfBirth = new DateTime(1999, 1, 1);
        ////  std.Age = 23;
        //  Console.WriteLine("Student Id ="+std.StudentId);
        //  Console.WriteLine("Student Name ="+std.StudentName);
        //  Console.WriteLine("Student Date of Birth "+std.DateOfBirth);
        //  Console.WriteLine("Age is " +std.Age);

        //ArrayListExample.Example();
        //HashTableExample.Test();
        //DictionaryEample.TestExaple();
        //ListExample.City();


    }
}
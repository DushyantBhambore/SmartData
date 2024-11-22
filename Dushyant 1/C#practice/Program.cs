using C_practice;
using System;
using System.ComponentModel.DataAnnotations;
using static C_practice.CH18_Anonymous_Function;
using static C_practice.CH19_LAMBDA_EXPRESSION;
namespace Csharp
{
    class Program
    {
        static void Main(string[] args)
        {

/*            Console.Write("Enter First Number =");
*//*            int a = int.Parse(Console.ReadLine());*//*
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Second Number = ");
            int b = Convert.ToInt32(Console.ReadLine());
            int c, d, e, f, g;
            c = a + b;
            Console.WriteLine("Addition of  Number {0} and {1} is = {2} ", a, b,c);
            d = a - b;
            Console.WriteLine("Subtraction of  Number {0} and {1} is ={2}  ", a, b,d);
            e = a * b;
            Console.WriteLine("Multiplication of  Number {0} and {1} is = {2} ", a, b,e);
            f = a / b;
            Console.WriteLine("Division of  Number {0} and {1} is = {2}  ", a, b,f);
            g = a % b;
            Console.WriteLine("Modulo of  Number {0} and {1} is = {2}  ", a, b,g);
            Console.WriteLine(int.MaxValue);
            DataTypes.Test()*/;
            //Strings.SubString();
            //CH04_IF_Else_Statement.TernaryOperator();
            //CH05_Switch.switch_statement();
            //CH06_Loops.For_Each_Loop();
            //Marksheet_Problem.Marks_Sheet();
            //CH07_Arrays.LOOPIN_Array();
            // MultiDimentional_Array.Jagged_Array();
            //Array_UserInput.User_Input();
            //  CH08_Methods m1 = new CH08_Methods();
            // m1.Show();
            //CH08_Methods.Show1();
            // CH08_Methods.Add(12,2);
            //CH08_Methods.DefaultValue();
            //CH08_Methods.Show_Name_Age(age: 18, name: "Dushyant"); // here i have used the named argument
            //Console.WriteLine(CH08_Methods.Add1(10, 2)  );

            // Calculator.test();
            //Console.WriteLine("Enter the First Number =");
            //int a = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter the Second Number =");
            //int b = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Enter the Option Do you want to perform (+,-,*,/,%) =");
            //string op = Console.ReadLine();
            //if (op == "+")
            //{
            //    Calculator.Addition(a, b);
            //}
            //else if (op == "-")
            //{
            //    Calculator.Subtraction(a, b);
            //}
            //else if (op == "*")
            //{
            //    Calculator.Multiplication(a, b);
            //}
            //else if (op == "/")
            //{
            //    Calculator.Division(a, b);
            //}
            //else if ((op == "%"))
            //{
            //    Calculator.Modulo(a, b);

            //}
            //else
            //{
            //    Console.WriteLine("Invalid Operation");
            //}

            // CH09_Constructor dd = new CH09_Constructor();

            // c1.Constructor_Overloading(1,2);

            //Copy_Constructor obj = new Copy_Constructor("ABC",21);
            //obj.getdata();
            //// In the copy constructor we have to copy the data from the First instacne of the object 
            //Copy_Constructor obj1 = new Copy_Constructor(obj);
            //obj1.getdata();
            // Private_Constructor p1 = new Private_Constructor();

            //Static_Class.get_productDetails();
            //Static_Class.get_productPrice();
            //            Destructors d = new Destructors("ABC",12); // here i have used named arguments 
            //   Console.WriteLine(d.Getname());
            // Console.WriteLine(d.Getage());
            // Destructors obj = new Destructors();
            //Employee obj = new Employee();
            //  obj.EmpName = "Abc";
            //  obj.EmpDesc = "SEO";
            //  obj.EmpID = 11;

            //  VisitorEmp obj1 = new VisitorEmp();
            //  obj1.EmpName = "NewABC";
            //  obj1.VisitorId = 12;
            //  obj1.VisitorName = "BCU";
            //  obj1.EmpDesc = "Visitor";

            //  PermananetEmp obj2 = new PermananetEmp();
            //  obj2.EmpName = "Dushyant";
            //  obj2.EmpDesc = "Software Develooper";
            //  obj2.EmpID = 35;
            //  Console.WriteLine("This is From Permanent Emp ");
            //  Console.WriteLine(obj2.EmpName + obj2.EmpDesc+obj2.EmpID);
            //  Console.WriteLine("THis is from Visitor class");
            //  Console.WriteLine(obj1.VisitorName + obj1.EmpDesc+obj1.VisitorId);

            //Animal obj = new Animal();
            //Cat obj1 = new Cat();
            //Dog obj2 = new Dog();

            //obj.AnimalSound();
            //obj1.CatSound();
            //obj2.DogSound();

            //Accounts acc = new Accounts();
            //Memebers mm = new Memebers();
            //SpecialAccount sp = new SpecialAccount();

            //acc.Acocount();
            //mm.Acocount();
            //sp.Acocount();
            //AbstractClassImplementation a = new AbstractClassImplementation();

            // Console.WriteLine("Addition usiung Abstract class = "+a.Add(10, 20));
            //a.Cars();
            //a.mercedize();

            //Person per  = new Person();
            //per.SetnameandAge("", -12);
            //per.GetNameandAge();

            //Student std = new Student();
            //std.stuid = -1;
            //Console.WriteLine("Student id is :"+ std.stuid);
            //std.Name = "";
            //Console.WriteLine("Your Name is :"+std.Name);
            //std.Age = 11;
            //Console.WriteLine("Your Age is :"+std.Age);

            //DerivedClass dc = new DerivedClass();
            //dc.Show1(); // After using the sealed keyword in BaseClass we cannot inhetirted it 
            //dc.Show2(); 

            //C cc = new C();
            //cc.Print();

            //HelloDelegate dc = new HelloDelegate(Hello);
            //dc("Heelo From DElegates ");

            //Calculation obj = new Calculation(CH17_Delegates.Addition);
            //obj(10, 20);
            //HelloDelegate obj1 = new HelloDelegate(CH17_Delegates.Hello);
            //obj1.Invoke("Delegates is Invoked");

            //MyDelegates obj = new MyDelegates(CH17_Delegates.cube);
            //Console.WriteLine("Enter for Cube =");
            //var num1 = Convert.ToInt32(Console.ReadLine());
            //obj(num1);
            //Console.WriteLine("Which number table do you want = ");
            //var table = Convert.ToInt32(Console.ReadLine());
            //obj = CH17_Delegates.Table;
            //obj(table);

            //MyMultiCastDelegate obj = new MyMultiCastDelegate(CH17_Delegates.Addition1);
            //obj += CH17_Delegates.Substraction1; // using += Assignment Operator for call another delegate 
            //obj += CH17_Delegates.Multiplication1;
            //obj += CH17_Delegates.Divition1;
            //obj.Invoke(40, 20);

            // Anonymous Function 
            //MyDelegates obj = delegate (int a)
            //{
            //    a += 10;
            //    Console.WriteLine("Result a = " + a);
            //};
            //obj.Invoke(10);

            //MyDelegate2 obj1 =  delegate (int a)
            //{
            //    a += 3;
            //    return a;
            //};

            //Console.WriteLine("MyDelegate2 Result =" + obj1.Invoke(5));

            // Anonymous Fucntion Passing as Parameter 
            //CH18_Anonymous_Function.MyFucntion(delegate (int b) { b += 5; Console.WriteLine("Value of b is :" + b); }, 5);

            // Lambada Expression (=> this is sign of Lamda expression) 

            //  Statement Lambda
            //CH19_LAMBDA_EXPRESSION.MyDelegate obj = (a) =>
            //{
            //    a += 2;
            //    Console.WriteLine("Value of a is =" + a);
            //};

            //CH19_LAMBDA_EXPRESSION.MyDelegate2 obj2 = a =>
            //{
            //    a -= 2;
            //    return a;
            //};
            //Console.WriteLine("Result a :" + obj2(10));

            //// Expression Lambda
            //CH19_LAMBDA_EXPRESSION.MyDelegate2 obj3 = a => a * a;
            //Console.WriteLine(obj3.Invoke(5));

            //AddTwo obj4 = (a, b) => (a + b);
            //int c = obj4(4, 5);
            //Console.WriteLine("Additon of Two Number is :"+c);


            // CH20_GENERIC_CLASSES

            // Using Method 
            //Example<int> e = new Example<int>(10);
            //Console.WriteLine("Value of b is :"+ e.GetValue());
            //Example<string> e1 = new Example<string>("Dushyant");
            //Console.WriteLine("Value of b is :"+e1.GetValue());
            //Example<double> e2 = new Example<double>(12.212);
            //Console.WriteLine("Value b is :"+e2.GetValue());
            //Example<char> e3 = new Example<char>('D');
            //Console.WriteLine("Value of b is :"+e3.GetValue());

            // Using Property 
            // Example<int> e = new Example<int>();
            //// e.MyProperty = 12;
            // Console.WriteLine(e.MyProperty=35);
            // Example<string> e2 = new Example<string>();

            // Console.WriteLine(e2.MyProperty = " Generic Class Invoked");

            // Hashtable 
            //CH07a_Hashtable.CH7aHashtable();

            // Stacks
            // CH07B_Stack.TestStack();

            // Queue 
            // CH07C_Queue.TestQueue();

            // List 
            //CH07D_List_Generic_Collection.TestList();

            //Dictionary
            //CH07e_Dictionary_Generic_Collection.TetsDictionary();

            // Exception Handling 
            // CH21_Exception_Handling.ExceptionClass();

            // THreading
            //CH22_Multi_Treading.Tets();
            //CH22_Multi_Treading.Function1();
            //CH22_Multi_Treading.Function2();
            //CH22_Multi_Treading.Function3();
            //Thread t1 = new Thread(CH22_Multi_Treading.Function1);
            //Thread t2 = new Thread(CH22_Multi_Treading.Function2);
            //Thread t3 = new Thread(CH22_Multi_Treading.Function3);

            //t1.Start();
            //t2.Start();
            //t3.Start();

            //            CH23_File_Handling.test();

            //Dependency Injection 
            // DI through Constructor  

            // Loosesly  Coupled Code 
            //iaccount ca = new currentaccount();
            //account a = new account(ca);
            //a.printaccount();

            //iaccount sa = new savingaccount();
            //account a1 = new account(sa);
            //a1.printaccount();

            // Tight Coupled Code 
            //Account a = new Account();
            //a.PrintAccount();

            // DI through Property 
            //Account1 sa = new Account1();
            //sa.account1 = new SavingAccount1();
            //sa.PrintAccount1();

            //Account1 ca = new Account1();
            //ca.account1 = new CurrentAccount1(); 
            //ca.PrintAccount1();

            // DI through Methods
            //Account2 sa = new Account2();
            //sa.PrintAccount( new SavingAccount2());

            //Account2 ca = new Account2();
            //ca.PrintAccount(new CurrentAccount2());

            // Enum 
            CH25_Enum_.Test();
            //Console.WriteLine(Days.ThursDay);

            //Days d = Days.Monday;
            //Console.WriteLine(d);

            // Explicit Type casting in enum 

            //int number = (int)Days.FriDay;
            //Console.WriteLine(number);

            //Days days = (Days)10;
            //Console.WriteLine(days);

        }
    }
}
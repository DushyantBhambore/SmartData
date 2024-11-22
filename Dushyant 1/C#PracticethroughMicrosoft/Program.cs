// See https://aka.ms/new-console-template for more information

using C_PracticethroughMicrosoft;
using C_PracticethroughMicrosoft.AbstactExample;
using C_PracticethroughMicrosoft.AccesModifier;
using C_PracticethroughMicrosoft.Delegate;
using C_PracticethroughMicrosoft.Struct_And_Class;
using C_PracticethroughMicrosoft.TypeInfeerence;

internal class Program
{

    private static void Main(string[] args)
    {
        //   CH01_Variable.Test2();

        /*        Record Usage 
                   A Record is reference type in c# primarily used for immutable data model and support value-based equality */
        /*        CH02_Classes_and_Objects.Person person1 = new CH02_Classes_and_Objects.Person("Bill", "gates");
                CH02_Classes_and_Objects.Person person2 = new CH02_Classes_and_Objects.Person("Bill", "Stark");
                Console.WriteLine(person1==person2);*/

        // Abstract Class

        /*Dog dog = new Dog();
        dog.AnimalSound();
        dog.Sleep();

       CarsColour obj = new CarsColour();
        obj.BMW();
        obj.Model();*/

        // Delegates 
        /*        Mydelegate obj = new Mydelegate(Addition);*/

        /*        ClassExample obj = new ClassExample();
                obj.TestClass("Bill", 34, "4455669988", 50000.00);*/

        /*        Emplyoee emp = new Emplyoee();
                emp.TestClass("BIll", 34, "4455669978", 45632.165);
                emp.ChildTesgt("Gates", "2151323654", 18, 3000);

                StructExampleCar car ;
                car.ModelName = "BMW";
                car.ColorName = "red";
                car.Features = "EV car";
                // car.Test("BMW", "red","Ev car"); // Eror is Unassign Local Variable
                Console.WriteLine($"Car Model Name is {car.ModelName} \n Car Color {car.ColorName} \n Car Features {car.Features}");*/


        /*        Child1 child1 = new Child1();
                child1.PublicMethod();
                child1.ChildClass();
                child1.InternalMethod();*/

        /*        Student std = new Student();
                std.StudentId = 1;
                std.StudentName = "test";
                std.DateOfBirth = new DateTime(1999, 11, 30);

                Console.WriteLine("Student Id is "+std.StudentId);
                Console.WriteLine("Student Name is "+std.StudentName);
                Console.WriteLine("Student Date Of Birth  is "+std.DateOfBirth);
                Console.WriteLine("Student Age is "+std.Age);*/


        // Delegates 
        /*        Student.Delegate();*/

        // ** Type Inference  : - Important Topic
        /*     TypeInferenceImpotrantTopic.Test();*/

        AdvanceDelegate.TaskDelegate1();

    }

}
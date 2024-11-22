using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_PracticethroughMicrosoft.Struct_And_Class
{
    internal class Example_Strcut_Class
    {
        
    }

    public class ClassExample
    {
        public string? name;
        public int age;
        public string? number;
        public double salary;

        public  void TestClass(string name , int age,string number , double salary)
        {
            this.name = name;
            this.age = age;
            this.number = number;
            this.salary = salary;

            Console.WriteLine($"Name is {this.name} \n Age is {this.age} \n Number is {this.number} \n Salary is {this.salary} ");
        }
    }

    public class Emplyoee : ClassExample
    {
        public void ChildTesgt(string name , string number,int age , double salary )
        {
            this.name = name;
            this.age = age;
            this.number = number;
            this.salary =salary;

            Console.WriteLine($"Child Name {name} \n Child Number {number} \n Child age  {18} \n child salary  {salary} ");
          
        }
    }

    public struct StructExampleCar
    {
        public string ColorName;
        public string ModelName;
        public string Features;

    }

    /*public struct ChildCar : StructExampleCar // we cannot inherited the struc class 
    {

    }*/
}

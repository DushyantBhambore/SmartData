using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH15_Encapsulation
    {
        ///<summary>
        ///Encapsulation in  c# is a mechanism of wrapping the data(variable) and code acting on the data (mehtods or properties) together as a single unit 
        ///
        /// In encapsulation the variable of class will be hidden from other classes and can be accessed only through the methodds or properties of their current class . Therefore it is also known as data hiding 
        /// 
        /// Applicationn
        /// 
        /// Declare the cariable of a class as private 
        /// Provide public setter and getter method or properties to modifty and view the variable value
        /// 
        /// </summary>
        /// 

   
    }
}
// Encasulation Acesss throught Methods 
class Person
{
    private string Name;
    private int Age;

    public void SetnameandAge(string name, int age)
    {
        if ((string.IsNullOrEmpty(name)==true && age<0))
        {
            Console.WriteLine("The Name is Required and Age Should not zero or negative ");
        }
        else
        {
            this.Name = name;
            this.Age = age;
        }
    }

    public void GetNameandAge()
    {
        if ((string.IsNullOrEmpty(this.Name)==true && Age < 0))
        {

        }
        else
        {
            Console.WriteLine("Your Name is :" + this.Name);
            Console.WriteLine("Your Age is :" + this.Age);
        }

    }
}

// Encapsulation Acess through Properties 
class Student
{
    private int  StuId;
    private string? name;
    private int age;

    public string? Name
    {
        set
        {
            if(string.IsNullOrEmpty(value)==true)
            {
                Console.WriteLine("Name SHould not be empty ");
            }
            else
            {
                this.name= value; 
            }
        }
        get
        {
            return this.name;
        }
    }

    public int stuid
    {
        set
        {
            if(value<=0)
            {
                Console.WriteLine("Id is not zero ");
            }
            else
            {
                this.StuId = value;
            }
        }
        get
        {
            return this.StuId;
        }
    }

    public int Age
    {
        set
        {
            if(value<0)
            {
                Console.WriteLine("Age Should Not be zero ");
            }
            else
            {
                this.age = value;
            }
        }
        get
        {
            return this.age;
        }
    }

}

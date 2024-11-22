using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH07D_List_Generic_Collection
    {
        ///<summary>
        ///
        /// A List is one of the generic collection classes in the " System.Collection.Generic";
        /// 
        /// An ArrayList resizes automatically as it grows (Auto Resizing )
        /// 
        /// The List<T> collection is the same as an ArrayList except that List<T> is a generic collection whereas ArratyList is a non-generic collection 
        /// 
        /// A List class can be used to create a collection of any type 
        /// 
        /// For Example , we can create a List of integers, strings and even any complex types 
        /// 
        /// List<T> class can accept null as a valid for reference type and it also duplicate elements 
        /// 
        /// Why to Use A List 
        /// 
        /// Unlike arrays a List can grow in size automatically in other words a List  can be re-sized dynamatically but arrays cannpt 
        /// 
        /// List is generic type 
        /// 
        /// List is type safe 
        /// 
        /// The List class also provides methods to search , sort , and manipulate Lists 
        /// 
        /// 
        /// Properties Of List<T>
        /// 
        ///Capacity - Gets or sets the total number of elements the internal data structure can holds
        ///
        /// Count - GEt the number of element contained in the List<T>
        /// 
        /// Add - Adds an object to the end of the List<T> 
        /// 
        /// AddRange() - Adds the elements of the specified collection to the end of the List<T>
        /// 
        /// Insert() - Inserts an element into the List<T> at the specified index 
        /// 
        /// InserRange() - Insert the elements of a collection into the List<T> at the specific index
        /// 
        /// Remove() - Remove the First occurrence of a specific object from the List<T>
        /// 
        /// 
        /// RemoveAt() - Remove the element at the specified index of the List<T>
        /// 
        /// RemoveRange() - Remove a range of element from the List<T>
        /// 
        /// RemoveAll() - Remove all the elements that match the condition defined by the specified predicate ( create a lambda expression ).
        /// 
        /// Contains() or Exists - Determines whether an element is in the Lis<T>
        /// 
        /// Reverse() - Reverse the  order of the elements in the List<T> or a portion of it 
        /// 
        /// Sort() - Sort the elements or a potion of the elementsin the List<T>
        /// 
        /// IndexOf() - Returns the zero-based index of the first occurrence of value in the List<T>
        /// 
        /// LastIndexOf() - Return the zero-based index of the last occurrence of value in the List<T
        /// 
        /// Clear() - Remover all elements from the List<T>
        /// 
        /// Find() - Searches for an elemenr that matches the condition defined by the specified predicate , and return the first occurrence within the entire List<T>
        /// 
        /// FindLast() - Searches for an element that matches the condition defined by the specified predicate and return the Last Occurrence within the entire List<T>
        /// 
        /// FindAll() - Retrives all the elements that match the conditions defined by the specified predicate
        /// 
        /// FindIndex() = Searches for an element that matches the condition defined by a specified predicate and return the zero-based index of the first occurrence within the List<T> or a portion of it . This method returns -1 if an item that methods the condition is not found 
        /// 
        /// FindLatIndex() - Searches for an element that matches the condition by a specified predicate, and returns the zero-based index of the last occurrence within the List<T> or a portion o it 
        /// 
        /// ToArray() - Copies the element of the List<T> to a new array .
        /// 
        /// ToList()  - Copies the elements of the array to a new List 
        /// 
        /// </summary>
        /// 

        public static void TestList()
        {
            List<int> mynumber = new List<int>();
            mynumber.Add(11);
            mynumber.Add(21);
            mynumber.Add(33);
            mynumber.Add(44);
            mynumber.Add(22);

            Console.WriteLine(mynumber.Capacity); //8
            mynumber.Add(55);
            mynumber.Add(71);
            mynumber.Add(88);
            mynumber.Add(99);
            mynumber.Add(100);
            mynumber.Add(121);
            //Console.WriteLine("Capacity = "+mynumber.Capacity); // 16
            //Console.WriteLine("Number of Count = " + mynumber.Count);

            //  Console.WriteLine("Index of the number = "+mynumber.IndexOf(99));
            //Console.WriteLine("Shos the Last Index of the List ="+mynumber.LastIndexOf(55));

            foreach (int i in mynumber)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("------------");
            Console.WriteLine("Number of Count = " + mynumber.Count);
            //mynumber.AddRange(mynumber);
            //mynumber.Insert(2, 100);
            mynumber.Sort();
            // mynumber.InsertRange(9,mynumber);
            //mynumber.Remove(44);
            //mynumber.Remove(55);
            //mynumber.RemoveAt(mynumber.Count - 5);
            // mynumber.RemoveRange(0,mynumber.Count-4);
            //Console.WriteLine(mynumber.Contains(44));
            // mynumber.Reverse();
            mynumber.Clear();
           
            Console.WriteLine("------------");
            foreach (int i in mynumber)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine("Number of Count = " + mynumber.Count);

            Console.WriteLine("----------------");
            List<string> mynames = new List<string>();
            mynames.Add("dushyant");
            mynames.Add("aakash");
            mynames.Add("abhay");
            mynames.Add("Yash");
            mynames.Add("Himanshu");
            mynames.Add("Rishabh");
            mynames.Add("Atul");
            mynames.Add("null");
            mynames.Add("Atul");

            Console.WriteLine(mynames.Capacity);

            foreach (var item in mynames)
            {
                Console.WriteLine(item);
            }


            Employe emp1 = new Employe()
            {
                empid = 11,
                empname = "Aakash",
                Desgination = "AI Developer",
                Experice = 0
            };

            Employe emp2 = new Employe()
            {
                empid = 22,
                empname = "Harshal",
                Desgination = "Java Developer ",
                Experice = 2
            };
            Employe emp3 = new Employe()
            {
                empid = 33,
                empname = "Abhay",
                Desgination = "PHP Developer",
                Experice = 3
            };
            Employe emp4 = new Employe()
            {
                empid = 44,
                empname = "Karan",
                Desgination = "Python Developer",
                Experice = 4
            };
            Employe emp5 = new Employe()
            {
                empid = 55,
                empname = "Dushyant",
                Desgination = ".NET Developer",
                Experice = 5
            };


            List<Employe> empList = new List<Employe>();
            empList.Add(emp1);
            empList.Add(emp2);
            empList.Add(emp3);
            empList.Add(emp4);
            empList.Add(emp5);

            foreach (Employe emp in empList)
            {
                Console.WriteLine($"Employee Name is ={emp.empname} and Designation is ={emp.Desgination} also with Experice of ={emp.Experice}");
            }

            Student std1 = new Student()
            {
                stuid = 1,
                sname = "Aakash",
                sclass = 12,
                sage = 18,
            };

            Student std2 = new Student()
            {
                stuid = 2,
                sname = "Abhay",
                sclass = 10,
                sage = 15,
            };
            Student std3 = new Student()
            {
                stuid = 3,
                sname = "Yash",
                sclass = 10,
                sage = 14,
            };
            Student std4 = new Student()
            {
                stuid = 4,
                sname = "Sushant",
                sclass = 10,
                sage = 15,
            };
            Student std5 = new Student()
            {
                stuid = 5,
                sname = "Yash",
                sclass = 10,
                sage = 15,
            };


            List<Student> std = new List<Student>();
            std.Add(std1);
            std.Add(std2);
            std.Add(std3);
            std.Add(std4);
            std.Add(std5);


            
            Console.WriteLine("-------------------Students Data---------- ");

            Student[] findall = std.ToArray();
            Console.WriteLine("List is converted into Array ");
            foreach (Student student in findall)
            {
                Console.WriteLine($"This is ToArray Method , Student Id is = {student.stuid},  Student Name is = {student.sname} and Student Age is = {student.sage} and Student Class is = {student.sclass} ");

            }

            List<Student> mylist = std.ToList();
            Console.WriteLine("List ");
            foreach (Student student in mylist)
            {
                Console.WriteLine($"This is ToList Method   , Student Id is = {student.stuid},  Student Name is = {student.sname} and Student Age is = {student.sage} and Student Class is = {student.sclass} ");

            }

            Console.WriteLine("This is findIndex = " + std.FindIndex(s => s.sage > 10));
            Console.WriteLine("This is FindLastIndex = " + std.FindLastIndex(s => s.sage > 10));
            Student? stdd = std.Find(s => (s.sname == "Yash"));

            Console.WriteLine($"THis is Find ,  Student Id is : {stdd.stuid}  ,Student Name is = {stdd.sname} and Student Age is = {stdd.sage} and Student Class is = {stdd.sclass} ");

            Student? stu = std.FindLast(s => s.sname == "Yash");
            Console.WriteLine($"This is FindLast , Student Id is = {stu.stuid},  Student Name is = {stu.sname} and Student Age is = {stu.sage} and Student Class is = {stu.sclass} ");

           //List<Student> findall = std.FindAll(s => s.sname == "Yash");

            //foreach(Student student in findall)
            //{
            //    Console.WriteLine($"This is FindAll , Student Id is = {student.stuid},  Student Name is = {student.sname} and Student Age is = {student.sage} and Student Class is = {student.sclass} ");

            //}




            //foreach (Student student in std)
            //{
            //    Console.WriteLine($"Student Name is = {student.sname} and Student Age is = {student.sage} and Student Class is = {student.sclass} ");
            //}
            // std.RemoveAll(std => std.sage > 14);

            //Console.WriteLine("-------------------");


            //foreach (Student student in std)
            //{
            //    Console.WriteLine($"Student Name is = {student.sname} and Student Age is = {student.sage} and Student Class is = {student.sclass} ");
            //}

            Console.WriteLine(std.Exists(std => std.sname=="A"));

        }

    }


    public class Employe
    {
        public int? empid { get; set; }
        public string? empname { get; set; }
        public string? Desgination { get; set;}
        public int Experice { get; set; }

    }

    class Student
    {
        public int stuid { get; set; }
        public string? sname { get; set; }
        public int? sage { get; set; }
        public int sclass { get; set; }
    }
}

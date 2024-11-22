

using DailyLecture._09_09_24;
using DailyLecture._09_09_24.Practice;
using DailyLecture._11_09_24;

internal class Program
{
    public delegate void showDelegate();
    private static void Main(string[] args)
    {
        //List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        //  var selectQ = (from li in list
        //                 select li).ToList();

        //  var selectF = list.Select(x => x).ToList();

        //  selectF.ForEach(x => Console.WriteLine(x));

        //  var whereQ = (from li in list
        //                where li % 2 == 0
        //                select li).ToList();

        //  var whereM = list.Where(li => li % 2 != 0).ToList();

        //  var orderrByQ = (from li in list
        //                   orderby li descending
        //                   select li).ToList();

        //  var orderByM = list.OrderDescending().ToList();

        //  orderByM.ForEach(x => Console.WriteLine(x));

        //  List<Student1> students = new List<Student1>()
        //  {
        //      new Student1(){Id=1,Name="Chetan"},
        //       new Student1(){Id=2,Name="Rahul"},
        //        new Student1(){Id=3,Name="Ramesh"},
        //         new Student1(){Id=4,Name="Riya"},
        //  };

        //  List<Marks> marks = new List<Marks>()
        //  {
        //      new Marks(){StId=2,StMarks=80},
        //      new Marks(){StId=1,StMarks=90},
        //      new Marks(){StId=3,StMarks=86},
        //      new Marks(){StId=4,StMarks=70},
        //  };

        //  var joinM = students.Join(marks,
        //                            st => st.Id,
        //                            mr => mr.StId,
        //                            (st, mk) => new
        //                            {
        //                                StudentName = st.Name,
        //                                StidemtMarks = mk.StMarks,
        //                            });

        //  var joinQ = (from st in students
        //               join mk in marks
        //               on st.Id equals mk.StId
        //               select new
        //               {
        //                   StudentName = st.Name,
        //                   StidemtMarks = mk.StMarks,
        //               }).ToList();

        //  foreach (var item in joinQ)
        //  {
        //      Console.WriteLine($"Name : {item.StudentName}, Marks : {item.StidemtMarks}");
        //  }
        //  List<string> names = new List<string>() { "Chetan", "Dushyant" };

        //  var selectManyQ = (from str in names
        //                     from ch in str
        //                     select ch).ToList();

        //  var selectManyM = names.SelectMany(x => x).ToList();

        //  selectManyM.ForEach(x => Console.WriteLine(x));    }

        ExtensionMethodExample();
    }
    class Student1
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    class Marks
    {
        public int StId { get; set; }
        public int StMarks { get; set; }
    }

    private static void ListExaple()
    {
        var list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        var list2 = GetEvenNumber(list);
        var list3 = GetOddNumber(list);
        Console.WriteLine("Even Number");
        foreach (var item in list2)
            Console.WriteLine(item);
        Console.WriteLine("Odd Number is ");
        foreach (var item in list3) Console.WriteLine(item);


        // METHOD 1 BY USING METHOD EXTENSION USING DELEGTE 
        // here i have check the condition by using the predicate delegate 
        Console.WriteLine("Get Even Number By using delegates ");
        foreach (var item in GetEvenByDelegates(list, x => x % 2 == 0)) // using lambada function 
        {
            Console.WriteLine(item);
        }
        // METHOD 2 BY USING METHOD EXTENSION USING DELEGTE 

        Predicate<int> predicate = (x) => x % 2 != 0;
        Console.WriteLine("Get Odd Number By Using delegates");
        foreach (var item in GetOddByDelegates(list, predicate))
        {
            Console.WriteLine(item);
        }

        // METHOD 3 BY USING METHOD EXTENSION USING DELEGTE 
        Console.WriteLine("Get Multiple BY 3");
        foreach (var item in GetOddByDelegates(list, GetMulipleBY3))
        {
            Console.WriteLine(item);
        }
    }

    //METHOD 3
    private static bool GetMulipleBY3(int data)
    {
        return data % 3 == 0;
    }
    //METHOD 1

    private static List<int> GetEvenByDelegates(List<int> list, Predicate<int> predicate)
    {
        var list2 = new List<int>();

        foreach (var item in list)
        {
            if (predicate(item)) list2.Add(item);
        }
        return list2;

    }
    //METHOD 2

    private static List<int> GetOddByDelegates(List<int> list, Predicate<int> predicate)
    {
        var list3 = new List<int>();

        foreach (var item in list)
        {
            if (predicate(item)) list3.Add(item);
        }
        return list3;
    }


    private static List<int> GetEvenNumber(List<int> list)
    {
        var list2 = new List<int>();

        foreach (var item in list)
        {
            if (item % 2 == 0)
                list2.Add(item);
        }
        return list2;
    }

    private static List<int> GetOddNumber(List<int> list)
    {
        var list3 = new List<int>();

        foreach (var item in list)
        {
            if (item % 2 != 0)
                list3.Add(item);
        }
        return list3;
    }

    private static void ExtensionMethodExample()
    {
        var student = GetStudent();

        Console.WriteLine("Age " + StudentExtension.CalculateAge(student));
        Console.WriteLine("Age Via ExntensionMethod " + student.CalculateAge());
        Console.WriteLine("Age via ExtensionMethod and also one Overload is " + student.CalculateAge(DateTime.Now));
    }

    public static void Test()
    {
        //Student std = new Student(DateTime.Now);
        //std.StudentName = "Abc";
        //std.StudentId = 1;
        //std.DateOfBirth = new DateTime(1999, 09, 09);
        //Console.WriteLine("Student Id ="+std.StudentId);
        //Console.WriteLine("Student Name  ="+std.StudentName);
        //Console.WriteLine("Student Date Of Birth  ="+std.DateOfBirth);
        //Console.WriteLine("Student Age ="+std.Age);

        //Student.Test();

        //DelegateExample();

        // First Object 



        //AnonymousExample.Example();


        //Mydelgate obj = new Mydelgate(Show);
        //obj();

        //Practice1 std = new Practice1();
        //std.TestWork();

        //Practice1.MyWork();

        Practice2.Test();
    }

    private static Student GetStudent()
    {
        return new Student(DateTime.Now)
        {
            StudentId = 35,
            StudentName = "Tony",
            DateOfBirth = new DateTime(2003, 01, 09),

        };
    }



}
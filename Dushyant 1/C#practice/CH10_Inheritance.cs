using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH10_Inheritance
    {
        ///<summary>
        ///it is possible to inherit fields and methods from one class to another. We group the "inheritance concept" into two categories:
        ///
        /// Derived Class (child) - the class that inherits from another class
        /// Base Class (parent) - the class being inherited from
        /// 
        /// To inherit from a class, use the : symbol.
        ///</summary>

    }

    public class Employee // Parent class or Base classs
    {
        public int EmpID;
        public string? EmpName;
        public string? EmpDesc;
    }
    public class VisitorEmp:Employee // Child Class or Derived Class
    {
        public int VisitorId;
        public string? VisitorName;
    }
    public class PermananetEmp:Employee // Child Class or Derived Class 
    {
        public string? PerEmp;
        public int PermananetID;
        public string? PermananetDescs;
    }

}


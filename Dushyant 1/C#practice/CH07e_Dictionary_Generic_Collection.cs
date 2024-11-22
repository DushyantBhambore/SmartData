using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH07e_Dictionary_Generic_Collection
    {
        ///<summary>
        ///
        /// Now we want to create a collection in which we dont want to access elements through index 
        /// 
        /// We want to store data in key value formate where keys are user-defined 
        /// 
        /// We want to insert same type of data in a collection 
        /// 
        /// 
        /// </summary>
        /// 

        public static void TetsDictionary()
        {
            Dictionary<string, string> mydictionary = new Dictionary<string, string>();
            mydictionary.Add("A", "A for Apple ");
            mydictionary.Add("B", "B for ball");
            mydictionary.Add("C", "C for Cat");
            mydictionary.Add("D", "D for Dog");
            mydictionary.Add("E", "E for eggs");

            foreach(KeyValuePair<string, string> kvp in mydictionary)
            {
                Console.WriteLine("Key is :"+kvp.Key +"and " + "Value is :" +kvp.Value);
            }
        }
    }
}

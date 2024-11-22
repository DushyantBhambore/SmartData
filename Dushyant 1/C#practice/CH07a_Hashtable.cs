using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_practice
{
    public class CH07a_Hashtable
    {
        ///<summary>
        ///
        /// HashTable store in key/value formate.
        /// 
        /// Array and ArrayList also stores data in key/value format.
        /// 
        /// In Array or ArrayList keys are pre-defined i.e index numbers, it means you cannot explicitly define keys in Array or ArrayList 
        /// 
        /// In HashTable , Keys are not pre-defined it means you can explicitly define user-define key in Hashtable 
        /// 
        /// key may be any either string , int , char etc;
        /// 
        /// The HashTable collection stores key value pairs.
        /// 
        /// The Hashtable class represents a collection of key and value pairs that are organized based on the hash code of the key 
        /// 
        /// it uses the key to access the elements in the collection 
        /// 
        /// A hash table is used when you needto access element by using key and you can identify key value 
        /// 
        /// Each item in the hash table has a key/value pair . The Key is used to access the items in the collection 
        /// 
        /// Methods Of Hash Table 
        /// 
        /// Add : Adds an item with key and value into the hashtable 
        /// 
        /// Remove : Removes the item with the specified key from the hashtable .
        /// 
        /// Clear : Removes all the items from the hashtable
        /// 
        /// Contains : Check whether the hashtable contains a specific key 
        /// 
        /// ContainsKey : Checks Whether the hastable contains a specific key.
        /// 
        /// ConatainsValue : Checks whether the hashtable contains a specific value .0  
        /// 
        /// GetHashCode : Return the hash code for the specified key 
        ///Hashtable used Hashing Algorithm To generate hash codes for every key and Beacuse of these hash codes hash tables are faster than Array and ArrayList
        ///
        /// 
        /// Properties :
        /// Count : Get the total count of key/value pairs in the hashtable 
        /// 
        /// Keys : Gets an ICollection of Keys in the hashtable 
        /// 
        /// Values : Gets an ICollection of values in the hashtable 
        /// 
        /// </summary
        /// 
        public static void CH7aHashtable()
        {
            Hashtable ht = new Hashtable();
            ht.Add("id", 112);
            ht.Add("name", "Dushyant");
            ht.Add("Cname", "Smartdata");
            ht.Add("Address", "Nagpur");
            ht.Add("pincode", 440032);
            ht.Add("salary", 500000);

            //Console.WriteLine(ht["salary"]);
            //Console.WriteLine(ht["name"]);

            Console.WriteLine(ht.Count);
            Console.WriteLine(ht.Values);
            Console.WriteLine(ht.Keys);

            Console.WriteLine("name".GetHashCode());
            Console.WriteLine(ht.Contains("name"));
            Console.WriteLine(ht.ContainsKey("Cname"));
            Console.WriteLine(ht.ContainsValue("Nagpur"));


            foreach (object i in ht.Keys)
            {
                Console.WriteLine(i + " = "+ ht[i]);
            }

            ht.Remove("Address");
            Console.WriteLine("-----------");
            foreach (object i in ht.Keys)
            {
                Console.WriteLine(i + " = " + ht[i]);
            }

            ht.Clear();
            Console.WriteLine("----------");
            foreach (object i in ht.Keys)
            {
                Console.WriteLine(i + " = " + ht[i]);
            }


        }
    }
}

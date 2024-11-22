using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace C_practice
{
    public class CH23_File_Handling
    {
        ///<summary>
        ///
        /// File Handling allowa to store/ rerive data on permanent storage 
        /// 
        /// File and its data can be handled programmatically 
        /// 
        /// When a file is opened for reading or writing it become a stream.
        /// 
        /// The stream is basically the sequence of bytes passing through the communication path. 
        /// The two main streams :
        /// Input Streams : Input Stream is used for reading data from the file 
        /// Ouput Stram : It is used to writing into the file (write operation).
        /// 
        /// The .net framework provides a few basic class for creating , reading , and writing to files on the secondary storage and for retriving file system information 
        /// 
        /// They are located in the System.IO namespace 
        /// 
        /// *********Classes Used In File Handling ***
        /// 
        /// FileStram, BinaryReader, BinaryWriter,StreamWriter,StreamReader,StringReader,StrinigWriter,DirectoryInfo,FileInfo
        /// 
        /// 
        /// ********* Directory INFO Class ******
        /// 
        /// it is used to create, delete and move directory .
        /// 
        /// </summary>
        /// 
        public static void test()
        {
            string path = @"D:\data.txt"; // verbatim literal 
            string path2 = @"D:\data1.txt";

            if (File.Exists(path))
            {

                    Console.WriteLine("File is Exists ");
                string data1 = File.ReadAllText(path);
                Console.WriteLine(data1);



            }
            else
            {
                Console.WriteLine("File is not Found ");
            }
            //File.Copy(path, path2);
            File.Copy(path, path2, true);

            if(File.Exists(path2)) 
            {
                Console.WriteLine("File is Exsist ");
                Console.WriteLine(File.ReadAllText(path2));
            }
            else
            {
                Console.WriteLine("File is not Found");
            }
        }
    }
}

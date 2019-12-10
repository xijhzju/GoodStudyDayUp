using System;
using System.IO;//For FileStream
//Analysis of memory leak with an example of file handling
/* Special note: To use the CLR profiler:
use the command: csc /t:exe /out:AnalyzingLeaksWithFileHandlingEx1.exe
Program.cs to compile
General Rule: csc /out:My.exe File.cs <- compiles Files.cs and
creates My.exe
(you may need to set the PATH environment variable in your system)*/
namespace AnalyzingLeaksWithFileHandlingEx1
{
    class Program
    {
        class FileOps
        {
            public void readWrite()
            {
                for (int i = 0; i < 1000; i++)
                {
                    String fileName = "Myfile" + i + ".txt";
                    String path = @"f:\MyFile\" + fileName;
                    {
                        FileStream fileStreamName;
                        try
                        {
                            fileStreamName = new FileStream(path,
                            FileMode.OpenOrCreate, FileAccess.ReadWrite);
                            //using (fileStreamName = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                            
                            //用using实现的话，即便有Exception，最后也会关闭文件

                            //According to Microsoft, the using statement ensures that the Dispose() method is called even
                            //if an exception occurs while you are calling methods on the object.You can achieve the same
                            //result by putting the object inside a try block and then calling the Dispose() method in a finally
                            //block; in fact, this is how the using statement is translated by the compiler.
                            //具体见363页
                            {
                                Console.WriteLine("Created file no :{0}", i);
                                //Forcefully throwing an exception , so that we cannot close the file
                                if (i < 1000)
                                {
                                    throw new Exception("Forceful  Exception");
                                }
                            }
                            // FileStream not closed
                            // fileStreamName.Close();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Caught exception" + e);
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            FileOps filePtr = new FileOps();
            {
                filePtr.readWrite();
                Console.ReadKey();
            }
        }
    }
}
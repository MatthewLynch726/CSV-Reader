using System;
using static System.Net.Mime.MediaTypeNames;

namespace CSV_Reader
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using (var reader = new StreamReader(@"C:\Test\CSV-File.csv"))
            {
                Console.WriteLine("Test!");
                List<string> listA = new List<string>();
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(';');

                    foreach (var i in values)
                    {
                        Console.WriteLine(i);
                    }
                }
            }
        }
    }
}

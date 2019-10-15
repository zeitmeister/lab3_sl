using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookService
{
    public static class WriteToFile<T>
    {
        public static void WriteToTextFile(IEnumerable<T> list)
        {
            using (StreamWriter outputFile = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\" + "../../files/queryResult.txt"))
            {
                foreach (var book in list)
                {
                    outputFile.WriteLine(book);
                }
            }
        }
    }
}

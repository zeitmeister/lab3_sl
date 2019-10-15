using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BookService
{
    static class WriteToFile<T>
    {
        public static void WriteToTextFile(IEnumerable<T> list)
        {
            string docPath = AppDomain.CurrentDomain.BaseDirectory + @"\" + "../../files/queryResult.txt";
            using (StreamWriter outputFile = new StreamWriter(docPath))
            {
                foreach (var line in list)
                    outputFile.WriteLine(line);
            }
        }
    }
}

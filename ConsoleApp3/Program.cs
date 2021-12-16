using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    internal class Program
    {
        
        static async Task Main(string[] args)
        {
            string folderPath = Directory.GetCurrentDirectory();

            string[] files = Directory.GetFiles(folderPath, "*.txt", SearchOption.TopDirectoryOnly);

            string pattern = "";

            RegexFileSpliter spliter = new RegexFileSpliter(pattern);

            foreach (string file in files)
            {
                await spliter.SplitAsync(file, x => string.Join(" ", x));
            }
        }
    }
}

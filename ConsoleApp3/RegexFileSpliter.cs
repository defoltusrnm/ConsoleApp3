using System;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    public class RegexFileSpliter
    {
        private readonly Regex _regex;

        public RegexFileSpliter(string pattern)
        {
            _regex = new Regex(pattern);
        }
        
        public async Task SplitAsync(string path, Func<string[], string> joinFunc)
        {
            using StreamReader reader = File.OpenText(path);
            using StreamWriter writer = File.CreateText($"{Path.GetFileNameWithoutExtension(path)}Parsed.txt");

            do
            {
                string line = await reader.ReadLineAsync();

                await writer.WriteLineAsync(joinFunc(_regex.Split(line)));
            }
            while (!reader.EndOfStream);
        }

    }
}

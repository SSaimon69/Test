using System.Diagnostics.Metrics;
using System.Security.Cryptography;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> map = TextToUniqDict(new string[] 
            { ",", ".", " "," ", ";", ":", "?", "!", "\"", "(", ")", "—","–", "[", "]", "»","«" },
            "text.txt");

            DateTime firstTime = DateTime.Now;

            //Сортировка
            var sort = map.OrderByDescending(x => x.Value);

            //Вывод в файл
            using (StreamWriter sw = File.CreateText("textOut.txt"))
            {
                foreach (var x in sort)
                {
                    sw.WriteLine(x.Key + " " + x.Value);
                }
            }

            Console.WriteLine("Затрачено времени: " + (DateTime.Now - firstTime).TotalSeconds + " секунд");
        }

        static Dictionary<string, int> TextToUniqDict(string [] separators, string filePath)
        {
            Dictionary<string, int> map = new Dictionary<string, int>();

            using (StreamReader sr = File.OpenText(filePath))
            {
                string? s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    string[] mas = s.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string ma in mas)
                        if (map.ContainsKey(ma)) map[ma]++;
                        else map.Add(ma, 1);
                }
            }

            return map;
        }


    }
}
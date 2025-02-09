using System.Threading.Channels;
using System.Xml.Linq;

namespace FunctionalProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // (parameter) => (result)
            // запазване в променлива
            var function = (string name, string lastName) => name.StartsWith("E") && lastName.StartsWith("E"); // това е функция, където гледа параметъра name, да започва с e
        }
    }
}

/* --- рекурсия
static void Main(string[] args)
{
    PrintN(0, 100);
}
public static void PrintN(int start, int end)
{
    if (start == end) //ако старт стане равно на end
    {
        return;
    }
    Console.WriteLine(start); */
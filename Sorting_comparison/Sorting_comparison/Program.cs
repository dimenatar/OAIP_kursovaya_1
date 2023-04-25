namespace Sorting_comparison
{
    internal class Program
    {
        static void Main(string[] args)
        {
            OutputHelper.OutputTableToConsole(new List<string>() { "Название алгоритма", "Затраченное время", "Затраченная память" }, new List<List<string>>() { new List<string>() { "1", "2", "3" } });
        }
    }
}
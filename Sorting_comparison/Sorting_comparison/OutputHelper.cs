using ConsoleTables;

namespace Sorting_comparison
{
    public static class OutputHelper
    {
        public static void OutputTableToConsole(IEnumerable<object> headers, IEnumerable<Analytics> analytics)
        {
            OutputTableToConsole(headers, analytics.Select(a => a.GetAnalytics()));
        }

        public static void OutputTableToConsole(IEnumerable<object> headers, IEnumerable<IEnumerable<object>> grids)
        {
            var table = new ConsoleTable(headers.Cast<string>().ToArray());

            for (int i = 0; i < grids.Count(); i++)
            {
                table.AddRow(grids.ElementAt(i).ToArray());
            }

            table.Write(Format.Alternative);
        }
    }
}

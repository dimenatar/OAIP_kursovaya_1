using System.Diagnostics;

namespace Sorting_comparison
{
    public static class ResourceListener
    {
        public static Analytics GetAnalytics(Action action, string name)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            action?.Invoke();

            stopwatch.Stop();
            Analytics analytics = new Analytics(stopwatch.ElapsedMilliseconds, name);
            return analytics;
        }
    }
}

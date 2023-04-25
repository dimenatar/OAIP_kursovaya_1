using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting_comparison
{
    public static class ResourceListener
    {
        public static Analytics GetAnalytics(Action action)
        {
            Analytics analytics = new Analytics();
            analytics.SetStartTime(TimeSpan.FromTicks(DateTime.Now.Ticks));
            analytics.SetStartMemory(GC.GetTotalMemory(false));
            action?.Invoke();

            analytics.SetEndTime(TimeSpan.FromTicks(DateTime.Now.Ticks));
            analytics.SetEndMemory(GC.GetTotalMemory(false));
            return analytics;
        }
    }
}

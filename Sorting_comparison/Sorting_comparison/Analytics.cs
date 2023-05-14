namespace Sorting_comparison
{
    public class Analytics
    {
        private string _name = "";
        private long _startTime;
        private long _endTime;
        private long _elapsedTime;

        public ulong Swaps { get; set; }
        public ulong Comparings { get; set; }

        public long ElapsedTime => _elapsedTime;

        public Analytics() { }

        public Analytics(string name)
        {
            _name = name;
        }

        public Analytics(long elapsedTime, string name)
        {
            _elapsedTime = elapsedTime;
            _name = name;
        }

        public void SetStartTime(long startTime)
        {
            _startTime = startTime;
        }

        public void SetEndTime(long endTime)
        {
            _endTime = endTime;
            _elapsedTime = endTime - _startTime;
        }

        public List<string> GetAnalytics()
        {
            return new List<string>()
            {
                _name,
                $"{_elapsedTime} ms",
                Swaps.ToString(),
                Comparings.ToString(),
            };

        }
    }
}

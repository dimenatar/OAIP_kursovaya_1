namespace Sorting_comparison
{
    public class Analytics
    {
        private string _name = "";
        private TimeSpan _startTime;
        private TimeSpan _endTime;
        private TimeSpan _elapsedTime;
        private long _usedMemory;
        private long _startMemory;
        private long _endMemory;

        public TimeSpan ElapsedTime => _elapsedTime;
        public long UsedMemory => _usedMemory;

        public Analytics() { }

        public Analytics(string name)
        {
            _name = name;
        }

        public Analytics(TimeSpan elapsedTime, long usedMemory, string name)
        {
            _elapsedTime = elapsedTime;
            _usedMemory = usedMemory;
            _name = name;
        }

        public void SetStartTime(TimeSpan startTime)
        {
            _startTime = startTime;
        }

        public void SetEndTime(TimeSpan endTime)
        {
            _endTime = endTime;
            _elapsedTime = endTime - _startTime;
        }

        public void SetStartMemory(long startMemory)
        {
            _startMemory = startMemory;
        }

        public void SetEndMemory(long endMemory)
        {
            _endMemory = endMemory;
            _usedMemory = endMemory - _startMemory;
        }

        public List<string> GetAnalytics()
        {
            return new List<string>()
            {
                _name,
                _elapsedTime.Microseconds.ToString(),
                _usedMemory.ToString(),
            };

        }
    }
}

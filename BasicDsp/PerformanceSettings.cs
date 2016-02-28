using System;
// ReSharper disable ClassNeverInstantiated.Global

namespace BasicDsp
{
    public class PerformanceSettings
    {
        public int CoreLimit { get; }
        public bool EarlyTempAllocation { get; }

        public PerformanceSettings(int coreLimit = 100, bool earlyTempAllocation = false)
        {
            if (coreLimit < 1)
                throw new ArgumentException("Core limit must be > 0", nameof(coreLimit));
            CoreLimit = coreLimit;
            EarlyTempAllocation = earlyTempAllocation;
        }
    }
}
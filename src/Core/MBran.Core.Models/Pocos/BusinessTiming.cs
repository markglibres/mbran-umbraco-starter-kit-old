using System;
using System.Collections.Generic;
using MBran.TimeRangePicker;

namespace MBran.Core.Models
{
    public partial class BusinessTiming : IBusinessTiming
    {
        public IEnumerable<DayOfWeek> BusinessTimingDays { get; set; }
        public TimeRange BusinessTimingHours { get; set; }
    }
}

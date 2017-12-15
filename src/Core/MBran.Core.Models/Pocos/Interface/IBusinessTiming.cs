using System;
using MBran.TimeRangePicker;
using System.Collections.Generic;

namespace MBran.Core.Models
{
    public partial interface IBusinessTiming
    {
        IEnumerable<DayOfWeek> BusinessTimingDays { get; set; }
        TimeRange BusinessTimingHours { get; set; }
    }
}

using MBran.TimeRangePicker;
using System;
using System.Collections.Generic;

namespace MBran.Core.Models
{
    public partial class BusinessTiming : BasePoco, IBusinessTiming
    {
        public virtual IEnumerable<DayOfWeek> BusinessTimingDays { get; set; }
        public virtual TimeRange BusinessTimingHours { get; set; }
    }
}

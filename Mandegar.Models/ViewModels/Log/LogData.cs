using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.Log
{
    public class LevelCountVM
    {
        public int InfoCount { get; set; }
        public int WarnCount { get; set; }
        public int ErrorCount { get; set; }
        public int TraceCount { get; set; }
        public int FatalCount { get; set; }
        public int OFFCount { get; set; }
        public int DebugCount { get; set; }
    }

    public class LogDailyVM
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public DateTime Date { get; set; }
        public int InfoCount { get; set; }
        public int WarnCount { get; set; }
        public int ErrorCount { get; set; }
        public int TraceCount { get; set; }
        public int FatalCount { get; set; }
        public int OFFCount { get; set; }
        public int DebugCount { get; set; }
    }

    public class LogWeeklyVM
    {
        public int Year { get; set; }
        public int Week { get; set; }
        public int InfoCount { get; set; }
        public int WarnCount { get; set; }
        public int ErrorCount { get; set; }
        public int TraceCount { get; set; }
        public int FatalCount { get; set; }
        public int OFFCount { get; set; }
        public int DebugCount { get; set; }
    }

    public class LogMonthlyVM
    {
        public DateTime Month { get; set; }
        public string Title { get; set; }
        public int InfoCount { get; set; }
        public int WarnCount { get; set; }
        public int ErrorCount { get; set; }
        public int TraceCount { get; set; }
        public int FatalCount { get; set; }
        public int OFFCount { get; set; }
        public int DebugCount { get; set; }
    }

    public class LogYearlyVM
    {
        public int Year { get; set; }
        public int Count { get; set; }
    }

    public class LogYearlyWithLevelVM
    {
        public int Year { get; set; }
        public int InfoCount { get; set; }
        public int WarnCount { get; set; }
        public int ErrorCount { get; set; }
        public int TraceCount { get; set; }
        public int FatalCount { get; set; }
        public int OFFCount { get; set; }
        public int DebugCount { get; set; }
    }
}

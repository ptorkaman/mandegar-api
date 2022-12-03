using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.Log
{
    public class LogStatiscsVM
    {
        public List<LogMonthlyVM> Monthly { get; set; }
        public List<LogYearlyVM> Yearly { get; set; }
        public List<LogYearlyWithLevelVM> LogYearlyWithLevel { get; set; }
        public List<LogWeeklyVM> Weekly { get; set; }
        public List<LogDailyVM> Daily { get; set; }
        public List<LevelCountVM> Statistics { get; set; }
    }
}

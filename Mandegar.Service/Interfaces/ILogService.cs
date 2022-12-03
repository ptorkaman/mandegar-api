using Mandegar.Models.ViewModels.Log;
using Mandegar.Models.HelperModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface ILogService
    {
        Task<Result<LogStatiscsVM>> GetAllStatisticsAsync(string date, DateTime from, DateTime to);
        Task<Result<List<LogDailyVM>>> GetDaily(DateTime from, DateTime to);
        Task<Result<List<LogWeeklyVM>>> GetWeekly(string date);
        Task<Result<List<LogMonthlyVM>>> GetMonthly(string date);
        Task<Result<List<LogYearlyVM>>> GetYearly(DateTime from, DateTime to);
        Task<Result<List<LogYearlyWithLevelVM>>> GetYearlyWithLevel(DateTime from, DateTime to);
    }
}

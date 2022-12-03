using Mandegar.DataAccess;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Log;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class LogService: ILogService
    {
        private readonly MandegarLogDbContext _context;
        private IConfiguration _iConfig;
        public LogService(MandegarLogDbContext MandegarLogDbContext, IConfiguration iConfig)
        {
            _context = MandegarLogDbContext;
            _iConfig = iConfig;
        }

        public async Task<Result<LogStatiscsVM>> GetAllStatisticsAsync(string date, DateTime from, DateTime to)
        {
            
            var param = new
            {
                CurrentDate = date
            };

            var dailyParam = new
            {
                From = from,
                To = to
            };
            LogStatiscsVM statistics = new LogStatiscsVM();
            statistics.Monthly = await ExecuteReader<LogMonthlyVM>(null, "MonthlyData", param);
            statistics.Yearly = await ExecuteReader<LogYearlyVM>(null, "YearlyData", dailyParam);
            statistics.LogYearlyWithLevel = await ExecuteReader<LogYearlyWithLevelVM>(null, "YearlyWithLevelData", dailyParam);
            statistics.Weekly = await ExecuteReader<LogWeeklyVM>(null, "WeeklyData", param);
            statistics.Daily = await ExecuteReader<LogDailyVM>(null, "DailyData", dailyParam);
            statistics.Statistics = await ExecuteReader<LevelCountVM>(null, "AllLevelCountData", null);
            
            return new Result<LogStatiscsVM>
            {
                Data = statistics
            };
        }

        public async Task<Result<List<LogYearlyWithLevelVM>>> GetYearlyWithLevel(DateTime from, DateTime to)
        {
            var param = new
            {
                From = from,
                To = to
            };

            List<LogYearlyWithLevelVM> result = await ExecuteReader<LogYearlyWithLevelVM>(null, "YearlyWithLevelData", param);
            return new Result<List<LogYearlyWithLevelVM>>
            {
                Data = result
            };
        }

        public async Task<Result<List<LogYearlyVM>>> GetYearly(DateTime from, DateTime to)
        {
            var param = new
            {
                From = from,
                To = to
            };

            List<LogYearlyVM> result = await ExecuteReader<LogYearlyVM>(null, "YearlyData", param);
            return new Result<List<LogYearlyVM>>
            {
                Data = result
            };
        }

        public async Task<Result<List<LogMonthlyVM>>> GetMonthly(string date)
        {
            var param = new
            {
                CurrentDate = date
            };

            List<LogMonthlyVM> result = await ExecuteReader<LogMonthlyVM>(null, "MonthlyData", param);
            return new Result<List<LogMonthlyVM>>
            {
                Data = result
            };
        }

        public async Task<Result<List<LogWeeklyVM>>> GetWeekly(string date)
        {
            var param = new
            {
                CurrentDate = date
            };

            List<LogWeeklyVM> result = await ExecuteReader<LogWeeklyVM>(null, "WeeklyData", param);
            return new Result<List<LogWeeklyVM>>
            {
                Data = result
            };
        }

        public async Task<Result<List<LogDailyVM>>> GetDaily(DateTime from, DateTime to)
        {
            var param = new
            {
                From = from,
                To = to
            };

            List<LogDailyVM> result = await ExecuteReader<LogDailyVM>(null, "DailyData", param);
            return new Result<List<LogDailyVM>>
            {
                Data = result
            };
        }

        private async Task<List<string>> GetSpParameters(string schemaName, string spName)
        {
            var result = new List<string>();

            if (string.IsNullOrWhiteSpace(schemaName))
            {
                var configSchemaName = _iConfig.GetSection("DbSchemaName").Value;
                if (string.IsNullOrWhiteSpace(configSchemaName))
                    schemaName = "dbo";

                else
                    schemaName = configSchemaName;
            }

            try
            {
                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = $"{schemaName}.GetSpParametersName";
                    command.CommandType = CommandType.StoredProcedure;


                    var param = new SqlParameter("SpName", spName);
                    command.Parameters.Add(param);


                    _context.Database.OpenConnection();

                    var dataReader = command.ExecuteReader();

                    while (await dataReader.ReadAsync())
                    {
                        result.Add(dataReader.GetString("PARAMETER_NAME"));
                    }

                    _context.Database.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(Messages.OperationFailed, ex);
            }


            result = result?.ConvertAll(d => d.ToLower());
            return result;
        }

        private static T ChangeType<T>(object value)
        {
            var t = typeof(T);

            if (t.IsGenericType && t.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                if (value == null)
                {
                    return default(T);
                }

                t = Nullable.GetUnderlyingType(t);
            }

            return (T)Convert.ChangeType(value, t);
        }

        public async Task<List<TSpResultModel>> ExecuteReader<TSpResultModel>(string schemaName, string storeProcedureName, object spParamsModel)
        {
            Type resultModelType = typeof(TSpResultModel);
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(resultModelType);
            var lst = (IList)Activator.CreateInstance(constructedListType);
            if (string.IsNullOrWhiteSpace(schemaName))
            {
                var configSchemaName = _iConfig.GetSection("DbSchemaName").Value;
                if (string.IsNullOrWhiteSpace(configSchemaName))
                    schemaName = "dbo";

                else
                    schemaName = configSchemaName;
            }

            try
            {
                var spInputParameters = await GetSpParameters(schemaName, storeProcedureName);

                using (var command = _context.Database.GetDbConnection().CreateCommand())
                {
                    command.CommandText = $"{schemaName}.{storeProcedureName}";
                    command.CommandType = CommandType.StoredProcedure;

                    if (spParamsModel != null)
                    {
                        foreach (var item in spParamsModel.GetType().GetProperties())
                        {
                            if (spInputParameters.Contains(item.Name.ToLower()))
                            {
                                var param = new SqlParameter(item.Name, spParamsModel.GetType().GetProperty(item.Name).GetValue(spParamsModel, null));
                                command.Parameters.Add(param);
                            }
                        }
                    }

                    _context.Database.OpenConnection();

                    var dataReader = command.ExecuteReader();

                    while (await dataReader.ReadAsync())
                    {
                        var fieldNames = Enumerable.Range(0, dataReader.FieldCount).Select(i => dataReader.GetName(i)).ToArray();

                        var model = Activator.CreateInstance(resultModelType);

                        foreach (var item in resultModelType.GetProperties())
                        {
                            if (fieldNames.Contains(item.Name))
                            {
                                if (!dataReader.IsDBNull(dataReader.GetOrdinal(item.Name)))
                                {
                                    PropertyInfo propertyInfo = resultModelType.GetProperty(item.Name);
                                    Type propertyType = propertyInfo.PropertyType;

                                    if (propertyType == typeof(string))
                                        propertyInfo.SetValue(model, ChangeType<string>(dataReader.GetString(dataReader.GetOrdinal(item.Name))));

                                    else if (propertyType == typeof(bool) || propertyType == typeof(Nullable<bool>))
                                        propertyInfo.SetValue(model, ChangeType<bool>(dataReader.GetBoolean(dataReader.GetOrdinal(item.Name))));

                                    else if (propertyType == typeof(byte) || propertyType == typeof(Nullable<byte>))
                                        propertyInfo.SetValue(model, ChangeType<byte>(dataReader.GetByte(dataReader.GetOrdinal(item.Name))));

                                    else if (propertyType == typeof(char) || propertyType == typeof(Nullable<char>))
                                        propertyInfo.SetValue(model, ChangeType<char>(dataReader.GetChar(dataReader.GetOrdinal(item.Name))));

                                    else if (propertyType == typeof(DateTime) || propertyType == typeof(Nullable<DateTime>))
                                        propertyInfo.SetValue(model, ChangeType<DateTime>(dataReader.GetDateTime(dataReader.GetOrdinal(item.Name))));

                                    else if (propertyType == typeof(decimal) || propertyType == typeof(Nullable<decimal>))
                                        propertyInfo.SetValue(model, ChangeType<decimal>(dataReader.GetDecimal(dataReader.GetOrdinal(item.Name))));

                                    else if (propertyType == typeof(double) || propertyType == typeof(Nullable<double>))
                                        propertyInfo.SetValue(model, ChangeType<double>(dataReader.GetDouble(dataReader.GetOrdinal(item.Name))));

                                    else if (propertyType == typeof(float) || propertyType == typeof(Nullable<float>))
                                        propertyInfo.SetValue(model, ChangeType<float>(dataReader.GetFloat(dataReader.GetOrdinal(item.Name))));

                                    else if (propertyType == typeof(Guid) || propertyType == typeof(Nullable<Guid>))
                                        propertyInfo.SetValue(model, ChangeType<Guid>(dataReader.GetGuid(dataReader.GetOrdinal(item.Name))));

                                    else if (propertyType == typeof(Int16) || propertyType == typeof(Nullable<Int16>))
                                        propertyInfo.SetValue(model, ChangeType<Int16>(dataReader.GetInt16(dataReader.GetOrdinal(item.Name))));

                                    else if (propertyType == typeof(Int32) || propertyType == typeof(Nullable<Int32>))
                                        propertyInfo.SetValue(model, ChangeType<Int32>(dataReader.GetInt32(dataReader.GetOrdinal(item.Name))));

                                    else if (propertyType == typeof(Int64) || propertyType == typeof(Nullable<Int64>))
                                        propertyInfo.SetValue(model, ChangeType<Int64>(dataReader.GetInt64(dataReader.GetOrdinal(item.Name))));

                                }
                            }

                        }

                        lst.Add(model);
                    }

                    _context.Database.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(Messages.OperationFailed, ex);
            }

            return lst as List<TSpResultModel>;

        }
    }
}

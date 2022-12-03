using Mandegar.DataAccess;
using Mandegar.Models.HelperModels;
using Mandegar.Repository.GenericRepositories;
using Mandegar.Resources.AdminMessage;
using Mandegar.Utilities.BusinessHelpers;
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

namespace Mandegar.Repository.UnitOfWork
{
    public class Uow : IUow
    {
        private MandegarDbContext _context;
        private IConfiguration _iConfig;
        private readonly Dictionary<Type, object> _repositories;

        public Uow(MandegarDbContext coreDbContext, IConfiguration iConfig)
        {
            _context = coreDbContext;
            _iConfig = iConfig;
            _repositories = new Dictionary<Type, object>();
        }

        public IRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IRepository<TEntity>;
            }

            var repository = new GenericRepository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);

            return repository;
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

        public async Task<int> ExecuteNonQuery(string schemaName, string storeProcedureName, object spParamsModel)
        {
            var res = 0;
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

                    res = await command.ExecuteNonQueryAsync();

                    _context.Database.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(Messages.OperationFailed, ex);
            }

            return res;

        }

        public async Task<object> ExecuteScalar(string schemaName, string storeProcedureName, object spParamsModel)
        {
            object res = new object();
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

                    res = await command.ExecuteScalarAsync();

                    _context.Database.CloseConnection();
                }

            }
            catch (Exception ex)
            {
                throw new Exception(Messages.OperationFailed, ex);
            }

            return res;

        }

        public async Task<Result<T>> BulkInsert<T>(IList<T> data, string tableSchema, string tableName, int? batchSize, string[] columnMapping)
        {
            var connection = new SqlConnection(_context.Database.GetDbConnection().ConnectionString);

            try
            {
                if (string.IsNullOrWhiteSpace(tableSchema))
                {
                    var configSchemaName = _iConfig.GetSection("DbSchemaName").Value;
                    if (string.IsNullOrWhiteSpace(configSchemaName))
                        tableSchema = "dbo";

                    else
                        tableSchema = configSchemaName;
                }

                var bSize = 0;
                if (batchSize == null)
                    bSize = data.Count();

                else
                    bSize = batchSize.Value;

                var dt = data.ToDataTable();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection, SqlBulkCopyOptions.UseInternalTransaction, null))
                {
                    bulkCopy.DestinationTableName = $"{tableSchema}.{tableName}";
                    bulkCopy.BatchSize = bSize;
                    bulkCopy.BulkCopyTimeout = int.MaxValue;

                    if (columnMapping != null && columnMapping.Count() > 0)
                    {
                        foreach (var mapping in columnMapping)
                        {
                            var split = mapping.Split(new[] { ',' });
                            bulkCopy.ColumnMappings.Add(split.First(), split.Last());
                        }
                    }
                    else
                    {
                        var mappings = new List<string>();
                        foreach (var item in data)
                        {
                            foreach (var prop in item.GetType().GetProperties())
                            {
                                var val = item.GetType().GetProperty(prop.Name).GetValue(item, null);
                                if (val != null)
                                {
                                    if (!mappings.Any(c => mappings.Contains(prop.Name)))
                                    {
                                        mappings.Add(prop.Name);
                                    }
                                }
                            }
                        }

                        foreach (var mapping in mappings)
                        {
                            var split = mapping.Split(new[] { ',' });
                            bulkCopy.ColumnMappings.Add(split.First(), split.Last());
                        }
                    }

                    await connection.OpenAsync();
                    await bulkCopy.WriteToServerAsync(dt);
                    await connection.CloseAsync();

                    return new Result<T>(true);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(Messages.OperationFailed, ex);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    await connection.CloseAsync();

            }
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

        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IDatabaseTransaction BeginTransaction()
        {
            return new EntityDatabaseTransaction(_context);
        }
    }
}

using Mandegar.Models.HelperModels;
using Mandegar.Repository.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Repository.UnitOfWork
{
    public interface IUow : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        Task<List<TSpResultModel>> ExecuteReader<TSpResultModel>(string schemaName, string storeProcedureName, object spParamsModel);
        Task<int> ExecuteNonQuery(string schemaName, string storeProcedureName, object spParamsModel);
        Task<object> ExecuteScalar(string schemaName, string storeProcedureName, object spParamsModel);
        Task<Result<T>> BulkInsert<T>(IList<T> data, string tableSchema, string tableName, int? batchSize, string[] columnMapping);
        IDatabaseTransaction BeginTransaction();
        void SaveChanges();
        Task SaveChangesAsync();
    }
}

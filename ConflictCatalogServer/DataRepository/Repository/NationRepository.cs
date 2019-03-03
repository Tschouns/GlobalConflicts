using System;
using System.Collections.Generic;
using System.Linq;
using Base.Result;
using Base.RuntimeChecks;
using Dapper;
using DataRepository.DbConnection;
using DataRepository.Model;

namespace DataRepository.Repository
{
    public class NationRepository : INationRepository
    {
        private readonly IDbConnectionProvider dbConnectionProvider;

        public NationRepository(IDbConnectionProvider dbConnectionProvider)
        {
            Argument.AssertIsNotNull(dbConnectionProvider, nameof(dbConnectionProvider));

            this.dbConnectionProvider = dbConnectionProvider;
        }

        public IReadOnlyCollection<NationModel> ReadAll()
        {
            var models = this.dbConnectionProvider
                .GetConnection()
                .Query<NationModel>(SqlCommands.NationSelectAll)
                .AsList();

            return models;
        }

        public OptionalResult<NationModel> ReadbyAlternateKey(string key)
        {
            Argument.AssertStringIsNotEmpty(key, nameof(key));

            var model = this.dbConnectionProvider
                .GetConnection()
                .Query<NationModel>(SqlCommands.NationSelectByUniqueName, new { UniqueName = key })
                .FirstOrDefault();

            return new OptionalResult<NationModel>(model);
        }

        public void Insert(NationModel model)
        {
            Argument.AssertIsNotNull(model, nameof(model));
            model.AssertIsNotPersisted();

            var connection = this.dbConnectionProvider.GetConnection();
            var affectedRows = connection.Execute(SqlCommands.NationInsert, model);

            if (affectedRows != 1)
            {
                throw new InvalidOperationException("The row could not be inserted!");
            }
        }

        public void Delete(NationModel model)
        {
            Argument.AssertIsNotNull(model, nameof(model));
            model.AssertHasId();

            var connection = this.dbConnectionProvider.GetConnection();
            var affectedRows = connection.Execute(SqlCommands.NationDeleteById, model);

            if (affectedRows != 1)
            {
                throw new InvalidOperationException("The row could not be deleted!");
            }
        }
    }
}

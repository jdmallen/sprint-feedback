using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using JDMallen.Toolbox.Interfaces;
using JDMallen.Toolbox.RepositoryPattern.Interfaces;
using SprintFeedback.Data.Models;
using SprintFeedback.Data.Parameters;
using SprintFeedback.Data.Repositories;
using SprintFeedback.Data.Context.Dapper.Queries;
using JDMallen.Toolbox.Extensions;
using System.Data;

namespace SprintFeedback.Data.Context.Dapper.Repositories
{
	public class FeedbackRepository
		: IFeedbackRepository
	{
		private readonly IDbTransaction _transaction;

		public FeedbackRepository(IDbTransaction transaction)
		{
			_transaction = transaction;
		}

		public Task<Feedback> Add(Feedback model)
		{
			throw new NotImplementedException();
		}

		public Task<bool> Any(FeedbackParameters parameters)
		{
			throw new NotImplementedException();
		}

		public async Task<long> Count(FeedbackParameters parameters)
		{
			var builder = new SqlBuilder();
			var countSql = builder.AddTemplate(Query.GenericSelectTemplate);
			builder.Select("count(*)");

			if (!parameters.Id.IsNullOrWhiteSpace())
			{
				builder.Where("Id = @Id", new { Id = parameters.Id });
			}

			var count = await _transaction
				.Connection
				.QuerySingleAsync<int>(
					countSql.RawSql,
					countSql.Parameters,
					_transaction);

			return count;
		}

		public Task<List<Feedback>> Find(FeedbackParameters parameters)
		{
			throw new NotImplementedException();
		}

		public Task<IPagedResult<Feedback>> FindPaged(FeedbackParameters parameters)
		{
			throw new NotImplementedException();
		}

		public Task<Feedback> Get(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<Feedback> Remove(Feedback id)
		{
			throw new NotImplementedException();
		}

		public Task<Feedback> Remove(Guid id)
		{
			throw new NotImplementedException();
		}

		public Task<Feedback> Update(Feedback model)
		{
			throw new NotImplementedException();
		}
	}
}

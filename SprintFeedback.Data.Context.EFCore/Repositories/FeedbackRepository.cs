using System;
using System.Linq;
using JDMallen.Toolbox.Extensions;
using JDMallen.Toolbox.Infrastructure.EFCore.Implementations;
using SprintFeedback.Data.Context.EFCore.Config;
using SprintFeedback.Data.Models;
using SprintFeedback.Data.Parameters;
using SprintFeedback.Data.Repositories;

namespace SprintFeedback.Data.Context.EFCore.Repositories
{
	public class FeedbackRepository
		: EFRepositoryBase<SfContext,Feedback,FeedbackParameters,Guid>, 
		  IFeedbackRepository
	{
		public FeedbackRepository(SfContext context) : base(context)
		{
		}

		protected override IQueryable<Feedback> BuildQuery(FeedbackParameters parameters)
		{
			var query = BuildQueryInit(parameters);

			if (parameters == null)
			{
				return query;
			}

			if (parameters.IsPositive)
			{
				query = query.Where(f => f.IsPositive);
			}

			if (!parameters.Comment.IsNullOrWhiteSpace())
			{
				query = query.Where(
					f => f.Comment.ToLowerInvariant()
						.Contains(parameters.Comment.ToLowerInvariant()));
			}

			if (!parameters.DisplayName.IsNullOrWhiteSpace())
			{
				query = query.Where(
					f => f.DisplayName.ToLowerInvariant()
						.Contains(parameters.DisplayName.ToLowerInvariant()));
			}

			if (!parameters.UserName.IsNullOrWhiteSpace())
			{
				query = query.Where(
					f => f.UserName.ToLowerInvariant()
						.Contains(parameters.UserName.ToLowerInvariant()));
			}

			return BuildQueryFinal(parameters, query);
		}
	}
}

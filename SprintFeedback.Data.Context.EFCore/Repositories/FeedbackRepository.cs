using System;
using System.Linq;
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
			throw new NotImplementedException();
		}
	}
}

using JDMallen.Toolbox.Infrastructure.EFCore.Implementations;
using SprintFeedback.Data.Context.EFCore.Config;
using SprintFeedback.Data.Repositories;

namespace SprintFeedback.Data.Context.EFCore.Repositories
{
	public class UnitOfWork : EFUnitOfWorkBase<SfContext>
	{
		public IFeedbackRepository FeedbackRepository { get; private set; }

		public UnitOfWork(
			SfContext connectionFactory, 
			IFeedbackRepository feedbackRepository)
			: base(connectionFactory)
		{
			FeedbackRepository = feedbackRepository;
		}

		public override void NullRepositories()
		{
			FeedbackRepository = null;
		}
	}
}

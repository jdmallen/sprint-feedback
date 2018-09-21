using JDMallen.Toolbox.Interfaces;
using JDMallen.Toolbox.RepositoryPattern.Implementations;

namespace SprintFeedback.Data.Repositories
{
	public class UnitOfWork : UnitOfWorkBase<IContext>
	{
		public IFeedbackRepository FeedbackRepository { get; }

		public UnitOfWork(
			IContext connectionFactory, 
			IFeedbackRepository feedbackRepository)
			: base(connectionFactory)
		{
			FeedbackRepository = feedbackRepository;
		}

		protected override void ResetRepositories()
		{
			FeedbackRepository.SetTransaction(Transaction);
		}
	}
}

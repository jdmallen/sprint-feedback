using SprintFeedback.Data.Context.EFCore.Config;

namespace SprintFeedback.Data.Context.EFCore.Repositories
{
	public class UnitOfWorkFactory : IUnitOfWorkFactory
	{
		private readonly SfContext _context;

		public UnitOfWorkFactory(SfContext context)
		{
			_context = context;
		}

		public UnitOfWork GetUnitOfWork()
		{
			var feedbackRepo = new FeedbackRepository(_context);
			return new UnitOfWork(_context,feedbackRepo);
		}
	}
}

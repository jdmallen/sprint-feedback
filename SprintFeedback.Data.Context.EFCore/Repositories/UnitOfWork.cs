using JDMallen.Toolbox.Infrastructure.EFCore.Implementations;
using JDMallen.Toolbox.RepositoryPattern.Implementations;
using SprintFeedback.Data.Context.EFCore.Config;

namespace SprintFeedback.Data.Context.EFCore.Repositories
{
	public class UnitOfWork : EFUnitOfWorkBase<SfContext>
	{
		public UnitOfWork(SfContext connectionFactory)
			: base(connectionFactory)
		{
		}

		public override void NullRepositories()
		{
			throw new System.NotImplementedException();
		}
	}
}

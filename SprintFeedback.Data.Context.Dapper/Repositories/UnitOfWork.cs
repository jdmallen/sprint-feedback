
using JDMallen.Toolbox.RepositoryPattern.Implementations;
using SprintFeedback.Data.Config;

namespace SprintFeedback.Data.Context.Dapper.Repositories
{
	public class UnitOfWork : UnitOfWorkBase<SfContext>
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
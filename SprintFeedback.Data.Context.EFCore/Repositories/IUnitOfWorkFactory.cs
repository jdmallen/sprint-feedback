namespace SprintFeedback.Data.Context.EFCore.Repositories
{
	public interface IUnitOfWorkFactory
	{
		UnitOfWork GetUnitOfWork();
	}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SprintFeedback.DataAccess.Config;

namespace SprintFeedback.DataAccess
{
	public static class DataAccessServiceExtensions
	{
		public static IServiceCollection AddDataAccessServices(
			this IServiceCollection services,
			string connectionString)
		{
			services.AddDbContext<SfContext>(
				opts =>
				{
					opts.UseSqlite(connectionString);
				});
			return services;
		}
	}
}

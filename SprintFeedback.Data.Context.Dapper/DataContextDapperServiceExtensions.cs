using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using SprintFeedback.Data.Config;
using SprintFeedback.Data.Context.Dapper.Config;

namespace SprintFeedback.Data.Context.Dapper
{
	public static class DataContextDapperServiceExtensions
	{
		public static IServiceCollection AddDataContextDapperServices(
			this IServiceCollection services,
			Settings settings)
		{
			services.AddTransient<SfContext>();
			return services;
		}
	}
}

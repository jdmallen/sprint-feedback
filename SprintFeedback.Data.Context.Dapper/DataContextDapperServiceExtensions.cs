using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using SprintFeedback.Data.Config;

namespace SprintFeedback.Data.Context.Dapper
{
	public static class DataContextDapperServiceExtensions
	{
		public static IServiceCollection AddDataContextDapperServices(
			this IServiceCollection services,
			Settings settings)
		{
			
			return services;
		}
	}
}

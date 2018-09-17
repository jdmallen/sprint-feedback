using Microsoft.Extensions.DependencyInjection;
using SprintFeedback.Data.Config;

namespace SprintFeedback.Data
{
	public static class DataServiceExtensions
	{
		public static IServiceCollection AddDataServices(
			this IServiceCollection services)
		{
			return services;
		}
	}
}

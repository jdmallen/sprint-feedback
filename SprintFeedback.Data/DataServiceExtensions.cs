using Microsoft.Extensions.DependencyInjection;

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

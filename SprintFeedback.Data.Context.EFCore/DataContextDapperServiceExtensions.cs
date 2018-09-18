using Microsoft.Extensions.DependencyInjection;
using SprintFeedback.Data.Config;
using SprintFeedback.Data.Context.EFCore.Config;

namespace SprintFeedback.Data.Context.EFCore
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

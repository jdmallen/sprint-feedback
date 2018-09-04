using System;
using Microsoft.Extensions.DependencyInjection;

namespace SprintFeedback.DataAccess
{
		public static class DataAccessServiceExtensions
		{
				public static ServiceCollection AddDataAccessServices(this ServiceCollection services)
				{
					return services;
				}
		}
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using SprintFeedback.Data.Config;

namespace SprintFeedback.Data
{
	public static class DataServiceExtensions
	{
		public static IServiceCollection AddDataServices(
			this IServiceCollection services,
			Settings settings)
		{
			var connectionString = new MySqlConnectionStringBuilder
			{
				Server = settings.DbConnectionServer,
				Database = settings.DbName,
				UserID = settings.DbConnectionLogin,
				Password = settings.DbConnectionPassword,
				OldGuids = true
			};

			services.AddDbContext<SfContext>(
				opts => opts.UseMySql(
					connectionString.ToString(),
					mySqlOptions =>
					{
						mySqlOptions.UnicodeCharSet(CharSet.Utf8mb4);
						mySqlOptions.EnableRetryOnFailure(5);
					}));
			return services;
		}
	}
}

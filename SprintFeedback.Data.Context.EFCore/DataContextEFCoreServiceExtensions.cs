using System;
using JDMallen.Toolbox.Interfaces;
using JDMallen.Toolbox.RepositoryPattern.Interfaces;
// using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySql.Data.MySqlClient;
using SprintFeedback.Data.Config;
using SprintFeedback.Data.Context.EFCore.Config;
using SprintFeedback.Data.Context.EFCore.Repositories;
using SprintFeedback.Data.Repositories;

namespace SprintFeedback.Data.Context.EFCore
{
	/// <summary>
	/// Switch the commented sections to use MSSQL instead of MySQL/MariaDB
	/// </summary>
	public static class DataContextEFCoreServiceExtensions
	{
		public static IServiceCollection AddDataContextEFCoreServices(
			this IServiceCollection services,
			Settings settings)
		{
			// var sqlServerConnectionString = new SqlConnectionStringBuilder
			// {
			// 	Password = settings.DbConnectionPassword,
			// 	UserID = settings.DbConnectionLogin,
			// 	DataSource = settings.DbConnectionServer,
			// 	InitialCatalog = settings.DbName
			// };

			var mariaDbConnectionString = new MySqlConnectionStringBuilder
			{
				Password = settings.DbConnectionPassword,
				UserID = settings.DbConnectionLogin,
				Server = settings.DbConnectionServer,
				Database = settings.DbName
			};

			services.AddDbContextPool<SfContext>(
				options =>
				{
					// options.UseSqlServer(sqlServerConnectionString.ToString());
					options.UseMySql(mariaDbConnectionString.ToString());
					var env =
						Environment.GetEnvironmentVariable(
							"ASPNETCORE_ENVIRONMENT");
					if ("Development".Equals(
						env,
						StringComparison.InvariantCultureIgnoreCase))
					{
						options.EnableSensitiveDataLogging();
					}
				});

			services.AddTransient<IContext, SfContext>();
			services.AddTransient<IFeedbackRepository, FeedbackRepository>();
			services.AddTransient<IUnitOfWork, UnitOfWork>();

			return services;
		}
	}
}

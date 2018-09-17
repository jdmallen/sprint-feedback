using System.Data;
using System.Threading;
using System.Threading.Tasks;
using JDMallen.Toolbox.Interfaces;
using MySql.Data.MySqlClient;
using SprintFeedback.Data.Config;

namespace SprintFeedback.Data.Context.Dapper.Config
{
	public class SfContext : IContext
	{
		private readonly Settings _settings;

		public SfContext(Settings settings)
		{
			_settings = settings;
		}

		public IDbConnection GetConnection()
		{
			var connectionString = new MySqlConnectionStringBuilder
			{
				Server = _settings.DbConnectionServer,
				Database = _settings.DbName,
				UserID = _settings.DbConnectionLogin,
				Password = _settings.DbConnectionPassword,
				OldGuids = true
			};
			return new MySqlConnection(connectionString.ToString());
		}

		public Task<int> SaveAllChanges(
			CancellationToken cancellationToken = default(CancellationToken))
		{
			throw new System.NotImplementedException();
		}
	}
}

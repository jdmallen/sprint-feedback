using System.IO;
using System.Linq;
using System.Reflection;

namespace SprintFeedback.Data.Context.EFCore.Queries
{
	public static class Query
	{
		static Query()
		{
			LoadQueries();
		}

		public static string GenericSelectTemplate {get; private set;}
		public static string GetAllFeedback { get; private set; }
		public static string GetFeedbackById { get; private set; }
		public static string GetTableSize { get; private set; }

		private static bool LoadQuery(PropertyInfo prop)
		{
			var filename = 
				$"{typeof(Query).Namespace}.{prop.Name}.sql";
			
			using(
				var stream = 
					Assembly.GetExecutingAssembly().GetManifestResourceStream(filename))
			{
				using(var streamReader = new StreamReader(stream))
				{
					prop.SetValue(null, streamReader.ReadToEnd());
				}
			}
			
			return true; // just using bool to hack Select LINQ
		}

		private static void LoadQueries()
		{
			typeof(Query)
				.GetProperties(
					BindingFlags.DeclaredOnly
						| BindingFlags.Public
						| BindingFlags.Instance
						| BindingFlags.Static)
				.Select(LoadQuery);
		}
	}
}

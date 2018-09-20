using System;
using System.Linq;
using JDMallen.Toolbox.Infrastructure.EFCore.Config;
using Microsoft.EntityFrameworkCore;
using SprintFeedback.Data.Models;
using SprintFeedback.Data.Utilities;

namespace SprintFeedback.Data.Context.EFCore.Config
{
	public class SfContext : EFContextBase
	{
		public SfContext(DbContextOptions options)
			: base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Model.AddEntityType(typeof(Feedback));
			modelBuilder.Entity<Feedback>(
				builder =>
				{
					builder.HasKey(f => f.Id);
					var env =
						Environment.GetEnvironmentVariable(
							"ASPNETCORE_ENVIRONMENT");
					if ("Development".Equals(
						env,
						StringComparison.InvariantCultureIgnoreCase))
					{
						builder.HasData(
							SeedData.GenerateSampleFeedback().ToArray());
					}

					builder.Ignore(f => f.ShortId);
				});
		}
	}
}

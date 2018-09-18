using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;
using JDMallen.Toolbox.Infrastructure.EFCore.Config;
using JDMallen.Toolbox.Interfaces;
using Microsoft.EntityFrameworkCore;
using SprintFeedback.Data.Config;

namespace SprintFeedback.Data.Context.EFCore.Config
{
	public class SfContext : EFContextBase, IContext
	{
		private readonly Settings _settings;

		public SfContext(DbContextOptions options, Settings settings)
			: base(options)
		{
			_settings = settings;
		}
	}
}

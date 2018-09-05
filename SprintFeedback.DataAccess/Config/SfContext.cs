﻿using JDMallen.Toolbox.Infrastructure.EFCore.Config;
using Microsoft.EntityFrameworkCore;

namespace SprintFeedback.DataAccess.Config
{
	public class SfContext : EFContextBase
	{
		public SfContext(DbContextOptions options) : base(options)
		{
		}
	}
}

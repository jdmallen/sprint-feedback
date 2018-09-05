using System;
using JDMallen.Toolbox.Infrastructure.EFCore.Models;

namespace SprintFeedback.DataAccess.Models
{
	public class Feedback : SqliteEntityModel<Guid>
	{
		public Guid ObjectSid { get; set; }

		public string UserName { get; set; }

		public string DisplayName { get; set; }

		public bool IsPositive { get; set; }

		public string Comment { get; set; }
	}
}

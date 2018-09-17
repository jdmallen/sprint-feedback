using System;
using JDMallen.Toolbox.Infrastructure.EFCore.Models;

namespace SprintFeedback.Data.Models
{
	public class Feedback : MySqlEntityModel<Guid>
	{
		public Guid ObjectSid { get; set; }

		public string UserName { get; set; }

		public string DisplayName { get; set; }

		public bool IsPositive { get; set; }

		public string Comment { get; set; }
	}
}

using System;
using System.Collections.Generic;
using GenFu;
using JDMallen.Toolbox.Implementations;

namespace SprintFeedback.Data.Models
{
	public class Feedback : EntityModel<Guid>
	{
		public string Comment { get; set; }

		public string DisplayName { get; set; }

		public bool IsPositive { get; set; }

		public Guid ObjectSid { get; set; }

		public string UserName { get; set; }
	}
}

using JDMallen.Toolbox.Models;

namespace SprintFeedback.Data.Parameters
{
	public class FeedbackParameters : QueryParameters
	{
		public string Comment { get; set; }

		public string DisplayName { get; set; }

		public bool IsPositive { get; set; }

		public string UserName { get; set; }
	}
}

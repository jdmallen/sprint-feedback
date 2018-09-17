using System;
using JDMallen.Toolbox.RepositoryPattern.Interfaces;
using SprintFeedback.Data.Models;
using SprintFeedback.Data.Parameters;

namespace SprintFeedback.Data.Repositories
{
	public interface IFeedbackRepository
		: IReader<Feedback, FeedbackParameters, Guid>,
			IWriter<Feedback, Guid>
	{

	}
}

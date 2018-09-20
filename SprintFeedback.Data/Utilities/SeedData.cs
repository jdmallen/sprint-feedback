using System.Collections.Generic;
using GenFu;
using SprintFeedback.Data.Models;

namespace SprintFeedback.Data.Utilities
{
	public class SeedData
	{
		public static IEnumerable<Feedback> GenerateSampleFeedback()
		{
			A.Configure<Feedback>()
				.Fill(x => x.Comment)
				.AsLoremIpsumSentences();
			return A.ListOf<Feedback>(40);
		}
	}
}

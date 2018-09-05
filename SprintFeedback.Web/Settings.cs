namespace SprintFeedback.Web
{
	public class Settings
	{
		public string DbFilePath { get; set; }

		public string JwtAudience { get; set; }

		public int JwtExpireMinutes { get; set; }

		public string JwtIssuer { get; set; }

		public string JwtSecretKey { get; set; }
	}
}

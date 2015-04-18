namespace MuonKit.W3cValidationClient.Css
{
	/// <summary>
	/// Represents Error or Warning data
	/// </summary>
	public class ValidationMessage
	{
		public long? Line { get; private set; }
        public string Level { get; private set; }
		public string Message { get; private set; }

		public ValidationMessage(long? line, string level, string message)
		{
			this.Line = line;
			this.Level = level;
			this.Message = message;
		}
	}
}
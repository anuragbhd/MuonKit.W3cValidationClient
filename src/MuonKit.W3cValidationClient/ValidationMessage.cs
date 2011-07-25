namespace MuonKit.W3cValidationClient
{
	/// <summary>
	/// Represents Error or Warning data
	/// </summary>
	public class ValidationMessage
	{
		public long? Line { get; private set; }
		public long? Column { get; private set; }
		public string Message { get; private set; }
		public string MessageId { get; private set; }
		public string Explanation { get; private set; }
		public string Source { get; private set; }

		public ValidationMessage(long? line, long? column, string message, string messageId, string explanation, string source)
		{
			this.Line = line;
			this.Column = column;
			this.Message = message;
			this.MessageId = messageId;
			this.Explanation = explanation;
			this.Source = source;
		}
	}
}
namespace MuonKit.W3cValidationClient.Html
{
	/// <summary>
	/// Parses the response from the W3C API
	/// </summary>
	public interface IValidationResponseParser
	{
		ValidationReport ParseResponse(string response);
	}
}
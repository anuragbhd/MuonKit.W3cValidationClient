namespace MuonKit.W3cValidationClient
{
	/// <summary>
	/// Parses the response from the W3C API
	/// </summary>
	public interface IResponseParser
	{
		ValidationReport ParseResponse(string response);
	}
}
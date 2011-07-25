namespace MuonKit.W3cValidationClient
{
	public interface IHttpClient
	{
		/// <summary>
		/// Performs and HTTP POST
		/// </summary>
		/// <param name="url">The URL to POST to</param>
		/// <param name="requestBody">The request body</param>
		/// <returns>The response body</returns>
		string Post(string url, string requestBody);
	}
}
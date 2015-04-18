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

        /// <summary>
        /// Performs and HTTP GET
        /// </summary>
        /// <param name="url">The URL to GET to</param>
        /// <param name="queryString">The query string</param>
        /// <returns>The response body</returns>
        string Get(string url, string queryString);
	}
}
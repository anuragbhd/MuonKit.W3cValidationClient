using System.Net;

namespace MuonKit.W3cValidationClient
{
	public class HttpClient : IHttpClient
	{
		public string Post(string url, string requestBody)
		{
			var webClient = new WebClient();
			return webClient.UploadString(url, requestBody);
		}
	}
}

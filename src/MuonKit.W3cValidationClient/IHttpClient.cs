namespace MuonKit.W3cValidationClient
{
	public interface IHttpClient
	{
		string Post(string url, string requestBody);
	}
}
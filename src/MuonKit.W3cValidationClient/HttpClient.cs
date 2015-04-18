using System.IO;
using System.Net;

namespace MuonKit.W3cValidationClient
{
	public class HttpClient : IHttpClient
	{
		public string Post(string url, string requestBody)
		{
			var webClient = new WebClient();
			webClient.Headers.Add ("User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36");
			webClient.Headers.Add ("Accept", "application/soap+xml");
			return webClient.UploadString(url, requestBody);
		}

        public string Get(string url, string queryString)
        {
            //var webClient = new WebClient();
            //webClient.Headers.Add("User-Agent", "Mozilla/5.0 (X11; Linux x86_64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/40.0.2214.115 Safari/537.36");
            //webClient.Headers.Add("Accept", "application/soap+xml");
            //System.Uri address = new System.Uri(url);
            //return webClient.DownloadString(address);
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url + "?" + queryString);
            request.Method = "GET";
            string result = string.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                result = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }

            return result;
        }
	}
}

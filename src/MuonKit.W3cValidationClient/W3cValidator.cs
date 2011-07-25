using System.Web;
using MuonKit.W3cValidationClient.Html;

namespace MuonKit.W3cValidationClient
{
	public class W3CHtmlValidator : IW3CHtmlValidator
	{
		readonly IHttpClient httpClient;
		readonly IValidationResponseParser validationResponseParser;

		public W3CHtmlValidator(IHttpClient httpClient, IValidationResponseParser validationResponseParser)
		{
			this.httpClient = httpClient;
			this.validationResponseParser = validationResponseParser;
		}

		public ValidationReport ValidateUri(string uri, string charset, string doctype)
		{
			return ValidateUri("http://validator.w3.org/check", uri, charset, doctype);
		}

		public ValidationReport ValidateUri(string validatorAddress, string uri, string charset = null, string doctype = null)
		{
			var body = "output=soap12&uri=" + HttpUtility.UrlEncode(uri);

			if(!string.IsNullOrEmpty(charset))
				body += "&charset=" + HttpUtility.UrlEncode(charset);

			if(!string.IsNullOrEmpty(doctype))
				body += "&doctype=" + HttpUtility.UrlEncode(doctype);

			var response = this.httpClient.Post(validatorAddress, body);

			return this.validationResponseParser.ParseResponse(response);
		}

		public ValidationReport ValidateDocument(string document, string charset = null, string doctype = null)
		{
			return this.ValidateDocument("http://validator.w3.org/check", document, charset, doctype);
		}

		/// <summary>
		/// Validates the given document
		/// </summary>
		/// <param name="validatorAddress"></param>
		/// <param name="document"></param>
		/// <param name="charset"></param>
		/// <param name="doctype"></param>
		/// <returns></returns>
		public ValidationReport ValidateDocument(string validatorAddress, string document, string charset = null, string doctype = null)
		{
			var body = "output=soap12&fragment=" + HttpUtility.UrlEncode(document);

			if (!string.IsNullOrEmpty(charset))
				body += "&charset=" + HttpUtility.UrlEncode(charset);

			if (!string.IsNullOrEmpty(doctype))
				body += "&doctype=" + HttpUtility.UrlEncode(doctype);

			var response = this.httpClient.Post(validatorAddress, body);

			return this.validationResponseParser.ParseResponse(response);
		}
	}
}
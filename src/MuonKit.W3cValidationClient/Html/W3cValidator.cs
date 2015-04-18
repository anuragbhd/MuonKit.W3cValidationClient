using System.Web;

namespace MuonKit.W3cValidationClient.Html
{
	public class W3CValidator : IW3CValidator
	{
		const string defaultValidatorAddress = "http://validator.w3.org/check";
		readonly IHttpClient httpClient;
		readonly IValidationResponseParser validationResponseParser;

		/// <summary>
		/// Creates a new validator
		/// </summary>
		public W3CValidator() : 
			this(new HttpClient(), new Soap12ValidationResponseParser())
		{
		}

		/// <summary>
		/// Creates a new validator
		/// </summary>
		/// <param name="httpClient">The HTTP client</param>
		/// <param name="validationResponseParser">The API reponse parser</param>
		public W3CValidator(IHttpClient httpClient, IValidationResponseParser validationResponseParser)
		{
			this.httpClient = httpClient;
			this.validationResponseParser = validationResponseParser;
		}

		public ValidationReport ValidateUri(string uri, string charset, string doctype)
		{
			return ValidateUri(defaultValidatorAddress, uri, charset, doctype);
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
			return this.ValidateDocument(defaultValidatorAddress, document, charset, doctype);
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
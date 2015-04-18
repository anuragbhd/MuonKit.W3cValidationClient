using System.Web;

namespace MuonKit.W3cValidationClient.Css
{
	public class CSSValidator : ICSSValidator
	{
		const string defaultValidatorAddress = "https://jigsaw.w3.org/css-validator/validator";
		readonly IHttpClient httpClient;
		readonly IValidationResponseParser validationResponseParser;

		/// <summary>
		/// Creates a new validator
		/// </summary>
		public CSSValidator() : 
			this(new HttpClient(), new Soap12ValidationResponseParser())
		{
		}

		/// <summary>
		/// Creates a new validator
		/// </summary>
		/// <param name="httpClient">The HTTP client</param>
		/// <param name="validationResponseParser">The API reponse parser</param>
        public CSSValidator(IHttpClient httpClient, IValidationResponseParser validationResponseParser)
		{
			this.httpClient = httpClient;
			this.validationResponseParser = validationResponseParser;
		}

        public ValidationReport ValidateUri(string uri, string usermedium, string profile)
		{
            return ValidateUri(defaultValidatorAddress, uri, usermedium, profile);
		}

        public ValidationReport ValidateUri(string validatorAddress, string uri, string usermedium = null, string profile = null)
		{
			var queryString = "output=soap12&uri=" + HttpUtility.UrlEncode(uri);

            if (!string.IsNullOrEmpty(profile))
                queryString += "&usermedium=" + HttpUtility.UrlEncode(usermedium);

            if (!string.IsNullOrEmpty(profile))
                queryString += "&profile=" + HttpUtility.UrlEncode(profile);

			var response = this.httpClient.Get(validatorAddress, queryString);

			return this.validationResponseParser.ParseResponse(response);
		}

        public ValidationReport ValidateDocument(string document, string usermedium = null, string profile = null)
		{
			return this.ValidateDocument(defaultValidatorAddress, document, usermedium, profile);
		}

		/// <summary>
		/// Validates the given document
		/// </summary>
		/// <param name="validatorAddress"></param>
		/// <param name="document"></param>
        /// <param name="usermedium"></param>
		/// <param name="profile"></param>
		/// <returns></returns>
        public ValidationReport ValidateDocument(string validatorAddress, string document, string usermedium = null, string profile = null)
		{
            var queryString = "output=soap12&text=" + HttpUtility.UrlEncode(document);

            if (!string.IsNullOrEmpty(profile))
                queryString += "&usermedium=" + HttpUtility.UrlEncode(usermedium);

			if (!string.IsNullOrEmpty(profile))
                queryString += "&profile=" + HttpUtility.UrlEncode(profile);

			var response = this.httpClient.Get(validatorAddress, queryString);

			return this.validationResponseParser.ParseResponse(response);
		}
	}
}
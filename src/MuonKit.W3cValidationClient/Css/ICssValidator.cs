namespace MuonKit.W3cValidationClient.Css
{
	public interface ICSSValidator
	{
		/// <summary>
        /// Validates a remote URI, using "http://jigsaw.w3.org/css-validator/validator"
		/// </summary>
		/// <param name="uri"></param>
        /// <param name="usermedium"></param>
        /// <param name="profile"></param>
		/// <returns></returns>
        ValidationReport ValidateUri(string uri, string usermedium, string profile);

		/// <summary>
        /// Validates the given document, using "http://jigsaw.w3.org/css-validator/validator"
		/// </summary>
		/// <param name="document"></param>
        /// <param name="usermedium"></param>
        /// <param name="profile"></param>
		/// <returns></returns>
        ValidationReport ValidateDocument(string document, string usermedium, string profile);

		/// <summary>
		/// Validates a remote URI
		/// </summary>
		/// <param name="validatorAddress">The address of the validation api</param>
		/// <param name="uri"></param>
        /// <param name="usermedium"></param>
        /// <param name="profile"></param>
		/// <returns></returns>
        ValidationReport ValidateUri(string validatorAddress, string uri, string usermedium, string profile = null);

		/// <summary>
		/// Validates the given document
		/// </summary>
		/// <param name="validatorAddress">The address of the validation api</param>
		/// <param name="document"></param>
        /// <param name="usermedium"></param>
        /// <param name="profile"></param>
		/// <returns></returns>
        ValidationReport ValidateDocument(string validatorAddress, string document, string usermedium, string profile = null);
	}
}
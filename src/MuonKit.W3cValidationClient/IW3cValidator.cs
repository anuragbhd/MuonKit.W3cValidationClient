using MuonKit.W3cValidationClient.Html;

namespace MuonKit.W3cValidationClient
{
	public interface IW3CHtmlValidator
	{
		/// <summary>
		/// Validates a remote URI, using "http://validator.w3.org/check"
		/// </summary>
		/// <param name="uri"></param>
		/// <param name="charset"></param>
		/// <param name="doctype"></param>
		/// <returns></returns>
		ValidationReport ValidateUri(string uri, string charset, string doctype);

		/// <summary>
		/// Validates the given document, using "http://validator.w3.org/check"
		/// </summary>
		/// <param name="document"></param>
		/// <param name="charset"></param>
		/// <param name="doctype"></param>
		/// <returns></returns>
		ValidationReport ValidateDocument(string document, string charset, string doctype);

		/// <summary>
		/// Validates a remote URI
		/// </summary>
		/// <param name="validatorAddress">The address of the validation api</param>
		/// <param name="uri"></param>
		/// <param name="charset"></param>
		/// <param name="doctype"></param>
		/// <returns></returns>
		ValidationReport ValidateUri(string validatorAddress, string uri, string charset = null, string doctype = null);

		/// <summary>
		/// Validates the given document
		/// </summary>
		/// <param name="validatorAddress">The address of the validation api</param>
		/// <param name="document"></param>
		/// <param name="charset"></param>
		/// <param name="doctype"></param>
		/// <returns></returns>
		ValidationReport ValidateDocument(string validatorAddress, string document, string charset = null, string doctype = null);
	}
}
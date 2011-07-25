using System.Collections.Generic;
using System.Xml;

namespace MuonKit.W3cValidationClient
{
	/// <summary>
	/// Handles parsing the SOAP 1.2 response from the W3C API
	/// </summary>
	public class Soap12ResponseParser : IResponseParser
	{
		public ValidationReport ParseResponse(string response)
		{
			var xmlDocument = new XmlDocument();
			xmlDocument.LoadXml(response);

			var xmlNamespaceManager = new XmlNamespaceManager(xmlDocument.NameTable);
			
			// this is a hack. how to get them auto from the document?
			xmlNamespaceManager.AddNamespace("env", "http://www.w3.org/2003/05/soap-envelope");
			xmlNamespaceManager.AddNamespace("m", "http://www.w3.org/2005/10/markup-validator");

			var validationResponse = xmlDocument.SelectSingleNode("env:Envelope/env:Body/m:markupvalidationresponse", xmlNamespaceManager);

			var uri = validationResponse.SelectSingleNode("m:uri", xmlNamespaceManager).InnerText;
			var checkedBy = validationResponse.SelectSingleNode("m:checkedby", xmlNamespaceManager).InnerText;
			var doctype = validationResponse.SelectSingleNode("m:doctype", xmlNamespaceManager).InnerText;
			var charset = validationResponse.SelectSingleNode("m:charset", xmlNamespaceManager).InnerText;
			var validity = bool.Parse(validationResponse.SelectSingleNode("m:validity", xmlNamespaceManager).InnerText);


			var errors = validationResponse.SelectSingleNode("m:errors", xmlNamespaceManager);
			var errorCount = int.Parse(errors.SelectSingleNode("m:errorcount", xmlNamespaceManager).InnerText);

			var errorList = errors.SelectNodes("m:errorlist/m:error", xmlNamespaceManager);
			var parsedErrors = new List<ValidationMessage>(errorCount);
			foreach(XmlNode error in errorList)
			{
				ValidationMessage validationMessage = ParseMessage(xmlNamespaceManager, error);
				parsedErrors.Add(validationMessage);
			}

			var warnings = validationResponse.SelectSingleNode("m:warnings", xmlNamespaceManager);
			var warningCount = int.Parse(warnings.SelectSingleNode("m:warningcount", xmlNamespaceManager).InnerText);

			var warningList = warnings.SelectNodes("m:warninglist/m:warning", xmlNamespaceManager);
			var parsedWarnings = new List<ValidationMessage>(warningCount);
			foreach (XmlNode warning in warningList)
			{
				ValidationMessage validationMessage = ParseMessage(xmlNamespaceManager, warning);
				parsedWarnings.Add(validationMessage);
			}

			return new ValidationReport(uri, checkedBy, doctype, charset, validity, errorCount, parsedErrors, warningCount, parsedWarnings);
		}

		/// <summary>
		/// Parses a warning or error
		/// </summary>
		/// <param name="xmlNamespaceManager"></param>
		/// <param name="error"></param>
		/// <returns></returns>
		static ValidationMessage ParseMessage(XmlNamespaceManager xmlNamespaceManager, XmlNode error)
		{
			var xmlLine = error.SelectSingleNode("m:line", xmlNamespaceManager);
			var line = xmlLine != null ? (int?)int.Parse(xmlLine.InnerText) : null;

			var xmlCol = error.SelectSingleNode("m:col", xmlNamespaceManager);
			var col = xmlCol != null ? (int?)int.Parse(xmlCol.InnerText) : null;

			var xmlMessage = error.SelectSingleNode("m:message", xmlNamespaceManager);
			var message = xmlMessage != null ? xmlMessage.InnerText : null;

			var xmlMessageId = error.SelectSingleNode("m:messageid", xmlNamespaceManager);
			var messageId = xmlMessageId != null ? xmlMessageId.InnerText : null;

			var xmlExplanation = error.SelectSingleNode("m:explanation", xmlNamespaceManager);
			var explanation = xmlExplanation != null ? xmlExplanation.InnerText : null;

			var xmlSource = error.SelectSingleNode("m:source", xmlNamespaceManager);
			var source = xmlSource != null ? xmlSource.InnerText : null;

			return new ValidationMessage(line, col, message, messageId, explanation, source);
		}
	}
}
using MuonKit.W3cValidationClient.Html;
using NUnit.Framework;

namespace MuonKit.W3cValidationClient.Tests.W3cValidatorSpecs
{
	[TestFixture]
	public class ShouldWork
	{
		[Test]
		public void ShouldntExplode()
		{
			var validator = new W3CValidator(new HttpClient(), new Soap12ValidationResponseParser());

			var validationReport = validator.ValidateDocument(@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd""><html xmlns=""http://www.w3.org/1999/xhtml""><head><title>test</title></head><body><p>hello</p></body></html>");

			Assert.AreEqual(true, validationReport.Validity);
		}
	}
}
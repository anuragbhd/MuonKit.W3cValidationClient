using System.Linq;
using NUnit.Framework;

namespace MuonKit.W3cValidationClient.Tests.Soap12ResponseParserSpecs
{
	[TestFixture]
	public class WarningsAndErrors
	{
		const string ResponseBody = @"<?xml version=""1.0"" encoding=""UTF-8""?>
<env:Envelope xmlns:env=""http://www.w3.org/2003/05/soap-envelope"">
<env:Body>
<m:markupvalidationresponse env:encodingStyle=""http://www.w3.org/2003/05/soap-encoding"" xmlns:m=""http://www.w3.org/2005/10/markup-validator"">
    
    <m:uri>upload://Form Submission</m:uri>
    <m:checkedby>http://validator.w3.org/</m:checkedby>
    <m:doctype>-//W3C//DTD XHTML 1.0 Strict//EN</m:doctype>
    <m:charset>utf-8</m:charset>
    <m:validity>false</m:validity>
    <m:errors>
        <m:errorcount>1</m:errorcount>
        <m:errorlist>
          
            <m:error>
                <m:line>20</m:line>
                <m:col>100</m:col>
                <m:message>required attribute &quot;alt&quot; not specified</m:message>
                <m:messageid>127</m:messageid>
                <m:explanation>  <![CDATA[
                      <p class=""helpwanted"">
      <a
        href=""feedback.html?uri=;errmsg_id=127#errormsg""
	title=""Suggest improvements on this error message through our feedback channels"" 
      >&#x2709;</a>
    </p>

    <div class=""ve mid-127"">
    <p>
      The attribute given above is required for an element that you've used,
      but you have omitted it. For instance, in most HTML and XHTML document
      types the ""type"" attribute is required on the ""script"" element and the
      ""alt"" attribute is required for the ""img"" element.
    </p>
    <p>
      Typical values for <code>type</code> are 
      <code>type=""text/css""</code> for <code>&lt;style&gt;</code>
      and <code>type=""text/javascript""</code> for <code>&lt;script&gt;</code>.
    </p>
  </div>

                  ]]>
                </m:explanation>
                <m:source><![CDATA[….w3.org/&#34;&#62;&#60;img width=&#34;110&#34; height=&#34;61&#34; id=&#34;logo&#34; src=&#34;../images/w3c.png&#34; /<strong title=""Position where error was detected."">&#62;</strong>&#60;/a&#62;]]></m:source>
            </m:error>
           
        </m:errorlist>
    </m:errors>
    <m:warnings>
        <m:warningcount>2</m:warningcount>
        <m:warninglist>
    
  <m:warning><m:messageid>W27</m:messageid><m:message>No Character encoding declared at document level</m:message></m:warning>

  <m:warning><m:messageid>W28</m:messageid><m:message>Using Direct Input mode: UTF-8 character encoding assumed</m:message></m:warning>
        </m:warninglist>
    </m:warnings>
</m:markupvalidationresponse>
</env:Body>
</env:Envelope>

";

		[Test]
		public void ShouldParseCorrectly()
		{
			var soap12ResponseParser = new Soap12ResponseParser();
			var validationReport = soap12ResponseParser.ParseResponse(ResponseBody);

			Assert.AreEqual("upload://Form Submission", validationReport.Uri);
			Assert.AreEqual("http://validator.w3.org/", validationReport.CheckedBy);
			Assert.AreEqual("-//W3C//DTD XHTML 1.0 Strict//EN", validationReport.Doctype);
			Assert.AreEqual("utf-8", validationReport.Charset);
			Assert.AreEqual(false, validationReport.Validity);

			Assert.AreEqual(1, validationReport.ErrorCount);
			
			var errors = validationReport.Errors.ToArray();
			Assert.AreEqual(20, errors[0].Line);
			Assert.AreEqual(100, errors[0].Column);
			Assert.AreEqual("required attribute \"alt\" not specified", errors[0].Message);
		}
	}
}
using System;
using MuonKit.W3cValidationClient.Html;
using MuonKit.W3cValidationClient.Css;

namespace MuonKit.W3cValidationClient.Test
{
	class MainClass
	{
		public static void Main (string[] args)
		{
			W3CValidator htmlValidator = new W3CValidator();
            CSSValidator cssValidator = new CSSValidator();
			//MuonKit.W3cValidationClient.Html.ValidationReport reportHtml = htmlValidator.ValidateDocument (@"<!DOCTYPE html PUBLIC ""-//W3C//DTD XHTML 1.0 Strict//EN"" ""http://www.w3.org/TR/xhtml1/DTD/xhtml1-strict.dtd""><html xmlns=""http://www.w3.org/1999/xhtml""><head><title>test</title></head><body><p><div>hello</p></body></html>", null, null);
            MuonKit.W3cValidationClient.Css.ValidationReport reportCss = cssValidator.ValidateUri("http://anuragbhandari.com", "all", "css3");
            //MuonKit.W3cValidationClient.Css.ValidationReport reportCss = cssValidator.ValidateDocument("body { color:black; }");
            Console.WriteLine ("");
		}
	}
}

using System.Collections.Generic;

namespace MuonKit.W3cValidationClient.Css
{
	public class ValidationReport
	{
		public string Uri { get; private set; }
		public string CheckedBy { get; private set; }
        public string Csslevel { get; private set; }
		public bool Validity { get; private set; }

		public long ErrorCount { get; private set; }
		public IEnumerable<ValidationMessage> Errors { get; private set; }

		public long WarningCount { get; private set; }
		public IEnumerable<ValidationMessage> Warnings { get; private set; }

        public ValidationReport(string uri, string checkedBy, string csslevel, bool validity, long errorCount, IEnumerable<ValidationMessage> errors, long warningCount, IEnumerable<ValidationMessage> warnings)
		{
			this.Uri = uri;
			this.CheckedBy = checkedBy;
            this.Csslevel = csslevel;
			this.Validity = validity;
			this.ErrorCount = errorCount;
			this.Errors = errors;
			this.WarningCount = warningCount;
			this.Warnings = warnings;
		}
	}
}
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    public class XlsxReportService : ReportServiceBase
    {
        public XlsxReportService(string[] args, ReportServiceBase next) : base(args, next) { }
        
        public override string extension { get; } = ".xlsx";

        protected override DataRow[] GetDataRows(string text)
        {
            if (args[0].EndsWith(extension))
            {
                return new DataRow[0];
            }

            return base.GetDataRows(text);
        }
    }
}
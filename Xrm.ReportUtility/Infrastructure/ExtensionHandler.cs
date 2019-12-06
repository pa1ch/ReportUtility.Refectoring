using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility.Infrastructure
{
    public class ExtensionHandler
    {
        private readonly ReportServiceBase handler;
        private readonly string[] args;
        
        public ExtensionHandler(string[] args)
        {
            this.args = args;
            handler = new XlsxReportService(args, null);
            handler = new CsvReportService(args, handler);
            handler = new TxtReportService(args, handler);
        }

        public Report CreateReport()
        {
            return handler.CreateReport();
        }
        
    }
}
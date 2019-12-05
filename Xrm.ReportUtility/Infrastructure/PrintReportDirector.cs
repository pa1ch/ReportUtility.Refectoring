using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Infrastructure
{
    public class PrintReportDirector
    {
        private IReportBuilder reportBuilder;
        
        public PrintReportDirector(IReportBuilder reportBuilder)
        {
            this.reportBuilder = reportBuilder;
        }

        public void PrintReport()
        {
            
        }
    }
}
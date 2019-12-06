using System.IO;
using System.Linq;
using CsvHelper;
using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    public class CsvReportService : ReportServiceBase
    {
        public CsvReportService(string[] args, ReportServiceBase next) : base(args, next) { }

        public override string extension { get; } = ".csv";

        protected override DataRow[] GetDataRows(string text)
        {
            if (args[0].EndsWith(extension))
            {
                using (TextReader textReader = new StringReader(text))
                {
                    var csvReader = new CsvReader(textReader);

                    csvReader.Configuration.Delimiter = ";";
                    csvReader.Configuration.RegisterClassMap<RowDataMapper>();

                    return csvReader.GetRecords<DataRow>().ToArray();
                }
            }

            return base.GetDataRows(text);
        }
    }
}
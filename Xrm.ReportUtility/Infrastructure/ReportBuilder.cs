using System;
using System.Collections.Generic;
using System.Linq;
using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public class ReportBuilder 
    {
        private readonly RowBuilderDirector builderDirector;
        private readonly Report report;
        
        public ReportBuilder(Report report)
        {
            this.report = report;
            builderDirector = new RowBuilderDirector(report.Config);
        }

        private void GetHeaderRow()
        {
            builderDirector.SetBuilder(new HeaderRowBuilder());
            Console.WriteLine(builderDirector.GetResult());
        }

        private string GetRowTemplate()
        {
            builderDirector.SetBuilder(new RowTemplateBuilder());
            return builderDirector.GetResult();
        }

        private string[] GetDataRow(DataRow row)
        {
            builderDirector.SetBuilder(new DataRowBuilder(row));
            return builderDirector.GetResult().Split();
        }

        public void PrintReport()
        {
            if (report.Config.WithData && report.Data != null && report.Data.Any())
            {
                GetHeaderRow();
                for (var i = 0; i < report.Data.Length; i++)
                {
                    var res = GetDataRow(report.Data[i]);
                    var dataParams = new string[res.Length+1];
                    dataParams[0] = (i + 1).ToString();
                    for(var j = 0; j < res.Length; j++)
                    {
                        dataParams[j + 1] = res[j];
                    }
                       
                    Console.WriteLine(GetRowTemplate(), dataParams);
                }
                
                if (report.Rows != null && report.Rows.Any())
                {
                    Console.WriteLine("Итого:");
                    foreach (var reportRow in report.Rows)
                    {
                        Console.WriteLine("  {0,-20}\t{1}", reportRow.Name, reportRow.Value);
                    }
                }
            }
        }
    }
}
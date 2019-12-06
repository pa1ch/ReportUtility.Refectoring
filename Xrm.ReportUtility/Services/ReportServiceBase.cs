using System;
using System.IO;
using System.Linq;
using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    public abstract class ReportServiceBase : IReportService
    {
        private readonly ReportServiceBase nextHandler;

        protected readonly string[] args;
        public abstract string extension { get; }

        protected ReportServiceBase(string[] args, ReportServiceBase nextHandler)
        {
            this.args = args;
            this.nextHandler = nextHandler;
        }

        public Report CreateReport()
        {
            var config = ParseConfig();
            CheckForWarning(config);
            var dataTransformer = DataTransformerCreator.CreateTransformer(config);

            var fileName = args[0];
            var text = File.ReadAllText(fileName);
            var data = GetDataRows(text);
            return dataTransformer.TransformData(data);
        }

        private ReportConfig ParseConfig()
        {
            return new ReportConfig
            {
                WithData = args.Contains("-data"),

                WithIndex = args.Contains("-withIndex"),
                WithTotalVolume = args.Contains("-withTotalVolume"),
                WithTotalWeight = args.Contains("-withTotalWeight"),
                
                WithoutVolume = args.Contains("-withoutVolume"),
                WithoutWeight = args.Contains("-withoutWeight"),
                WithoutCost = args.Contains("-withoutCost"),
                WithoutCount = args.Contains("-withoutCount"),

                VolumeSum = args.Contains("-volumeSum"),
                WeightSum = args.Contains("-weightSum"),
                CostSum = args.Contains("-costSum"),
                CountSum = args.Contains("-countSum")
            };
        }

        private void CheckForWarning(ReportConfig config)
        {
            if ((config.WithIndex || config.WithTotalVolume || config.WithTotalWeight) && !config.WithData)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("WARNING");
                Console.ForegroundColor = ConsoleColor.Gray;
            }

        }

        protected virtual DataRow[] GetDataRows(string text)
        {
            nextHandler?.GetDataRows(text);
            throw new NotSupportedException("this extension not supported");
        }
    }
}

﻿using System;
using System.Linq;
using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using Xrm.ReportUtility.Services;

namespace Xrm.ReportUtility
{
    public static class Program
    {
        // "Files/table.txt" -data -weightSum -costSum -withIndex -withTotalVolume
        public static void Main(string[] args)
        {
            var service = GetReportService(args);

            var report = service.CreateReport();

            var reportBuilder = new ReportBuilder(report);
            reportBuilder.PrintReport();
            
            Console.WriteLine("");
            Console.WriteLine("Press enter...");
            Console.ReadLine();
        }

        private static IReportService GetReportService(string[] args)
        {
            var filename = args[0];

            if (filename.EndsWith(".txt"))
            {
                return new TxtReportService(args);
            }

            if (filename.EndsWith(".csv"))
            {
                return new CsvReportService(args);
            }

            if (filename.EndsWith(".xlsx"))
            {
                return new XlsxReportService(args);
            }

            throw new NotSupportedException("this extension not supported");
        }
    }
}
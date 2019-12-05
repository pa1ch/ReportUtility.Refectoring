using System.Net;
using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public class DataRowBuilder : IRowBuilder
    {
        private string result = "";
        private DataRow row;
        
        public DataRowBuilder(DataRow row)
        {
            this.row = row;
        }

        public void AddName()
        {
            result += row.Name;
            result += " ";
        }

        public void AddValue()
        {
            result += row.Volume;
            result += " ";
        }

        public void AddWeight()
        {
            result += row.Weight;
            result += " ";
        }

        public void AddCost()
        {
            result += row.Cost;
            result += " ";
        }

        public void AddCount()
        {
            result += row.Count;
            result += " ";
        }

        public void AddIndex()
        {
            
        }

        public void AddTotalVolume()
        {
            result += row.Volume * row.Count;
            result += " ";
        }

        public void AddTotalWeight()
        {
            result += row.Weight * row.Count;
            result += " ";
        }

        public string GetRow()
        {
            if (result.EndsWith(" "))
                result = result.Remove(result.Length - 1);
            return result;
        }
    }
}
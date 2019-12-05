using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Infrastructure.Builders
{
    public class RowTemplateBuilder : IRowBuilder
    {
        private string result = "";
        private int index = 1;
        
        public void AddName()
        {
            result += $"{{{index},12}}\t";
            index += 1;
        }

        public void AddValue()
        {
            result += $"{{{index},14}}\t";
            index += 1;
        }
        
        public void AddWeight()
        {
            result += $"{{{index},14}}\t";
            index += 1;
        }
        
        public void AddCost()
        {
            result += $"{{{index},9}}\t";
            index += 1;
        }
        
        public void AddCount()
        {
            result += $"{{{index},10}}";
            index += 1;
        }
        
        public void AddIndex()
        {
            result = "{0}\t" + result;
        }

        public void AddTotalVolume()
        {
            result += $"\t{{{index},15}}";
            index += 1;
        }

        public void AddTotalWeight()
        {
            result += $"\t{{{index},13}}";
            index += 1;
        }

        public string GetRow()
        {
            return result;
        }
    }
}
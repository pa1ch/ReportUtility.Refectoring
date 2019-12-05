using Xrm.ReportUtility.Interfaces;

namespace Xrm.ReportUtility.Infrastructure.Builders
{
    public class HeaderRowBuilder : IRowBuilder
    {
        private string result = "";

        public void AddName()
        {
            result += "Наименование\t";
        }

        public void AddValue()
        {
            result += "Объём упаковки\t"; 
        }
        
        public void AddWeight()
        {
            result += "Масса упаковки\t";
        }
        
        public void AddCost()
        {
            result += "Стоимость\t";
        }
        
        public void AddCount()
        {
            result += "Количество";
        }
        
        public void AddIndex()
        {
            result = "№\t" + result;
        }

        public void AddTotalVolume()
        {
            result += "\tСуммарный объём";
        }

        public void AddTotalWeight()
        {
            result += result + "\tСуммарный вес";
        }
        
        public string GetRow()
        {
            return result;
        }
    }
}
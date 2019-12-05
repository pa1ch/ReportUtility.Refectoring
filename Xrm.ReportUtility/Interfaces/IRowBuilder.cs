namespace Xrm.ReportUtility.Interfaces
{
    public interface IRowBuilder
    {
        void AddName();
        
        void AddValue();

        void AddWeight();
        
        void AddCost();
        
        void AddCount();

        void AddIndex();
        
        void AddTotalVolume();
        
        void AddTotalWeight();
        
        string GetRow();

    }
}
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure.Builders
{
    public class RowBuilderDirector : IRowBuilderDirector
    {
        private readonly ReportConfig config;
        private IRowBuilder builder;
        
        public RowBuilderDirector(ReportConfig config)
        {
            this.config = config;
            
        }

        public void SetBuilder(IRowBuilder builder)
        {
            this.builder = builder;
        }

        public string GetResult()
        {
            builder.AddName();
            if (config.WithIndex)
                builder.AddIndex();
            if (!config.WithoutVolume)
                builder.AddValue();
            if (!config.WithoutWeight)
                builder.AddWeight();
            if (!config.WithoutCost)
                builder.AddCost();
            if (!config.WithoutCount)
                builder.AddCount();
            if (config.WithTotalVolume)
                builder.AddTotalVolume();
            if (config.WithTotalWeight)
                builder.AddTotalWeight();
            return builder.GetRow();
        }
    }
}
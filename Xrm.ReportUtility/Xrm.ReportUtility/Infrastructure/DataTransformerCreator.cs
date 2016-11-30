using Xrm.ReportUtility.Infrastructure.Transformers;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Infrastructure
{
    public static class DataTransformerCreator
    {
        public static IDataTransformer CreateTransformer(ReportConfig config) // НИЖЕ ПАТТЕРН ДЕКОРАТОР, Сам метод CreateTransformer фабричный
        {
            IDataTransformer service = new DataTransformer(config);

            if (config.WithData)    
            {
                service = new WithDataReportTransformer(service); // декоратор
            }

            if (config.VolumeSum)
            {
                service = new VolumeSumReportTransformer(service); // декоратор
            }

            if (config.WeightSum)
            {
                service = new WeightSumReportTransfomer(service); // декоратор
            }

            if (config.CostSum)
            {
                service = new CostSumReportTransformer(service); // декоратор
            }

            if (config.CountSum)
            {
                service = new CountSumReportTransformer(service); // декоратор
            }

            return service;
        }
    }
}
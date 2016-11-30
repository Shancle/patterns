using System.IO;
using System.Linq;
using Xrm.ReportUtility.Infrastructure;
using Xrm.ReportUtility.Interfaces;
using Xrm.ReportUtility.Models;
using System.Reflection;

namespace Xrm.ReportUtility.Services
{
    public abstract class ReportServiceBase : IReportService
    {
        private static readonly PropertyInfo[] properties = typeof(ReportConfig).GetProperties(); // что бы каждый вызов не получать все проперти получим 1 раз
        private readonly string[] _args;

        protected ReportServiceBase(string[] args)
        {
            _args = args;
        }

        public Report CreateReport() // ШАБЛОННЫЙ МЕТОД
        {
            var config = ParseConfig();
            var dataTransformer = DataTransformerCreator.CreateTransformer(config);

            var fileName = _args[0];
            var text = File.ReadAllText(fileName);
            var data = GetDataRows(text);
            return dataTransformer.TransformData(data);
        }

        private ReportConfig ParseConfig() // Сделал рефлексию, это лучше чем вписывать здесь на проверку каждого поля из конфига
        {                                  
            var result = new ReportConfig();
            foreach (var proterty in properties)
            {
                var name = proterty.Name.ToCharArray();
                name[0] = char.ToLower(name[0]); // т.к. изначально аргументы с маленькой а свойства с большой
                if(_args.Contains("-"+new string(name))) // т.к. по умолчанию bool = false то осталось в нужных поставить true
                {
                    proterty.SetValue(result, true);
                }
            }
            return result;
            /*return new ReportConfig 
            {
                WithData = _args.Contains("-withData"),

                WithIndex = _args.Contains("-withIndex"),
                WithTotalVolume = _args.Contains("-withTotalVolume"),
                WithTotalWeight = _args.Contains("-withTotalWeight"),

                WithoutVolume = _args.Contains("-withoutVolume"),  //
                WithoutWeight = _args.Contains("-withoutWeight"),  // Для 3-ей хотелки
                WithoutCost = _args.Contains("-withoutCost"),      // 
                WithoutCount = _args.Contains("-withoutCount"),    //

                VolumeSum = _args.Contains("-volumeSum"),
                WeightSum = _args.Contains("-weightSum"),
                CostSum = _args.Contains("-costSum"),
                CountSum = _args.Contains("-countSum")
            };*/
        }

        protected abstract DataRow[] GetDataRows(string text);
    }
}

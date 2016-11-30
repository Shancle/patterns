using Xrm.ReportUtility.Models;

namespace Xrm.ReportUtility.Services
{
    public class XlsxReportService : ReportServiceBase
    {
        public XlsxReportService(string[] args) : base(args) { }

        protected override DataRow[] GetDataRows(string text) // не плохая реализация
        {
            return new DataRow[0];
        }
    }
}
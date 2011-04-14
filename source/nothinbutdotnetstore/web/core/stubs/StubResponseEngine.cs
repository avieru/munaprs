using System.Web;

namespace nothinbutdotnetstore.web.core.stubs
{
    public class StubResponseEngine : ICanDisplayReportModels
    {
        public void display<ReportModel>(ReportModel report_model)
        {
            HttpContext.Current.Items.Add("blah", report_model);
            HttpContext.Current.Server.Transfer("~/views/DepartmentBrowser.aspx");
        }
    }
}
using nothinbutdotnetstore.web.application.stubs;
using nothinbutdotnetstore.web.core;
using nothinbutdotnetstore.web.core.stubs;

namespace nothinbutdotnetstore.web.application
{
    using nothinbutdotnetstore.stubs;

    public class ViewMainDepartmentsInTheStore : IEncapsulateApplicationSpecificFunctionality
    {
        ICanDisplayReportModels response_engine;
        ICanFindInformationInTheStoreCatalog reporting_gateway;

        public ViewMainDepartmentsInTheStore():this(Stub.a<StubResponseEngine>(x => x.not_allowed_after(201104211537)),
            Stub.a<StubStoreCatalog>())
        {
        }

        public ViewMainDepartmentsInTheStore(ICanDisplayReportModels response_engine,
                                             ICanFindInformationInTheStoreCatalog reporting_gateway)
        {
            this.response_engine = response_engine;
            this.reporting_gateway = reporting_gateway;
        }

        public void process(IContainRequestDetails request)
        {
            response_engine.display(reporting_gateway.get_the_main_departments_in_the_store());
        }
    }
}
using System.Collections.Generic;
using developwithpassion.specifications.extensions;
using developwithpassion.specifications.moq;
using Machine.Specifications;
using nothinbutdotnetstore.web.application;
using nothinbutdotnetstore.web.application.models;
using nothinbutdotnetstore.web.core;
using Arg = Moq.It;

namespace nothinbutdotnetstore.specs
{
    public class ViewMainDepartmentsInTheStoreSpecs
    {
        public abstract class concern : Observes<IEncapsulateApplicationSpecificFunctionality,
                                            ViewMainDepartmentsInTheStore>
        {
        }

        [Subject(typeof(ViewMainDepartmentsInTheStore))]
        public class when_run : concern
        {
            Establish e = () =>
            {
                the_main_departments = new List<DepartmentModel> {new DepartmentModel()};
                request_details = fake.an<IContainRequestDetails>();
                response_engine = depends.on<ICanDisplayReportModels>();
                reporting_gateway = depends.on<ICanFindInformationInTheStoreCatalog>();
                reporting_gateway.setup(x => x.get_the_main_departments_in_the_store()).Return(the_main_departments);
            };

            Because b = () =>
                sut.process(request_details);

            It should_tell_the_response_engine_to_display_the_model = () =>
                response_engine.received(x => x.display(the_main_departments));

            static ICanDisplayReportModels response_engine;
            static IContainRequestDetails request_details;
            static ICanFindInformationInTheStoreCatalog reporting_gateway;
            static IEnumerable<DepartmentModel> the_main_departments;
        }
    }
}
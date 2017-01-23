using UT.Application.Storage;
using UT.Presentation.Web.Models.ControllerContext;
using UT.Presentation.Web.Tests.Helpers;
using Moq;
using UT.Domain.Interfaces;

namespace UT.Presentation.Web.Tests.Controllers
{
    public class MockFinancialInformationControllerContext : FinancialInformationControllerContext
    {
        public MockFinancialInformationControllerContext()
        {
            MockFinancialInstitutionsRepository = new Mock<IFinancialInstitutionsRepository>();
            MockSitecoreContext = new MockSitecoreContext();
            MockSession = new Mock<ISessionStorage>();

            SitecoreContext = MockSitecoreContext.MockISitecoreContext.Object;
            FinancialInstitutionsRepository = MockFinancialInstitutionsRepository.Object;
            Session = MockSession.Object;
        }

        public Mock<IFinancialInstitutionsRepository> MockFinancialInstitutionsRepository { get; set; }
        public MockSitecoreContext MockSitecoreContext { get; set; }
        public Mock<ISessionStorage> MockSession { get; set; }

    }
}

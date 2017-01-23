using System.Globalization;
using Sitecore.Mvc.Helpers;
using Sitecore.Mvc.Presentation;
using UT.Presentation.Web.Models;
using Moq;

namespace UT.Presentation.Web.Tests.Helpers
{
    public class MockSitecoreContext
    {
        public MockSitecoreContext()
        {
            var htmlHelper = WebTestHelpers.CreateHtmlHelper();
            MockISitecoreContext = new Mock<ISitecoreContext>();
            MockRendering = new Mock<Rendering>();
            MockSitecoreHelper = new Mock<SitecoreHelper>(htmlHelper);

            MockISitecoreContext
                .Setup(x => x.RenderingContext.Rendering)
                .Returns(MockRendering.Object);
            MockISitecoreContext
                .Setup(x => x.SitecoreHelper)
                .Returns(MockSitecoreHelper.Object);
            MockISitecoreContext
                .Setup(x => x.GetCulture())
                .Returns(new CultureInfo("en"));
            MockISitecoreContext
                .Setup(x => x.GetDatabaseName())
                .Returns("master");
            MockISitecoreContext
                .Setup(x => x.GetLanguageName())
                .Returns("en");
        }

        public Mock<ISitecoreContext> MockISitecoreContext { get; private set; }
        public Mock<Rendering> MockRendering { get; private set; }
        public Mock<SitecoreHelper> MockSitecoreHelper { get; private set; }
    }
}

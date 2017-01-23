using System.Collections;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace UT.Presentation.Web.Tests.Helpers
{
    public static class WebTestHelpers
    {
        public static HtmlHelper CreateHtmlHelper()
        {
            return CreateHtmlHelper(new ViewDataDictionary());
        }

        public static HtmlHelper<TModel> CreateHtmlHelper<TModel>(TModel inputDictionary)
        {
            var viewData = new ViewDataDictionary<TModel>(inputDictionary);
            var mockViewContext = new Mock<ViewContext> { CallBase = true };
            mockViewContext.Setup(c => c.ViewData).Returns(viewData);
            mockViewContext.Setup(c => c.HttpContext.Items).Returns(new Hashtable());

            return new HtmlHelper<TModel>(mockViewContext.Object, CreateViewDataContainer(viewData));
        }

        public static IViewDataContainer CreateViewDataContainer(ViewDataDictionary viewData)
        {
            var mockContainer = new Mock<IViewDataContainer>();
            mockContainer.Setup(c => c.ViewData).Returns(viewData);
            return mockContainer.Object;
        }

        public static HtmlHelper CreateHtmlHelper(ViewDataDictionary vd)
        {
            var mockViewContext = new Mock<ViewContext>(
              CreateControllerContext(),
              new Mock<IView>().Object,
              vd,
              new TempDataDictionary(),
              new Mock<TextWriter>().Object);

            var mockViewDataContainer = new Mock<IViewDataContainer>();
            mockViewDataContainer.Setup(v => v.ViewData).Returns(vd);

            return new HtmlHelper(mockViewContext.Object, mockViewDataContainer.Object);
        }

        public static ControllerContext CreateControllerContext()
        {
            return CreateControllerContext(new Mock<HttpContextBase>().Object);
        }

        public static ControllerContext CreateControllerContext(HttpContextBase httpContext)
        {
            return new ControllerContext(httpContext, new RouteData(), new TestController());
        }

        public static ControllerContext CreateControllerContext(HttpContextBase httpContext, ControllerBase controller)
        {
            return new ControllerContext(httpContext, new RouteData(), controller);
        }
    }
}

using System;
using System.Globalization;
using Sitecore.Mvc.Helpers;
using Sitecore.Mvc.Presentation;

namespace UT.Presentation.Web.Models
{
    public class DefaultSitecoreContext: ISitecoreContext
    {

        public SitecoreHelper SitecoreHelper
        {
            get
            {
                var htmlHelper = RenderingContext.PageContext.HtmlHelper;
                return new SitecoreHelper(htmlHelper);
            }
        }

        public RenderingContext RenderingContext
        {
            get { return RenderingContext.Current; }
        }


        public string GetDatabaseName()
        {
            return Sitecore.Context.Database.Name;
        }
        public string GetLanguageName()
        {
            return Sitecore.Context.Language.Name;
        }
        public CultureInfo GetCulture()
        {
            return Sitecore.Context.Culture;
        }

        public string GetItemUrl(Guid itemId)
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Globalization;
using Sitecore.Mvc.Helpers;
using Sitecore.Mvc.Presentation;

namespace UT.Presentation.Web.Models
{
    public interface ISitecoreContext
    {
        RenderingContext RenderingContext { get; }
        SitecoreHelper SitecoreHelper { get; }
        string GetItemUrl(Guid itemId);
        string GetDatabaseName();
        string GetLanguageName();
        CultureInfo GetCulture();
    }
}
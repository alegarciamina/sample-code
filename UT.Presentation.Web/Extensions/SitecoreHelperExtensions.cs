using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Mvc.Presentation;
using System.Web;

namespace UT.Presentation.Web.Extensions
{
    public static class SitecoreHelperExtensions
    {
        public static HtmlString DynamicPlaceholder(this Sitecore.Mvc.Helpers.SitecoreHelper helper, string dynamicKey)
        {
            var currentRenderingId = RenderingContext.Current.Rendering.UniqueId;
            return helper.Placeholder(string.Format("{0}_{1}", dynamicKey, currentRenderingId));
        }

        public static HtmlString LazyImage(this Sitecore.Mvc.Helpers.SitecoreHelper helper, string fieldName, bool isPageNormal)
        {
            if (!isPageNormal || helper.CurrentItem == null)
                return helper.Field(fieldName);
            return CreateLazyImage(helper, fieldName);
        }

        public static HtmlString OptionalField(this Sitecore.Mvc.Helpers.SitecoreHelper helper, string fieldName, string defaultFieldName, Item item = null)
        {
            item = item ?? helper.CurrentItem;
            if (string.IsNullOrWhiteSpace(item[fieldName]))
                return helper.Field(defaultFieldName, item);
            return helper.Field(fieldName, item);
        }

        private static HtmlString CreateLazyImage(Sitecore.Mvc.Helpers.SitecoreHelper helper, string fieldName)
        {
            ImageField imageField = helper.CurrentItem.Fields[fieldName];
            if (imageField != null && imageField.MediaItem != null)
            {
                MediaItem image = new MediaItem(imageField.MediaItem);
                string imageURL = Sitecore.StringUtil.EnsurePrefix('/',
                    Sitecore.Resources.Media.MediaManager.GetMediaUrl(image));
                string img = "<img src=\"/images/lazy.jpg\" data-src=\"{0}\" class=\"lazy\" />";

                return new HtmlString(string.Format(img, imageURL));
            }
            return helper.Field(fieldName);
        }
    }
}
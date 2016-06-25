
using System.Web.Mvc;

namespace MvsPL.Infrastructure
{
    public static class CustomHtmlHelpers
    {
        public static MvcHtmlString Submit(this HtmlHelper html, string buttonText)
        {
            TagBuilder tag = new TagBuilder("input");
            tag.MergeAttribute("type","submit");
            tag.MergeAttribute("value", buttonText);
            return new MvcHtmlString(tag.ToString(TagRenderMode.SelfClosing));
        }

        public static MvcHtmlString If(this MvcHtmlString value, bool evaluation)
        {
            return evaluation ? value : MvcHtmlString.Empty;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SpendThriftWebsite.Infrastructure
{
    public static class MyHelpers
    {
        public static MvcHtmlString Image(this HtmlHelper helper, string src, string alt)
        {
            var newSource = "/" + src;
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", newSource);
            builder.MergeAttribute("alt", alt);
            return new MvcHtmlString(builder.ToString(TagRenderMode.SelfClosing));
        }
    }
}
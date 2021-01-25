using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.CustomTag
{
    [HtmlTargetElement(Attributes = "background-color")]
    public class CustomTag
    {
        public static string img(string Source, string Alt, string Title, int Height = 900, int Width = 720)
        {
            return string.Format("<img src='{0}' alt='{1}' title='{2}' height='{3}' width='{4}'/>", Source, Alt, Title, Height, Width);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OdeToFood.CustomTag
{
    public static class CustomLabel
    {
        public static IHtmlString Create(string Content)
        {
            string LableStr = $"<label style=\"background-color:black;color:white;font-size:24px\">{Content}</label>";
            return new HtmlString(LableStr);
        }
    }
}
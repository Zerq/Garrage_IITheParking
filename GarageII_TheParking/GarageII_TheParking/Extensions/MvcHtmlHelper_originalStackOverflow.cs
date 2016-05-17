using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace GarageII_TheParking.Extensions
{
    //public class MvcHtmlHelper_originalStackOverflow
    ////http://stackoverflow.com/questions/14351305/custom-htmlhelper-method-that-generates-an-input-type-range-htmlstring
    //{
    //    public static class MvcHtmlHelper
    //    {
    //        public static HtmlString RangeFor<TModel, TProperty>
    //        (this HtmlHelper<TModel> htmlHelper,
    //            Expression<Func<TModel, TProperty>> expression,
    //            object htmlAttributes)
    //        {
    //            var name = ExpressionHelper.GetExpressionText(expression);
    //            var metadata = ModelMetadata.FromLambdaExpression(expression,
    //                           htmlHelper.ViewData);
    //            //var min = (string)((ViewDataDictionary<TModel>)htmlAttributes)["min"];
    //            //var max = (string)((ViewDataDictionary<TModel>)htmlAttributes)["max"];
    //            //var value = (string)((ViewDataDictionary<TModel>)htmlAttributes)["value"];
    //            return Range(htmlHelper, min, max, value);
    //        }

    //        public static HtmlString Range(this HtmlHelper htmlHelper,
    //            string name, string min, string max, string value = "0")
    //        {
    //            var builder = new TagBuilder("input");
    //            builder.Attributes["type"] = "range";
    //            builder.Attributes["name"] = name;
    //            builder.Attributes["min"] = min;
    //            builder.Attributes["max"] = max;
    //            builder.Attributes["value"] = value;
    //            return new HtmlString(builder.ToString(TagRenderMode.SelfClosing));
    //        }
    //    }
    //}

}
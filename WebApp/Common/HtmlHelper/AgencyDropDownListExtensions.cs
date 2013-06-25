using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using AR2AP.Service;

namespace AR2AP.WebApp.Common.HtmlHelper
{
    public static class AgencyDropDownListExtensions
    {
        public static MvcHtmlString AgencyDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object defaultValue, string optionLabel, object htmlAttributes)
        {
            AgencyService service = new AgencyService();
            var list = service.GetEntities().ToSelectListBy("AgencyID", o => o.AgencyName);
            return DropDownListExtensions.DropDownListFor(htmlHelper, expression, defaultValue, list, optionLabel, htmlAttributes);
        }
    }
}
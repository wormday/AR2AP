using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using AR2AP.Service;

namespace AR2AP.WebApp.Common.HtmlHelper
{
    public static class TeamDropDownListExtensions
    {
        public static MvcHtmlString TeamDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object defaultValue, string optionLabel, object htmlAttributes)
        {
            TeamService service = new TeamService();
            var list = service.GetEntities().ToSelectListBy("TeamID", o => o.Market+o.Depart);
            return DropDownListExtensions.DropDownListFor(htmlHelper, expression, defaultValue, list, optionLabel, htmlAttributes);
        }
    }
}
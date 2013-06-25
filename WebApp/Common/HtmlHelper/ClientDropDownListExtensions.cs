using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using AR2AP.Service;

namespace AR2AP.WebApp.Common.HtmlHelper
{
    public static class ClientDropDownListExtensions
    {
        public static MvcHtmlString ClientDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object defaultValue, string optionLabel, object htmlAttributes)
        {
            ClientService service = new ClientService();
            var list = service.GetEntities().ToSelectListBy("ClientID", o => o.ClientName+o.ClientGroup);
            return DropDownListExtensions.DropDownListFor(htmlHelper, expression, defaultValue, list, optionLabel, htmlAttributes);
        }
    }
}
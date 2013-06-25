using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace AR2AP.WebApp.Common.HtmlHelper
{
    public static class DropDownListExtensions
    {
        static string MvcResources_HtmlHelper_MissingSelectData = "Missing Select Data";
        static string MvcResources_HtmlHelper_WrongSelectDataType = "Wrong Select Data Type";
        static string MvcResources_Common_NullOrEmpty = "Null Or Empty";

        #region DropDownListFor
        public static MvcHtmlString DropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
           Expression<Func<TModel, TProperty>> expression, object defaultValue, IEnumerable<SelectListItem> selectList, string optionLabel, object htmlAttributes)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            string name = ExpressionHelper.GetExpressionText(expression);
            IDictionary<string, object> attributes = ConvertTo(htmlAttributes);
            return SelectInternal(htmlHelper, optionLabel, name, selectList, defaultValue, false, attributes);
        }
        #endregion

        #region 内部方法
        private static IEnumerable<SelectListItem> GetSelectData(this System.Web.Mvc.HtmlHelper htmlHelper, string name)
        {
            object o = null;
            if (htmlHelper.ViewData != null)
            {
                o = htmlHelper.ViewData.Eval(name);
            }
            if (o == null)
            {
                throw new InvalidOperationException(
                    String.Format(
                        CultureInfo.CurrentCulture,
                        MvcResources_HtmlHelper_MissingSelectData,
                        name,
                        "IEnumerable<SelectListItem>"));
            }
            IEnumerable<SelectListItem> selectList = o as IEnumerable<SelectListItem>;
            if (selectList == null)
            {
                throw new InvalidOperationException(
                    String.Format(
                        CultureInfo.CurrentCulture,
                        MvcResources_HtmlHelper_WrongSelectDataType,
                        name,
                        o.GetType().FullName,
                        "IEnumerable<SelectListItem>"));
            }
            return selectList;
        }

        private static object GetModelStateValue(System.Web.Mvc.HtmlHelper htmlHelper, string key, Type destinationType)
        {
            ModelState modelState;
            if (htmlHelper.ViewContext.ViewData.ModelState.TryGetValue(key, out modelState))
            {
                if (modelState.Value != null)
                {
                    return modelState.Value.ConvertTo(destinationType, null /* culture */);
                }
            }
            return null;
        }

        private static string ListItemToOption(SelectListItem item)
        {
            TagBuilder builder = new TagBuilder("option")
            {
                InnerHtml = HttpUtility.HtmlEncode(item.Text)
            };
            if (item.Value != null)
            {
                builder.Attributes["value"] = item.Value;
            }
            if (item.Selected)
            {
                builder.Attributes["selected"] = "selected";
            }
            return builder.ToString(TagRenderMode.Normal);
        }

        private static MvcHtmlString SelectInternal(this System.Web.Mvc.HtmlHelper htmlHelper, string optionLabel, string name, IEnumerable<SelectListItem> selectList, object selectedValue, bool allowMultiple, IDictionary<string, object> htmlAttributes)
        {
            string fullName = htmlHelper.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);
            if (String.IsNullOrEmpty(fullName))
            {
                throw new ArgumentException(MvcResources_Common_NullOrEmpty, "name");
            }

            bool usedViewData = false;

            if (selectList == null)
            {
                selectList = htmlHelper.GetSelectData(fullName);
                usedViewData = true;
            }


            object defaultValue = selectedValue != null ? selectedValue : (allowMultiple) ? GetModelStateValue(htmlHelper, fullName, typeof(string[])) : GetModelStateValue(htmlHelper, fullName, typeof(string));

            if (!usedViewData)
            {
                if (defaultValue == null)
                {
                    defaultValue = htmlHelper.ViewData.Eval(fullName);
                }
            }

            if (defaultValue != null)
            {
                IEnumerable defaultValues = (allowMultiple) ? defaultValue as IEnumerable : new[] { defaultValue };
                IEnumerable<string> values = from object value in defaultValues select Convert.ToString(value, CultureInfo.CurrentCulture);
                HashSet<string> selectedValues = new HashSet<string>(values, StringComparer.OrdinalIgnoreCase);
                List<SelectListItem> newSelectList = new List<SelectListItem>();

                foreach (SelectListItem item in selectList)
                {
                    item.Selected = (item.Value != null) ? selectedValues.Contains(item.Value) : selectedValues.Contains(item.Text);
                    newSelectList.Add(item);
                }
                selectList = newSelectList;
            }

            StringBuilder listItemBuilder = new StringBuilder();

            if (optionLabel != null)
            {
                listItemBuilder.AppendLine(ListItemToOption(new SelectListItem() { Text = optionLabel, Value = String.Empty, Selected = false }));
            }

            foreach (SelectListItem item in selectList)
            {
                listItemBuilder.AppendLine(ListItemToOption(item));
            }

            TagBuilder tagBuilder = new TagBuilder("select")
            {
                InnerHtml = listItemBuilder.ToString()
            };
            tagBuilder.MergeAttributes(htmlAttributes);
            tagBuilder.MergeAttribute("name", fullName, true /* replaceExisting */);
            tagBuilder.GenerateId(fullName);

            if (allowMultiple)
            {
                tagBuilder.MergeAttribute("multiple", "multiple");
            }

            ModelState modelState;
            if (htmlHelper.ViewData.ModelState.TryGetValue(fullName, out modelState))
            {
                if (modelState.Errors.Count > 0)
                {
                    tagBuilder.AddCssClass(System.Web.Mvc.HtmlHelper.ValidationInputCssClassName);
                }
            }

            tagBuilder.MergeAttributes(htmlHelper.GetUnobtrusiveValidationAttributes(name));

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }
        #endregion

        #region IDictionary转换
        private static IDictionary<string, object> ConvertTo(object htmlAttributes)
        {
            IDictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (System.ComponentModel.PropertyDescriptor propertyDescriptor in System.ComponentModel.TypeDescriptor.GetProperties(htmlAttributes))
            {
                dictionary.Add(propertyDescriptor.Name.Replace('_', '-'), propertyDescriptor.GetValue(htmlAttributes));
            }
            return dictionary;
        }
        #endregion


        public static SelectList ToSelectListBy<T>(this IEnumerable<T> dataList, string valueName, string textName)
        {
            if (dataList == null || dataList.Count() <= 0)
            {
                return null;
            }
            SelectList list = new SelectList(dataList);
            SelectList rtnList = new SelectList(dataList.AsEnumerable(), valueName, textName);
            return rtnList;
        }
        public static IEnumerable<SelectListItem> ToSelectListBy<T>(this IEnumerable<T> dataList, string valueName, Func<T, string> textFunc)
        {
            if (dataList == null || dataList.Count() <= 0)
            {
                return null;
            }
            ICollection<SelectListItem> rtnCollection = new List<SelectListItem>();
            foreach (var data in dataList)
            {
                SelectListItem selectListItem = new SelectListItem();
                selectListItem.Value = data.GetType().GetProperty(valueName).GetValue(data,null).ToString();
                selectListItem.Text = textFunc(data);
                rtnCollection.Add(selectListItem);
            }
            return rtnCollection;
        }

    }
}
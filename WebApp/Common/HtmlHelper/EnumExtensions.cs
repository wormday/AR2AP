using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Reflection;

namespace AR2AP.WebApp.Common.HtmlHelper
{
    public static class EnumExtensions
    {
        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TEnum defaultValue)
        {
            return EnumDropDownListFor<TModel, TProperty, TEnum>(htmlHelper, expression, defaultValue, null, null);
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TEnum defaultValue, string optionLabel)
        {
            return EnumDropDownListFor<TModel, TProperty, TEnum>(htmlHelper, expression, defaultValue, optionLabel, null);
        }

        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, TEnum defaultValue, string optionLabel, object htmlAttributes)
        {
            var list = GetSelectItemsFromEnum(typeof(TEnum));
            dynamic defautlVal = defaultValue;
            return DropDownListExtensions.DropDownListFor(htmlHelper, expression, (int?)defautlVal, list, optionLabel, htmlAttributes);
        }
        public static MvcHtmlString EnumDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, Type enumType, string optionLabel, object htmlAttributes)
        {
            var list = GetSelectItemsFromEnum(enumType);
            return DropDownListExtensions.DropDownListFor(htmlHelper, expression, null, list, optionLabel, htmlAttributes);
        }
        public static IEnumerable<SelectListItem> GetSelectItemsFromEnum(Type type)
        {
            if (type == null)
                throw new ArgumentNullException("type");
            FieldInfo[] list = null;
            Type enumType = null;
            if (type.IsEnum)
            {
                list = type.GetFields();
                enumType = type;
            }
            else if (type.GenericTypeArguments[0].IsEnum)
            {
                list=type.GenericTypeArguments[0].GetFields();
                enumType = type.GenericTypeArguments[0];
            }
            else
            {
                throw new ArgumentException("参数只能为枚举类型", "type");
            }
            foreach (FieldInfo data in list)
            {
                if (data.FieldType.UnderlyingSystemType.BaseType == typeof(System.Enum))
                {
                    Int32 EnumValue = Convert.ToInt32(Enum.Parse(enumType, data.Name));
                    yield return new SelectListItem() { Text = data.Name, Value = EnumValue.ToString() };
                }
            }
        }
        //添加东西
        public static IEnumerable<SelectListItem> GetListEnumWrap<PhoneCallTypeEnum>()
        {
            var items = new List<SelectListItem>();
            if (typeof(PhoneCallTypeEnum).IsEnum)
            {
                foreach (var value in Enum.GetValues(typeof(PhoneCallTypeEnum)).Cast<int>())
                {
                    var name = Enum.GetName(typeof(PhoneCallTypeEnum), value);
                    name = string.Format("{0}", name);
                    items.Add(new SelectListItem() { Value = value.ToString(), Text = name });
                }
            }
            return items;
        }
    }
}
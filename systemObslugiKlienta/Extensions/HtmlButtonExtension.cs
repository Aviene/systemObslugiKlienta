using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;

namespace systemObslugiKlienta.Extensions
{
    public static class HtmlButtonExtension
    {

        public static MvcHtmlString Button(this HtmlHelper helper, object innerHtml, object htmlAttributes)
        {
            return helper.Button(innerHtml, HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));
        }

        public static MvcHtmlString Button(this HtmlHelper helper, object innerHtml, IDictionary<string, object> htmlAttributes)
        {
            var builder = new TagBuilder("button") { InnerHtml = innerHtml.ToString() };
            builder.MergeAttributes(htmlAttributes);
            return MvcHtmlString.Create(builder.ToString());
        }

        public static MvcHtmlString ButtonFor<TModel, TField>(this HtmlHelper<TModel> html,
                                                            Expression<Func<TModel, TField>> property,
                                                            object innerHtml,
                                                            object htmlAttributes)
        {
            // lazily based on TextAreaFor

            var attrs = HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes);

            var name = ExpressionHelper.GetExpressionText(property);
            var metadata = ModelMetadata.FromLambdaExpression(property, html.ViewData);

            string fullName = html.ViewContext.ViewData.TemplateInfo.GetFullHtmlFieldName(name);

            ModelState modelState;
            if (html.ViewData.ModelState.TryGetValue(fullName, out modelState) && modelState.Errors.Count > 0)
            {
                if (!attrs.ContainsKey("class")) attrs["class"] = string.Empty;
                attrs["class"] += " " + HtmlHelper.ValidationInputCssClassName;
                attrs["class"] = attrs["class"].ToString().Trim();
            }
            var validation = html.GetUnobtrusiveValidationAttributes(name, metadata);
            if (null != validation) foreach (var v in validation) attrs.Add(v.Key, v.Value);

            string value;
            if (modelState != null && modelState.Value != null)
            {
                value = modelState.Value.AttemptedValue;
            }
            else if (metadata.Model != null)
            {
                value = metadata.Model.ToString();
            }
            else
            {
                value = String.Empty;
            }

            attrs["name"] = name;
            attrs["Value"] = value;
            return html.Button(innerHtml, attrs);
        }
    }
}
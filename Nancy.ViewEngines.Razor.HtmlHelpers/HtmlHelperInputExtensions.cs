using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq.Expressions;
using System.Linq;
using Nancy.Validation;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
	public static class HtmlHelperInputExtensions
    {
        public static IHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
			return TextBox(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), null, true);
        }

		public static IHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool writeOutErrorLabels = false)
		{
			return TextBox(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), htmlAttributes, writeOutErrorLabels);
		}

        public static IHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
			return TextBox(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), TypeHelper.ObjectToDictionary(htmlAttributes), true);
        }

		public static IHtmlString TextBox<TModel>(this HtmlHelpers<TModel> helper, string name, bool writeOutErrorLabels)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

			return BuildInputField(helper.RenderContext.Context.ModelValidationResult, name, InputType.Text, null, false, null, true);
        }

        public static IHtmlString TextBox<TModel>(this HtmlHelpers<TModel> helper, string name, object value)
        {
			return TextBox(helper, name, value, null, true);
        }

		public static IHtmlString TextBox<TModel>(this HtmlHelpers<TModel> helper, string name, object value, object htmlAttributes, bool writeOutErrorLabels)
        {
			return TextBox(helper, name, value, TypeHelper.ObjectToDictionary(htmlAttributes), writeOutErrorLabels);
        }

		public static IHtmlString TextBox<TModel>(this HtmlHelpers<TModel> helper, string name, object value, IDictionary<string, object> htmlAttributes, bool writeOutErrorLabels)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

			return BuildInputField(helper.RenderContext.Context.ModelValidationResult, name, InputType.Text, value, true, htmlAttributes, writeOutErrorLabels);
        }

        public static IHtmlString HiddenFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            return Hidden(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), null);
        }

        public static IHtmlString HiddenFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            return Hidden(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), htmlAttributes);
        }

        public static IHtmlString HiddenFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            return Hidden(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), TypeHelper.ObjectToDictionary(htmlAttributes));
        }

		public static IHtmlString Hidden<TModel>(this HtmlHelpers<TModel> helper, string name, bool writeOutErrorLabels)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

			return BuildInputField(helper.RenderContext.Context.ModelValidationResult, name, InputType.Hidden, null, false, null, writeOutErrorLabels);
        }

        public static IHtmlString Hidden<TModel>(this HtmlHelpers<TModel> helper, string name, object value)
        {
            return Hidden(helper, name, value, null);
        }

        public static IHtmlString Hidden<TModel>(this HtmlHelpers<TModel> helper, string name, object value, object htmlAttributes)
        {
            return Hidden(helper, name, value, TypeHelper.ObjectToDictionary(htmlAttributes));
        }

		public static IHtmlString Hidden<TModel>(this HtmlHelpers<TModel> helper, string name, object value, IDictionary<string, object> htmlAttributes, bool writeOutErrorLabels)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

			return BuildInputField(helper.RenderContext.Context.ModelValidationResult, name, InputType.Hidden, GetHiddenFieldValue(value), true, htmlAttributes, writeOutErrorLabels);
        }

        private static object GetHiddenFieldValue(object value)
        {
            var binaryValue = value as Binary;
            if (binaryValue != null)
            {
                value = binaryValue.ToArray();
            }

            var byteArrayValue = value as byte[];
            if (byteArrayValue != null)
            {
                value = Convert.ToBase64String(byteArrayValue);
            }

            return value;
        }

		public static IHtmlString PasswordFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, bool writeOutErrorLabels = false)
        {
			return Password(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), null, writeOutErrorLabels);
        }

		public static IHtmlString PasswordFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes, bool writeOutErrorLabels = false)
        {
			return Password(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), htmlAttributes, writeOutErrorLabels);
        }

		public static IHtmlString PasswordFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes, bool writeOutErrorLabels)
        {
            return Password(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), TypeHelper.ObjectToDictionary(htmlAttributes), writeOutErrorLabels);
        }

        public static IHtmlString Password<TModel>(this HtmlHelpers<TModel> helper, string name, bool writeOutErrorLabels)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

			return BuildInputField(helper.RenderContext.Context.ModelValidationResult, name, InputType.Password, null, false, null, writeOutErrorLabels);
        }

		public static IHtmlString Password<TModel>(this HtmlHelpers<TModel> helper, string name, object value, bool writeOutErrorLabels)
        {
			return Password(helper, name, value, null, writeOutErrorLabels);
        }

		public static IHtmlString Password<TModel>(this HtmlHelpers<TModel> helper, string name, object value, object htmlAttributes, bool writeOutErrorLabels)
        {
			return Password(helper, name, value, TypeHelper.ObjectToDictionary(htmlAttributes), writeOutErrorLabels);
        }

		public static IHtmlString Password<TModel>(this HtmlHelpers<TModel> helper, string name, object value, IDictionary<string, object> htmlAttributes, bool writeOutErrorLabels)
        {
            if (String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
            }

			return BuildInputField(helper.RenderContext.Context.ModelValidationResult, name, InputType.Password, value, true, htmlAttributes, writeOutErrorLabels);
        }

        private static IHtmlString BuildInputField(ModelValidationResult modelValidationResult, string name, InputType type, object value, bool isExplicitValue, IDictionary<string, object> attributes,  bool writeOutErrorLabel
            )
        {
            var inputTag = new TagBuilder("input");
            // Implicit parameters
            inputTag.MergeAttribute("type", GetInputTypeString(type));
            inputTag.GenerateId(name);

            // Overwrite implicit
            inputTag.MergeAttributes(attributes, true);

			TagBuilder validationLabel = null;
			if (writeOutErrorLabel || !modelValidationResult.IsValid)
			{
				validationLabel = new TagBuilder("label");
				validationLabel.Attributes.Add("for", name);

				// Todo: consider multiple values of Value
				if (modelValidationResult.Errors.Any(e => e.Key == name))
				{
					inputTag.AddCssClass(HtmlHelperExtensions.ErrorClass);
					var error = modelValidationResult.Errors.First(e => e.Key == name).Value;
					validationLabel.InnerHtml = error.First();
				}
			}

            //if (UnobtrusiveJavaScriptEnabled)
            //{
            //    // Add validation attributes
            //    var validationAttributes = _validationHelper.GetUnobtrusiveValidationAttributes(name);
            //    tagBuilder.MergeAttributes(validationAttributes, replaceExisting: false);
            //}

            // Function arguments
            inputTag.MergeAttribute("name", name, true);
            //var modelState = ModelState[name];
            //if ((type != InputType.Password) && modelState != null)
            {
                // Don't use model values for passwords
                value = value; //?? modelState.Value ?? String.Empty;
            }

            if ((type != InputType.Password) || ((type == InputType.Password) && (value != null)))
            {
                // Review: Do we really need to be this pedantic about sticking to mvc?
				inputTag.MergeAttribute("value", Convert.ToString(value), isExplicitValue);
            }
        
			//AddErrorClass(tagBuilder, name);
			var tag = inputTag.ToHtmlString(TagRenderMode.SelfClosing);
			if (validationLabel != null)
			{
				tag += validationLabel.ToHtmlString(TagRenderMode.Normal);
			}

			return tag;
		}

        private static string GetInputTypeString(InputType inputType)
        {
            if (!Enum.IsDefined(typeof(InputType), inputType))
            {
                inputType = InputType.Text;
            }
            return inputType.ToString().ToLowerInvariant();
        }
    }
}
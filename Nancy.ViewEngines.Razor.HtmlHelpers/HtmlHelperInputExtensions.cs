﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq.Expressions;
using Nancy.Validation;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
	public static class HtmlHelperInputExtensions
	{
		public static IHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression)
		{
			return TextBox(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), null);
		}

		public static IHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
		{
			return TextBox(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), htmlAttributes);
		}

		public static IHtmlString TextBoxFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			return TextBox(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), TypeHelper.ObjectToDictionary(htmlAttributes));
		}

		public static IHtmlString TextBox<TModel>(this HtmlHelpers<TModel> helper, string name)
		{
			if (String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
			}

			return BuildInputField(helper.RenderContext.Context.ModelValidationResult, name, InputType.Text, null, false, null);
		}

		public static IHtmlString TextBox<TModel>(this HtmlHelpers<TModel> helper, string name, object value)
		{
			return TextBox(helper, name, value, null);
		}

		public static IHtmlString TextBox<TModel>(this HtmlHelpers<TModel> helper, string name, object value, object htmlAttributes)
		{
			return TextBox(helper, name, value, TypeHelper.ObjectToDictionary(htmlAttributes));
		}

		public static IHtmlString TextBox<TModel>(this HtmlHelpers<TModel> helper, string name, object value, IDictionary<string, object> htmlAttributes)
		{
			if (String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
			}

			return BuildInputField(helper.RenderContext.Context.ModelValidationResult, name, InputType.Text, value, true, htmlAttributes);
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

		public static IHtmlString Hidden<TModel>(this HtmlHelpers<TModel> helper, string name)
		{
			if (String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
			}

			return BuildInputField(helper.RenderContext.Context.ModelValidationResult, name, InputType.Hidden, null, false, null);
		}

		public static IHtmlString Hidden<TModel>(this HtmlHelpers<TModel> helper, string name, object value)
		{
			return Hidden(helper, name, value, null);
		}

		public static IHtmlString Hidden<TModel>(this HtmlHelpers<TModel> helper, string name, object value, object htmlAttributes)
		{
			return Hidden(helper, name, value, TypeHelper.ObjectToDictionary(htmlAttributes));
		}

		public static IHtmlString Hidden<TModel>(this HtmlHelpers<TModel> helper, string name, object value, IDictionary<string, object> htmlAttributes)
		{
			if (String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
			}

			return BuildInputField(helper.RenderContext.Context.ModelValidationResult, name, InputType.Hidden, GetHiddenFieldValue(value), true, htmlAttributes);
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

		public static IHtmlString PasswordFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression)
		{
			return Password(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), null);
		}

		public static IHtmlString PasswordFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
		{
			return Password(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), htmlAttributes);
		}

		public static IHtmlString PasswordFor<TModel, TProperty>(this HtmlHelpers<TModel> helper, Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
		{
			return Password(helper, ExpressionHelper.GetExpressionText(expression), expression.Compile()(helper.Model), TypeHelper.ObjectToDictionary(htmlAttributes));
		}

		public static IHtmlString Password<TModel>(this HtmlHelpers<TModel> helper, string name)
		{
			if (String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
			}

			return BuildInputField(helper.RenderContext.Context.ModelValidationResult, name, InputType.Password, null, false, null);
		}

		public static IHtmlString Password<TModel>(this HtmlHelpers<TModel> helper, string name, object value)
		{
			return Password(helper, name, value, null);
		}

		public static IHtmlString Password<TModel>(this HtmlHelpers<TModel> helper, string name, object value, object htmlAttributes)
		{
			return Password(helper, name, value, TypeHelper.ObjectToDictionary(htmlAttributes));
		}

		public static IHtmlString Password<TModel>(this HtmlHelpers<TModel> helper, string name, object value, IDictionary<string, object> htmlAttributes)
		{
			if (String.IsNullOrEmpty(name))
			{
				throw new ArgumentException("Argument_Cannot_Be_Null_Or_Empty", "name");
			}

			return BuildInputField(helper.RenderContext.Context.ModelValidationResult, name, InputType.Password, value, true, htmlAttributes);
		}

		private static IHtmlString BuildInputField(ModelValidationResult modelValidationResult, string name, InputType type, object value, bool isExplicitValue, IDictionary<string, object> attributes)
		{
			var inputTag = new TagBuilder("input");
			// Implicit parameters
			inputTag.MergeAttribute("type", GetInputTypeString(type));
			inputTag.GenerateId(name);

			// Overwrite implicit
			inputTag.MergeAttributes(attributes);

			//if (UnobtrusiveJavaScriptEnabled)
			//{
			//    // Add validation attributes
			//    var validationAttributes = _validationHelper.GetUnobtrusiveValidationAttributes(name);
			//    tagBuilder.MergeAttributes(validationAttributes, replaceExisting: false);
			//}

			// Function arguments
			inputTag.MergeAttribute("name", name);
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
			var input = inputTag.ToHtmlString(TagRenderMode.SelfClosing);

			if (!modelValidationResult.IsValid && modelValidationResult.HasErrors(name))
			{
				inputTag.AddCssClass(HtmlHelperExtensions.ErrorClass);
				inputTag.MergeAttribute("style", "margin-bottom: 0");

				var validationLabel = HtmlHelperExtensions.CreateValidationLabel(modelValidationResult, name, inputTag);

				input = inputTag.ToHtmlString(TagRenderMode.SelfClosing) + validationLabel.ToHtmlString(TagRenderMode.Normal);
			}

			return input;
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
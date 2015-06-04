using System.Linq;
using System.Text;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
	using System.Diagnostics.Contracts;

	public static class HtmlHelperExtensions
	{
		private static string _errorClass;

		public static string ErrorClass
		{
			get { return _errorClass ?? (_errorClass = "error"); }
			set { _errorClass = value; }
		}

		internal static bool HasErrors(this Validation.ModelValidationResult modelValidationResult, string name)
		{
			Contract.Requires(modelValidationResult != null);
			Contract.Requires(!string.IsNullOrWhiteSpace(name));

			var hasErrors = modelValidationResult.Errors
				.Where(e => e.Key == name)
				.Select(mvr => mvr.Value)
				.SelectMany(mvr => mvr)
				.Where(mvr => mvr.MemberNames.Any(mn => mn == name))
				.Distinct()
				.Any();

			return hasErrors;
		}

		internal static TagBuilder CreateValidationLabel(Validation.ModelValidationResult modelValidationResult, string name, TagBuilder formElementTag)
		{
			Contract.Requires(modelValidationResult != null);
			Contract.Requires(!string.IsNullOrWhiteSpace(name));
			Contract.Requires(formElementTag != null);
			Contract.Requires(HasErrors(modelValidationResult, name));

			Contract.Ensures(Contract.Result<TagBuilder>() != null);

			var validationLabel = new TagBuilder("label");
			validationLabel.Attributes.Add("for", name);
			validationLabel.AddCssClass(ErrorClass);

			var errorMessages = modelValidationResult.Errors
				.Where(e => e.Key == name)
				.Select(mvr => mvr.Value)
				.SelectMany(mvr => mvr)
				.Where(mvr => mvr.MemberNames.Any(mn => mn == name))
				.Select(mvr => mvr.ErrorMessage)
				.Distinct()
				.ToList();

			var errors = new StringBuilder();

			foreach (var errorMessage in errorMessages)
			{
				errors.Append(errorMessage).Append("<br />");
			}

			if (errors.Length > 0)
			{
				errors.Length -= 6;
			}

			validationLabel.InnerHtml = errors.ToString();

			return validationLabel;
		}
	}
}
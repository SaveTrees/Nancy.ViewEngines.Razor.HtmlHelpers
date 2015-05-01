using System.Linq;
using System.Text;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
	public static class HtmlHelperExtensions
	{
		private static string _errorClass;

		public static string ErrorClass
		{
			get { return _errorClass ?? (_errorClass = "error"); }
			set { _errorClass = value; }
		}

		internal static TagBuilder CreateValidationLabel(Validation.ModelValidationResult modelValidationResult, string name, TagBuilder formElementTag)
		{
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

			if (errorMessages.Any())
			{
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
			}

			return validationLabel;
		}
	}
}
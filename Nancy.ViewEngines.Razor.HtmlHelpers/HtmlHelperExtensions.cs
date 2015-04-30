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
	}
}

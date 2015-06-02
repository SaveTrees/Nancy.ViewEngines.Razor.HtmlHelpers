using System;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
	/// <summary>
	/// Extensions for the <see cref="HtmlHelpers{TModel}"/> to add html form support
	/// </summary>
	public static class HtmlHelperFormExtensions
	{
		/// <summary>
		/// Creates a form with a <typeparamref name="TModel"/> backing model
		/// </summary>
		public class BeginFormObject<TModel> : IDisposable
		{
			private readonly NancyRazorViewBase<TModel> _view;

			/// <summary>
			/// Initialise the form object by writing the opening form tag
			/// </summary>
			/// <param name="tagOpen">The markup for opening the form tag</param>
			/// <param name="view">The nancy razor view into which to write the html form</param>
			public BeginFormObject(NonEncodedHtmlString tagOpen, NancyRazorViewBase<TModel> view)
			{
				_view = view;
				view.WriteLiteral(tagOpen.ToHtmlString());
			}

			/// <summary>
			/// Writes the html markup for closing the form tag
			/// </summary>
			public void Dispose()
			{
				_view.WriteLiteral("</form>");
			}
		}

		public static BeginFormObject<TModel> BeginForm<TModel>(this HtmlHelpers<TModel> helpers, NancyRazorViewBase<TModel> view, string action = null, string name = null, string id = null, string method = "POST")
		{
			var tag = GetFormTag(action, id, name, method);

			var beginFormObject = new BeginFormObject<TModel>(tag, view);
			return beginFormObject;
		}

		/// <summary>
		/// Creates a form without a backing model type
		/// </summary>
		public class BeginFormObject : BeginFormObject<dynamic>
		{
			/// <summary>
			/// Initialise the form object by writing the opening form tag
			/// </summary>
			/// <param name="tagOpen">The markup for opening the form tag</param>
			/// <param name="view">The nancy razor view into which to write the html form</param>
			public BeginFormObject(NonEncodedHtmlString tagOpen, NancyRazorViewBase view)
				: base(tagOpen, view)
			{
			}
		}

		/// <summary>
		/// Creates the html markup for the form opening tag
		/// </summary>
		/// <param name="action"></param>
		/// <param name="id">The id of the form. If <c>null</c> then no id is written</param>
		/// <param name="name">The name of the form, if <c>null</c> then it takes the values of <paramref name="id"/></param>
		/// <param name="method">The HTTP method for the form action</param>
		/// <returns>An html-formatted string representing the opening form tag markup</returns>
		private static NonEncodedHtmlString GetFormTag(string action, string id = null, string name = null, string method = "POST")
		{
			var idAttribute = id == null ? string.Empty : string.Format(" id=\"{0}\"", id);
			
			if (name == null) name = id ?? string.Empty;
			var nameAttribute = string.Format(" name=\"{0}\"", name);
			var methodAttribute = string.Format(" method=\"{0}\"", method);
			var actionAttribute = action == "" ? "" : string.Format(" action=\"{0}\"", action);

			var tag = string.Format("<form{0}{1}{2}{3}>", methodAttribute, actionAttribute, idAttribute, nameAttribute);

			return new NonEncodedHtmlString(tag);
		}
	}
}

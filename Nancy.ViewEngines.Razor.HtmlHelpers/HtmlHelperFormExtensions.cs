using System;

namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
	public static class HtmlHelperFormExtensions
	{
		public static BeginFormObject BeginForm<TModel>(this HtmlHelpers<TModel> helpers, NancyRazorViewBase view, string name = null, string id = null, string method = "POST")
		{
			var tag = GetTag(name, id, method);
			
			return new BeginFormObject(tag, view);
		}

		public static BeginFormObject<TModel> BeginForm<TModel>(this HtmlHelpers<TModel> helpers, NancyRazorViewBase<TModel> view, string route = null, string method = "POST", string name = null, string id = null)
		{
			var tag = GetTag(name, id, method);

			return new BeginFormObject<TModel>(tag, view);
		}

		public class BeginFormObject : IDisposable
		{
			private readonly NancyRazorViewBase view;

			public BeginFormObject(string markup, NancyRazorViewBase view)
			{
				this.view = view;
				view.WriteLiteral(markup);
			}

			public void Dispose()
			{
				view.WriteLiteral("</form>");
			}
		}

		public class BeginFormObject<TModel> : IDisposable
		{
			private readonly NancyRazorViewBase<TModel> view;

			public BeginFormObject(string markup, NancyRazorViewBase<TModel> view)
			{
				this.view = view;
				view.WriteLiteral(markup);
			}

			public void Dispose()
			{
				view.WriteLiteral("</form>");
			}
		}

		private static string GetTag(string name, string id, string method = "POST")
		{
			var methodAttribute = string.Format(" method=\"{0}\"", method);
			var nameAttribute = string.IsNullOrWhiteSpace(name) ? string.Empty : string.Format(" name=\"{0}\"", name);
			var idAttribute = string.IsNullOrWhiteSpace(id) ? string.Empty : string.Format(" id=\"{0}\"", id);

			var tag = string.Format("<form{0}{1}{2}>", methodAttribute, idAttribute, nameAttribute);

			return tag;
		}
	}
}

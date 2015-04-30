namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
    public class HtmlString : NonEncodedHtmlString
    {
        public HtmlString(string value) : base(value)
        {
        }

        public static HtmlString operator +(HtmlString first, HtmlString second)
        {
            return new HtmlString(first.ToHtmlString() + second.ToHtmlString());
        }
    }
}
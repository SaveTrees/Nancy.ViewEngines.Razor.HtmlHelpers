namespace Nancy.ViewEngines.Razor.HtmlHelpers
{
    /// <summary>
    /// A wrapper around the <see cref="NonEncodedHtmlString"/>
    /// </summary>
    public class HtmlString : NonEncodedHtmlString
    {
        /// <summary>
        /// Initialise a new <see cref="HtmlString"/> from a <see cref="string"/>
        /// </summary>
        /// <param name="value">The value of the string</param>
        public HtmlString(string value) : base(value)
        {
        }

        /// <summary>
        /// Concatenate two <see cref="HtmlString"/>s
        /// </summary>
        /// <param name="first">The first string</param>
        /// <param name="second">The second string</param>
        /// <returns>The <paramref name="second"/> string postpended to the <paramref name="first"/> string</returns>
        public static HtmlString operator +(HtmlString first, HtmlString second)
        {
            return new HtmlString(first.ToHtmlString() + second.ToHtmlString());
        }
    }
}
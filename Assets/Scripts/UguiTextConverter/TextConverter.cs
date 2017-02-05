namespace UguiTextConverter
{
    public class TextConverter
    {
        /// <summary>
        /// uGUIのRichText形式の文字列を、HTML文字列に変換する
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string UguiToHtml(string text)
        {
            var parser = new UguiRichTextParser.RichTextParser(text);
            return parser.ToHtmlString();
        }

        /// <summary>
        /// HTML形式の文字列を、uGUIのRichText形式の文字列に変換する
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string HtmlToUgui(string html)
        {
            var parser = new HtmlTextParser.HtmlTextParser(html);
            return parser.ToUguiRichTextString();
        }
    }
}

using HtmlAgilityPack;

namespace UguiTextConverter.HtmlTextParser
{
    public class HtmlTextParser
    {
        HtmlDocument m_Document;

        public HtmlTextParser(string text)
        {
            m_Document = new HtmlDocument();
            m_Document.LoadHtml(text);
        }

        public override string ToString()
        {
            return m_Document.DocumentNode.OuterHtml;
        }

        public string ToUguiRichTextString()
        {
            return NodeToUguiConverter.ToString(m_Document.DocumentNode.ChildNodes);
        }
    }
}

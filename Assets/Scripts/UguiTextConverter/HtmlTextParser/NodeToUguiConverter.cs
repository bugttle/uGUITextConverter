using HtmlAgilityPack;

namespace UguiTextConverter.HtmlTextParser
{
    public static class NodeToUguiConverter
    {
        public static string ToString(HtmlNodeCollection nodes)
        {
            var str = "";
            foreach (var node in nodes)
            {
                switch (node.NodeType)
                {
                    case HtmlNodeType.Element:
                        if (node.Name.ToLower() == "b".ToLower())
                        {
                            str += ToBString(node);
                        }
                        else if (node.Name.ToLower() == "i".ToLower())
                        {
                            str += ToIString(node);
                        }
                        else if (node.Name.ToLower() == "font".ToLower())
                        {
                            str += ToFontString(node);
                        }
                        else
                        {
                            if (node.HasChildNodes)
                            {
                                str += ToString(node.ChildNodes);
                            }
                        }
                        break;

                    case HtmlNodeType.Text:
                        str += node.InnerText;
                        break;

                    default:
                        break;
                }
            }
            return str;
        }

        static string ToFontString(HtmlNode node)
        {
            var startTags = "";
            var str = "";
            var endTags = "";

            var size = node.GetAttributeValue("size", null);
            var color = node.GetAttributeValue("color", null);

            // 開始タグ
            if (size != null)
            {
                startTags += "<size=" + size + ">";
            }
            if (color != null)
            {
                startTags += "<color=" + color + ">";
            }

            // コンテンツ
            if (node.HasChildNodes)
            {
                str = ToString(node.ChildNodes);
            }

            // 終了タグ
            if (color != null)
            {
                endTags += "</color>";
            }
            if (size != null)
            {
                endTags += "</size>";
            }

            return startTags + str + endTags;
        }

        static string ToBString(HtmlNode node)
        {
            return "<b>" + ToString(node.ChildNodes) + "</b>";
        }

        static string ToIString(HtmlNode node)
        {
            return "<i>" + ToString(node.ChildNodes) + "</i>";
        }
    }
}

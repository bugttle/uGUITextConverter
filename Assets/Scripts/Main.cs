using UguiTextConverter;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField]
    Text m_Text;

    private void Reset()
    {
        m_Text = transform.GetComponent<Text>();
    }

    // Use this for initialization
    void Start()
    {
        // 通常のText
        Debug.Log(m_Text.text);

        if (m_Text.supportRichText)
        {
            // RichText => Html
            var html = TextConverter.UguiToHtml(m_Text.text);
            Debug.Log(html);

            // Html => RichText
            var text = TextConverter.HtmlToUgui(html);
            Debug.Log(text);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}

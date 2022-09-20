using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatItem : MonoBehaviour
{
    //Text 
    Text chatText;
    //RectTransform
    RectTransform rt;
    void Awake()
    {
        chatText = GetComponent<Text>();
        rt = GetComponent<RectTransform>();
    }

    //Text ����, Text������ ũ�⿡ �°� �ڽ��� ContetSize�� ����
    public void SetText(string s)
    {
        chatText.text = s;
        //chatText.text �� ũ�⿡ �°� ContetSize������
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, chatText.preferredHeight);
    }
}

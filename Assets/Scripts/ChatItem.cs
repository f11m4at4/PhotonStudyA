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

    //Text 셋팅, Text내용의 크기에 맞게 자신의 ContetSize를 변경
    public void SetText(string s)
    {
        chatText.text = s;
        //chatText.text 의 크기에 맞게 ContetSize를변경
        rt.sizeDelta = new Vector2(rt.sizeDelta.x, chatText.preferredHeight);
    }
}

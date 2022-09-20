using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    //InputChat
    public InputField inputChat;
    //ChatItem 공장
    public GameObject chatItemFactory;
    //ScorllView의 Content
    public Transform trContent;
    
    void Start()
    {
        //InputField에서 엔터를 쳤을 때 호출되는 함수 등록
        inputChat.onSubmit.AddListener(OnSubmit);
    }

    void Update()
    {
        
    }

    //InputField에서 엔터를 쳤을때 호출되는 함수
    void OnSubmit(string s)
    {
        //1. ChatItem을 만든다(부모를 Scorllview의 Content)
        GameObject item = Instantiate(chatItemFactory, trContent);
        //2. 만든 ChatItem에서 ChatItem 컴포넌트 가져온다
        ChatItem chat = item.GetComponent<ChatItem>();
        //3. 가져온 컴포넌트에 s를 셋팅
        chat.SetText(s);
    }
}

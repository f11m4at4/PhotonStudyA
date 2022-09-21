using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using UnityEngine.EventSystems;

public class ChatManager : MonoBehaviourPun
{
    //InputChat
    public InputField inputChat;
    //ChatItem 공장
    public GameObject chatItemFactory;
    //ScorllView의 Content
    public RectTransform trContent;

    //내 아이디 색
    Color idColor;
    
    void Start()
    {
        //InputField에서 엔터를 쳤을 때 호출되는 함수 등록
        inputChat.onSubmit.AddListener(OnSubmit);
        //마우스 커서 비활성화
        Cursor.visible = false;
        //idColor를 랜덤하게
        idColor = new Color32(
            (byte)Random.Range(0, 256),
            (byte)Random.Range(0, 256),
            (byte)Random.Range(0, 256),
            255
        );

    }

    void Update()
    {
        //만약에 esc키를 누르면 커서 활성화
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

        //만약에 마우스 클릭을 하면 커서 비활성화
        if(Input.GetMouseButtonDown(0))
        {

            //만약에 커서가 해당 위치에 UI가 없을때
            if (EventSystem.current.IsPointerOverGameObject() == false)

            {
                Cursor.visible = false;
            }
        }
    }

    //InputField에서 엔터를 쳤을때 호출되는 함수
    void OnSubmit(string s)
    {
        //<color=#FFFFFF>닉네임</color>
        string chatText = "<color=#" + ColorUtility.ToHtmlStringRGB(idColor) + ">" + PhotonNetwork.NickName + "</color>" + " : " + s;

        photonView.RPC("RpcAddChat", RpcTarget.All, chatText);
        //4. InputChat의 내용을 초기화
        inputChat.text = "";
        //5. InputChat에 Focusing 을 해주자.
        inputChat.ActivateInputField();
    }


    //이전 Content의 H
    float prevContentH;
    //ScorllView의 RectTransform
    public RectTransform trScrollView;

    [PunRPC]
    void RpcAddChat(string chatText)
    {
        //0. 바뀌기 전의 Content H값을 넣자
        prevContentH = trContent.sizeDelta.y;

        //1. ChatItem을 만든다(부모를 Scorllview의 Content)
        GameObject item = Instantiate(chatItemFactory, trContent);
        //2. 만든 ChatItem에서 ChatItem 컴포넌트 가져온다
        ChatItem chat = item.GetComponent<ChatItem>();
        //3. 가져온 컴포넌트에 s를 셋팅
        chat.SetText(chatText);


        StartCoroutine(AutoScrollBottom());
    }

    IEnumerator AutoScrollBottom()
    {
        yield return null;

        //trScrollView H 보다 Content H 값이 커지면(스크롤 가능상태)
        if(trContent.sizeDelta.y > trScrollView.sizeDelta.y)
        {
            //4. Content가 바닥에 닿아있었다면
            if (trContent.anchoredPosition.y >= prevContentH - trScrollView.sizeDelta.y)
            {
                //5. Content의 y값을 다시 설정해주자
                trContent.anchoredPosition = new Vector2(0, trContent.sizeDelta.y - trScrollView.sizeDelta.y);
            }
        }        
    }
}

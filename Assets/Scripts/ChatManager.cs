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
    //ChatItem ����
    public GameObject chatItemFactory;
    //ScorllView�� Content
    public Transform trContent;

    //�� ���̵� ��
    Color idColor;
    
    void Start()
    {
        //InputField���� ���͸� ���� �� ȣ��Ǵ� �Լ� ���
        inputChat.onSubmit.AddListener(OnSubmit);
        //���콺 Ŀ�� ��Ȱ��ȭ
        Cursor.visible = false;
        //idColor�� �����ϰ�
        idColor = new Color32(
            (byte)Random.Range(0, 256),
            (byte)Random.Range(0, 256),
            (byte)Random.Range(0, 256),
            255
        );

    }

    void Update()
    {
        //���࿡ escŰ�� ������ Ŀ�� Ȱ��ȭ
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
        }

        //���࿡ ���콺 Ŭ���� �ϸ� Ŀ�� ��Ȱ��ȭ
        if(Input.GetMouseButtonDown(0))
        {

            //���࿡ Ŀ���� �ش� ��ġ�� UI�� ������
            if (EventSystem.current.IsPointerOverGameObject() == false)

            {
                Cursor.visible = false;
            }
        }
    }

    //InputField���� ���͸� ������ ȣ��Ǵ� �Լ�
    void OnSubmit(string s)
    {
        //<color=#FFFFFF>�г���</color>
        string chatText = "<color=#" + ColorUtility.ToHtmlStringRGB(idColor) + ">" + PhotonNetwork.NickName + "</color>" + " : " + s;

        photonView.RPC("RpcAddChat", RpcTarget.All, chatText);
        //4. InputChat�� ������ �ʱ�ȭ
        inputChat.text = "";
        //5. InputChat�� Focusing �� ������.
        inputChat.ActivateInputField();
    }

    [PunRPC]
    void RpcAddChat(string chatText)
    {
        //1. ChatItem�� �����(�θ� Scorllview�� Content)
        GameObject item = Instantiate(chatItemFactory, trContent);
        //2. ���� ChatItem���� ChatItem ������Ʈ �����´�
        ChatItem chat = item.GetComponent<ChatItem>();
        //3. ������ ������Ʈ�� s�� ����
        chat.SetText(chatText);       
    }    
}

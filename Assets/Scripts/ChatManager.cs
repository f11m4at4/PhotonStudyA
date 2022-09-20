using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    //InputChat
    public InputField inputChat;
    //ChatItem ����
    public GameObject chatItemFactory;
    //ScorllView�� Content
    public Transform trContent;
    
    void Start()
    {
        //InputField���� ���͸� ���� �� ȣ��Ǵ� �Լ� ���
        inputChat.onSubmit.AddListener(OnSubmit);
    }

    void Update()
    {
        
    }

    //InputField���� ���͸� ������ ȣ��Ǵ� �Լ�
    void OnSubmit(string s)
    {
        //1. ChatItem�� �����(�θ� Scorllview�� Content)
        GameObject item = Instantiate(chatItemFactory, trContent);
        //2. ���� ChatItem���� ChatItem ������Ʈ �����´�
        ChatItem chat = item.GetComponent<ChatItem>();
        //3. ������ ������Ʈ�� s�� ����
        chat.SetText(s);
    }
}

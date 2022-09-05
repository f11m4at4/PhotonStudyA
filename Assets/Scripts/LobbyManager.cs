using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        CreateRoom();
    }

    void Update()
    {
        
    }

    //�����
    public void CreateRoom()
    {
        //��ɼ� ����
        RoomOptions roomOptions = new RoomOptions();
               
        //�ִ��ο� (0���̸� �ִ��ο�)
        roomOptions.MaxPlayers = 10;
        //�� ��Ͽ� ���̳�? ������ �ʴ���?
        roomOptions.IsVisible = true;

        //���� �����.
        PhotonNetwork.CreateRoom("XR_A", roomOptions, TypedLobby.Default);
    }

    //�� ���� �Ϸ�
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("OnCreatedRoom");
    }

    //�� ���� ����
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("OnCreateRoomFailed, " + returnCode + ", " + message);
    }

    //������
}

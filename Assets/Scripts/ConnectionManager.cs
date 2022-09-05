using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class ConnectionManager : MonoBehaviourPunCallbacks
{
    void Start()
    {
        //NameServer ����(AppId, GameVersion, ����)
        PhotonNetwork.ConnectUsingSettings();
    }

    //������ ������ ���� ����, �κ� ���� �� ������ �� �� ���� ����
    public override void OnConnected()
    {
        base.OnConnected();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    //������ ������ ����, �κ� ���� �� ������ ����
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        //�г��� ����
        PhotonNetwork.NickName = "������_" + Random.Range(1, 10000);
        //�⺻ �κ� ����
        PhotonNetwork.JoinLobby();
        //Ư�� �κ� ����
        //PhotonNetwork.JoinLobby(new TypedLobby("������ �κ�", LobbyType.Default));
        
    }

    //�κ� ���� ������ ȣ��
    public override void OnJoinedLobby()
    {
        base.OnJoinedLobby();
        print(System.Reflection.MethodBase.GetCurrentMethod().Name);

        // LobbyScene���� �̵�
        SceneManager.LoadScene("LobbyScene");
    }

    void Update()
    {
        
    }
}

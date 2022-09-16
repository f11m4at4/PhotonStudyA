using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    //SpawnPos ��
    public Vector3[] spawnPos;

    void Start()
    {
        //OnPhotonSerializeView ȣ�� ��
        PhotonNetwork.SerializationRate = 60;
        //Rpc ȣ�� ��
        PhotonNetwork.SendRate = 60;

        //�ڸ� ��� 
        //1. spawnPos�� ������ �Ҵ�
        spawnPos = new Vector3[PhotonNetwork.CurrentRoom.MaxPlayers];
        //2. ������� (360 / maxPlayer)
        //3. GameManager �߽ɿ��� 5��ŭ ������ ��ġ�� ���
       
        //�÷��̾ �����Ѵ�.
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        
    }

    //�濡 �÷��̾ ���� ���� �� ȣ�����ִ� �Լ�
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        print(newPlayer.NickName + "�� �濡 ���Խ��ϴ�.");
    }
}

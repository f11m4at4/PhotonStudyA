using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviourPun
{

    void Start()
    {
        //OnPhotonSerializeView ȣ�� ��
        PhotonNetwork.SerializationRate = 60;
        //Rpc ȣ�� ��
        PhotonNetwork.SendRate = 60;

        //�÷��̾ �����Ѵ�.
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        if(photonView.IsMine)
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
            {
                photonView.RPC("RpcSendText", RpcTarget.All);
            }
        }
    }

    [PunRPC]
    void RpcSendText()
    {
        print("��� �غ� ��?");
    }
    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlaneMove : MonoBehaviourPun
{
    //내가 만들었던 거니?
    public bool isCreated;
    void Start()
    {
        isCreated = photonView.IsMine;
    }

    void Update()
    {
        if(isCreated)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");

            photonView.RPC("RpcSetDir", RpcTarget.MasterClient, h, v);
                       
        }

        if(PhotonNetwork.IsMasterClient)
        {
            if(dir.sqrMagnitude > 0)
            {
                transform.position += dir * 5 * Time.deltaTime;
            }
        }

        if(Input.GetKeyDown(KeyCode.Alpha5))
        {
            //방장이 아닐때 나의 소유권을 방장전달
            if(!PhotonNetwork.IsMasterClient && photonView.IsMine)
            {
                photonView.TransferOwnership(PhotonNetwork.MasterClient);
            }
        }
    }

    Vector3 dir;
    [PunRPC]
    void RpcSetDir(float h, float v)
    {
        dir = new Vector3(h, v, 0);
        dir.Normalize();

        
    }
}

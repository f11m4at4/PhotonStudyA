using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class GameManager : MonoBehaviourPunCallbacks
{
    //SpawnPos 들
    public Vector3[] spawnPos;

    void Start()
    {
        //OnPhotonSerializeView 호출 빈도
        PhotonNetwork.SerializationRate = 60;
        //Rpc 호출 빈도
        PhotonNetwork.SendRate = 60;

        //자리 계산 
        //1. spawnPos의 갯수를 할당
        spawnPos = new Vector3[PhotonNetwork.CurrentRoom.MaxPlayers];
        //2. 각도계산 (360 / maxPlayer)
        //3. GameManager 중심에서 5만큼 떨어진 위치들 계산
       
        //플레이어를 생성한다.
        PhotonNetwork.Instantiate("Player", Vector3.zero, Quaternion.identity);
    }

    void Update()
    {
        
    }

    //방에 플레이어가 참여 했을 때 호출해주는 함수
    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        print(newPlayer.NickName + "이 방에 들어왔습니다.");
    }
}

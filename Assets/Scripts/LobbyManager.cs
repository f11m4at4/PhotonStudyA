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

    //방생성
    public void CreateRoom()
    {
        //방옵션 셋팅
        RoomOptions roomOptions = new RoomOptions();
               
        //최대인원 (0명이면 최대인원)
        roomOptions.MaxPlayers = 10;
        //룸 목록에 보이냐? 보이지 않느냐?
        roomOptions.IsVisible = true;

        //방을 만든다.
        PhotonNetwork.CreateRoom("XR_A", roomOptions, TypedLobby.Default);
    }

    //방 생성 완료
    public override void OnCreatedRoom()
    {
        base.OnCreatedRoom();
        print("OnCreatedRoom");
    }

    //방 생성 실패
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
        print("OnCreateRoomFailed, " + returnCode + ", " + message);
    }

    //방입장
}

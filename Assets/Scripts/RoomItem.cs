using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    //���� 
    public Text roomInfo;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetInfo(string roomName, int currPlayer, byte maxPlayer)
    {
        //���̸� (0/0)
        roomInfo.text = roomName + " (" + currPlayer + " / " + maxPlayer + ")"; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomItem : MonoBehaviour
{
    //내용 
    public Text roomInfo;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void SetInfo(string roomName, int currPlayer, byte maxPlayer)
    {
        //방이름 (0/0)
        roomInfo.text = roomName + " (" + currPlayer + " / " + maxPlayer + ")"; 
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Information : MonoBehaviourPunCallbacks
{
    public Text roomData;
    private string roomName;

    public void OnClickJoinRoom()
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void SetInfo(string name, int current, int max)
    {
        roomName = name;
        roomData.text = name + " ( " + current + " / " + max + " ) "; 
    }
}

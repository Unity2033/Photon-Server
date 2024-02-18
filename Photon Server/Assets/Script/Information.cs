using Photon.Pun;
using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class Information : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI roomInformation;

    public void ConnectRoom()
    {
        PhotonNetwork.JoinRoom(roomInformation.text);
    }

    public void RoomData(string name, int currentStaff, int maxStaff)
    {
        roomInformation.fontSize = 50;
        roomInformation.color = Color.black;
        roomInformation.alignment = TextAlignmentOptions.Center;
        roomInformation.text = name + " ( "+ currentStaff + " / " + maxStaff + ")";
    }
}



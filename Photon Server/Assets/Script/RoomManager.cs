using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime; // ?´ëŠ ?œë²„???‘ì†?ˆì„ ???´ë²¤?¸ë? ?¸ì¶œ?˜ëŠ” ?¼ì´ë¸ŒëŸ¬ë¦?

public class RoomManager : MonoBehaviourPunCallbacks
{
    public Button roomButton;
    public InputField roomName;
    public InputField roomPerson;
    public Transform roomContent;

    // ë£?ëª©ë¡???€?¥í•˜ê¸??„í•œ ?ë£Œêµ¬ì¡°
    Dictionary<string, RoomInfo> roomDictionary = new Dictionary<string, RoomInfo>();

    void Update()
    {
        if(roomName.text.Length > 0 && roomPerson.text.Length > 0)
            roomButton.interactable = true;
        else
            roomButton.interactable = false;
    }

    // ë£¸ì— ?…ì¥?????¸ì¶œ?˜ëŠ” ì½œë°± ?¨ìˆ˜
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Photon Game");
    }

    public void OnClickCreateRoom()
    {
        // ë£??µì…˜???¤ì •?©ë‹ˆ??
        RoomOptions Room = new RoomOptions();

        // ìµœë? ?‘ì†?ì˜ ?˜ë? ?¤ì •?©ë‹ˆ??
        Room.MaxPlayers = byte.Parse(roomPerson.text);

        // ë£¸ì˜ ?¤í”ˆ ?¬ë?ë¥??¤ì •?©ë‹ˆ??
        Room.IsOpen = true;

        // ë¡œë¹„?ì„œ ë£?ëª©ë¡???¸ì¶œ ?œí‚¬ì§€ ?¤ì •?©ë‹ˆ??
        Room.IsVisible = true;

        // ë£¸ì„ ?ì„±?˜ëŠ” ?¨ìˆ˜
        PhotonNetwork.CreateRoom(roomName.text, Room);
    }

    // ?´ë‹¹ ë¡œë¹„??ë°?ëª©ë¡??ë³€ê²??¬í•­???ˆìœ¼ë©??¸ì¶œ(ì¶”ê?, ?? œ, ì°¸ê?)
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        RemoveRoom();
        UpdateRoom(roomList);
        CreateRoomObject();
    }

    void UpdateRoom(List<RoomInfo> roomList)
    {
        for (int i = 0; i < roomList.Count; i++)
        {
            // ?´ë‹¹ ?´ë¦„??RoomCatalog??key ê°’ìœ¼ë¡??¤ì •?˜ì–´ ?ˆë‹¤ë©?
            if (roomDictionary.ContainsKey(roomList[i].Name))
            {
                // RemovedFromList : (true) ë£¸ì—???? œê°€ ?˜ì—ˆ????
                if (roomList[i].RemovedFromList)
                {
                    roomDictionary.Remove(roomList[i].Name);
                }
                else
                {
                    roomDictionary[roomList[i].Name] = roomList[i];
                }
            }
            else
            {
                roomDictionary[roomList[i].Name] = roomList[i];
            }
        }
    }

    public void RemoveRoom()
    {
        foreach(Transform room in roomContent)
        {
            Destroy(room.gameObject);
        }
    }

    public void CreateRoomObject()
    {
        // RoomCatalog???¬ëŸ¬ ê°œì˜ Valueê°’ì´ ?¤ì–´ê°€?ˆë‹¤ë©?RoomInfo???£ì–´ì¤ë‹ˆ??
        foreach (RoomInfo info in roomDictionary.Values)
        {
            // ë£¸ì„ ?ì„±?©ë‹ˆ??
            GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

            // RoomContect???˜ìœ„ ?¤ë¸Œ?íŠ¸ë¡??¤ì •?©ë‹ˆ??
            room.transform.SetParent(roomContent);

            // ë£??•ë³´ë¥??…ë ¥?©ë‹ˆ??
            room.GetComponent<Information>().RoomData(info.Name, info.PlayerCount, info.MaxPlayers);
        }
    }
}

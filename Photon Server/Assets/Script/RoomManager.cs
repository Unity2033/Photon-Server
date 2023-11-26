using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using Photon.Realtime; // 어느 서버에 접속했을 때 이벤트를 호출하는 라이브러리

public class RoomManager : MonoBehaviourPunCallbacks
{
    public Button roomButton;
    public InputField roomName;
    public InputField roomPerson;
    public Transform roomContent;

    // 룸 목록을 저장하기 위한 자료구조
    Dictionary<string, RoomInfo> roomDictionary = new Dictionary<string, RoomInfo>();

    void Update()
    {
        if(roomName.text.Length > 0 && roomPerson.text.Length > 0)
            roomButton.interactable = true;
        else
            roomButton.interactable = false;
    }

    // 룸에 입장한 후 호출되는 콜백 함수
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Photon Game");
    }

    public void OnClickCreateRoom()
    {
        // 룸 옵션을 설정합니다.
        RoomOptions Room = new RoomOptions();

        // 최대 접속자의 수를 설정합니다.
        Room.MaxPlayers = byte.Parse(roomPerson.text);

        // 룸의 오픈 여부를 설정합니다.
        Room.IsOpen = true;

        // 로비에서 룸 목록을 노출 시킬지 설정합니다.
        Room.IsVisible = true;

        // 룸을 생성하는 함수
        PhotonNetwork.CreateRoom(roomName.text, Room);
    }

    // 해당 로비에 방 목록의 변경 사항이 있으면 호출(추가, 삭제, 참가)
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
            // 해당 이름이 RoomCatalog의 key 값으로 설정되어 있다면
            if (roomDictionary.ContainsKey(roomList[i].Name))
            {
                // RemovedFromList : (true) 룸에서 삭제가 되었을 때
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
        // RoomCatalog에 여러 개의 Value값이 들어가있다면 RoomInfo에 넣어줍니다.
        foreach (RoomInfo info in roomDictionary.Values)
        {
            // 룸을 생성합니다.
            GameObject room = Instantiate(Resources.Load<GameObject>("Room"));

            // RoomContect의 하위 오브젝트로 설정합니다.
            room.transform.SetParent(roomContent);

            // 룸 정보를 입력합니다.
            room.GetComponent<Information>().SetInfo(info.Name, info.PlayerCount, info.MaxPlayers);
        }
    }
}

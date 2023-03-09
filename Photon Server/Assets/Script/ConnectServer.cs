using Photon.Pun; // 게임 내부에서 데이터 주고 받는 라이브러리
using UnityEngine;
using Photon.Realtime;
using UnityEngine.UI;

public class ConnectServer : MonoBehaviourPunCallbacks
{
    [SerializeField] Dropdown server;
    public void SelectServer()
    {
        // 서버 접속
        PhotonNetwork.ConnectUsingSettings();      
    }

    public override void OnJoinedLobby()
    {
        // 일반 LoadLevel은 씬 동기화가 되지 않습니다.
        PhotonNetwork.LoadLevel("Photon Room");
    }

    public override void OnConnectedToMaster()
    {     
        // JoinLobby : 특정 로비를 생성하여 진입하는 방법
        PhotonNetwork.JoinLobby(new TypedLobby(server.options[server.value].text, LobbyType.Default));
    }
}

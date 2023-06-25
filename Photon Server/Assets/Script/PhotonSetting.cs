using PlayFab;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;
using PlayFab.ClientModels;

public class PhotonSetting : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField email;
    [SerializeField] InputField userID;
    [SerializeField] InputField password;
 
    public void SignUp()
    {
        // RegisterPlayFabUserRequest : 서버에 유저를 등록하기 위한 클래스 
        var request = new RegisterPlayFabUserRequest
        {
            Email = email.text,       // 입력한 Email
            Password = password.text, // 입력한 비밀번호
            Username = userID.text    // 입력한 게임 ID
        };

        PlayerPrefs.SetString("Name", userID.text);

        PlayFabClientAPI.RegisterPlayFabUser
        (
            request,       // 회원 가입에 대한 정보
            SignUpSuccess, // 회원 가입이 성공했을 때 함수
            SignUpFailure  // 회원 가입이 실패했을 때 함수
        );
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email.text,
            Password = password.text,
        };

        PlayFabClientAPI.LoginWithEmailAddress
        (
            request,
            LoginSuccess,
            LoginFailure
        );
    }

    public void LoginSuccess(LoginResult result)
    {
        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.NickName = PlayerPrefs.GetString("Name");

        PhotonNetwork.LoadLevel("Photon Lobby");
    }

    public void LoginFailure(PlayFabError error)
    {
        NotificationManager.NotificationWindow(error.ToString());
    }

    public void SignUpSuccess(RegisterPlayFabUserResult result)
    {
        NotificationManager.NotificationWindow(result.ToString()); 
    }

    public void SignUpFailure(PlayFabError error)
    {
        NotificationManager.NotificationWindow(error.ToString());
    }
}

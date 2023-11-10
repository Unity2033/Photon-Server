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
            Email = email.text,      
            Password = password.text, 
            Username = userID.text    
        };

        PlayerPrefs.SetString("Name", userID.text);

        PlayFabClientAPI.RegisterPlayFabUser
        (
            request,
            (RegisterPlayFabUserResult result) => NotificationManager.NotificationWindow(result.ToString()), 
            (PlayFabError error) => NotificationManager.NotificationWindow(error.ToString()) 
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
            (PlayFabError error) => NotificationManager.NotificationWindow(error.ToString())
        ); 
    }

    public void LoginSuccess(LoginResult result)
    {
        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.NickName = PlayerPrefs.GetString("Name");

        PhotonNetwork.LoadLevel("Photon Lobby");
    }

  
}

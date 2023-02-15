using Photon.Pun;
using PlayFab;
using PlayFab.ClientModels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhotonSetting : MonoBehaviourPunCallbacks
{
    [SerializeField] InputField email;
    [SerializeField] InputField password;
  
    public void LoginSuccess(LoginResult result)
    {
        PhotonNetwork.AutomaticallySyncScene = false;

        PhotonNetwork.GameVersion = "1.0f";

        PhotonNetwork.LoadLevel("Photon Lobby");
    }

    public void LoginFailure(PlayFabError error)
    {
        NotificationManager.NotificationWindow
        (
            "Login Failed",
            "There are currently no acounts registered on the server. " +
            "\n\n Please enter your ID and password correctly"
        );
    }

    public void SignUpSuccess(RegisterPlayFabUserResult result)
    {
        NotificationManager.NotificationWindow
        (
           "MemberShip Successful",
           "Congratulations on becoming a member. " +
           "\n\n Your email account has been registered on the game server"
        );
    }

    public void SignUpFailure(PlayFabError error)
    {
        NotificationManager.NotificationWindow
        (
           "Failed to Sign Up",
           "Membership registration failed due to a current server error. " +
           "\n\n Please try to register as a member again"
        );
    }

    public void SignUp()
    {
        var request = new RegisterPlayFabUserRequest
        {
            Email = email.text,
            Password = password.text
        };

        PlayFabClientAPI.RegisterPlayFabUser
        (
            request,
            SignUpSuccess,
            SignUpFailure
        );
    }

    public void Login()
    {
        var request = new LoginWithEmailAddressRequest
        {
            Email = email.text,
            Password = password.text
        };

        PlayFabClientAPI.LoginWithEmailAddress
        (
            request,
            LoginSuccess,
            LoginFailure
        );
    }
}

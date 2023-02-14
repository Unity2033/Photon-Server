using Photon.Pun;
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
}

using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NickName : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI nickName;

    void Start()
    {
        nickName.text = photonView.Owner.NickName;      
    }

    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }
}

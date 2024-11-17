using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class NickName : MonoBehaviourPunCallbacks
{
    public Text nickName;
    private Camera virtualCamera;

    private void Awake()
    {
        virtualCamera = Camera.main;
    }

    void Start()
    {
        nickName.text = photonView.Owner.NickName;
    }

    void Update()
    {
        transform.forward = virtualCamera.transform.forward;
    }
}

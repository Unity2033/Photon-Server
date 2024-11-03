using Photon.Pun;
using UnityEngine.UI;

public class NickName : MonoBehaviourPunCallbacks
{
    public Text nickName;

    void Start()
    {
        nickName.text = photonView.Owner.NickName;
    }

    void Update()
    {
       
    }
}

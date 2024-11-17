using Photon.Pun;
using UnityEngine;

public class CharacterSpawner : MonoBehaviourPunCallbacks
{
    private void Awake()
    {
      Create();
    }

    public void Create()
    {
         PhotonNetwork.Instantiate
         (
             "Character",
              new Vector3(0, 1, 0),
              Quaternion.identity
         );
    }
}

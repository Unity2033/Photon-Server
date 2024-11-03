using UnityEngine;
using Photon.Pun;
using System.Collections;


public abstract class SpawnManager : MonoBehaviourPunCallbacks
{
  
    void Start()
    {
        
    }


    public abstract IEnumerator Create();
}

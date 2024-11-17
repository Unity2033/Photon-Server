using Photon.Pun;
using UnityEngine;

[RequireComponent(typeof(Rotation))]
public class Head : MonoBehaviourPunCallbacks
{
    [SerializeField] Rotation rotation;

    private void Awake()
    {
        rotation = GetComponent<Rotation>();
    }

    void Update()
    {
        if (photonView.IsMine == false) return;

        rotation.RotateX();
    }
}
using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviourPunCallbacks
{


    public Vector3 RandomPosition(float value)
    {
        // ���� ������Ʈ�� �߽����� ���� ������ ���� �����մϴ�.
        float radius = value;

        // ù ��°�� x ���� ����մϴ�.
        float x = Random.Range(-radius, radius);

        // z ���� ���������� ����մϴ�.
        float z = Mathf.Sqrt(Mathf.Pow(radius,2) - Mathf.Pow(x,2));

        // Random.Range�� -�� +�� ���� ��ȣ�� �����մϴ�.
        if(Random.Range(0,2) == 0)
        {
            z = -z;
        }

        return new Vector3(x, 1, z);
    }

    IEnumerator Spawn(string name, float radius)
    {
        while(true)
        {
            PhotonNetwork.Instantiate
            (
                name,
                RandomPosition(radius),
                Quaternion.identity
            );

            yield return new WaitForSeconds(5);
        }
    }

    private void Awake()
    {
        PhotonNetwork.Instantiate
        (
             "Character",
             RandomPosition(10),
             Quaternion.identity
        );
    }

    void Start()
    {
        if(PhotonNetwork.IsMasterClient)
        {
            StartCoroutine(Spawn("Bee", 100));
        }
    }

    public void ExitRoom()
    {
        PhotonNetwork.LeaveRoom();
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel("Photon Room");
    }
}
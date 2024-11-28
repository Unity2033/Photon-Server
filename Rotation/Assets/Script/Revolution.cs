using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revolution : MonoBehaviour
{

    public GameObject moon;
    public GameObject origin;
    public float speed = 1.0f;

    void Start()
    {
        StartCoroutine(RotateCoroutine());
    }

    IEnumerator RotateCoroutine()
    {
        while(true)
        {
            transform.RotateAround
            (
                origin.transform.position, // ������ �Ǵ� ���� ������Ʈ
                Vector3.down,              // ���� ��
                speed * Time.deltaTime     // ȸ�� �ӵ�
            );

            moon.transform.Rotate(0.1f, 0.1f, 0.1f);

            yield return null;
        }
    }
    
    void Update()
    {
        
    }
}

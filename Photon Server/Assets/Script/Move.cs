using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector3 direction;

    public void OnKeyUpdate()
    {
        // direction.x에 대한 값을 받습니다.
        direction.x = Input.GetAxisRaw("Horizontal");

        // direction.z에 대한 값을 받습니다.
        direction.z = Input.GetAxisRaw("Vertical");

        // direction 방향을 단위 벡터로 설정합니다.
        direction.Normalize();
    }

    public void OnMove(Rigidbody rigidBody)
    {
        rigidBody.position += rigidBody.transform.TransformDirection(direction * speed * Time.deltaTime);
    }
}
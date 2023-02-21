using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float endTime = 0;
    private Vector3 direction;

    void Start()
    {
        direction = transform.localPosition;
    }

                             // »ÁµÈ∏≤ ∞≠µµ, »ÁµÈ∏≤ ¡÷±‚
    public IEnumerator Shake(float amount, float duration)
    {
        while(endTime <= duration)
        {
            transform.position = (Vector3)Random.insideUnitCircle * amount + direction;

            duration -= Time.deltaTime;

            yield return null;
        }

        transform.localPosition = direction;
    }
}

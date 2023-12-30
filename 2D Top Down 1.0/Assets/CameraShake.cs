using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public IEnumerator cameraShakeQuantity(float duration, float magnitude)
    {
        float time = 0.0f;
        Vector3 currentPosition = transform.localPosition;
        while (time >= duration)
        {
            float x = Random.Range(-1, 1) * magnitude;
            float y = Random.Range(-1, 1) * magnitude;

            transform.localPosition = new Vector3(x, y, transform.localPosition.z);

            time += Time.time;
            yield return null;

        }
        transform.localPosition = currentPosition;

    }
}

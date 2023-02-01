using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    private Transform transform;
    private float shakeLen = 0.0f;
    private float shakeAmt = 0.25f;
    private float shakeDmp = 2.0f;
    Vector3 cameraPos;

    void Awake()
    {
        if (transform == null)
        {
            transform = GetComponent(typeof(Transform)) as Transform;
        }
    }

    void OnEnable()
    {
        cameraPos = transform.localPosition;
    }

    void FixedUpdate()
    {
        if (shakeLen > 0)
        {
            transform.localPosition = cameraPos + Random.insideUnitSphere * shakeAmt;
            shakeLen -= Time.deltaTime * shakeDmp;
        }
        else
        {
            shakeLen = 0.0f;
            transform.localPosition = cameraPos;
        }
    }

    public void ShakeTrigger()
    {
        shakeLen = 0.25f;
    }
}

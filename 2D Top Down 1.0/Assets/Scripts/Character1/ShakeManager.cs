using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ShakeManager : MonoBehaviour
{
    //------------------------------------------By CineMachine camera : -----------------------------------------
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    float shakeTimer;
    public static ShakeManager Instance { get; private set; }

    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
    }

    public void CamShake(float intensity, float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin =
            cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();

        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intensity;
       // cinemachineBasicMultiChannelPerlin.m_FrequencyGain = time;
        shakeTimer = time;
    }

    private void Update()
    {
        if(shakeTimer > 0)
        {
            shakeTimer -= Time.deltaTime;
        }
            
            if(shakeTimer <= 0f)
            {
            CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = 
                cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;
            }
    }


    //-----------------------------By Camera Animation : -----------------------------------------------------
    /*[SerializeField] Animator shakeAnimation;

    public void CamShake()
    {
        shakeAnimation.SetTrigger("shake");
    }*/


    //-------------------------------------By Camera position : --------------------------------------------------

    /*[SerializeField] Transform Camera;

    private void Awake()
    {
        Camera = GameObject.FindGameObjectWithTag("MainCamera").transform;
    }
    public IEnumerator cameraShake(float duration, float magnitude)
    {
        float shakeTime = 0.0f;
        Vector3 cameraPosition = Camera.localPosition;

        while(shakeTime < duration)
        {
            float x = Random.Range(-1.0f, 1.0f) * magnitude;
            float y = Random.Range(-1.0f, 1.0f) * magnitude;

            Camera.localPosition = new Vector3(x, y, cameraPosition.z);
            shakeTime += Time.deltaTime;

            yield return null;
        }
        Camera.localPosition = cameraPosition;
    }*/
}

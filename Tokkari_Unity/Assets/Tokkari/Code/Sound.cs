using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public float sensitivity = 1;
    public GameObject seal;
    public float rms;

    AudioSource audioSource;
    Transform t;
    Vector3 s;
    float sy;

    private float upwardForce = 100f;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
        audioSource.loop = true;
        //audioSource.volume = .01f;
        while (!(Microphone.GetPosition(null) > 0)) { }
        audioSource.Play();
        t = seal.transform;
        s = t.localPosition;
        sy = s.y;
    }

    private void Update()
    {
        s.y = sy * rms * sensitivity;
        t.localPosition = s;
    }

    private void OnAudioFilterRead(float[] data, int channels)
    {
        rms = 0;

        for (int i = 0; i < data.Length; ++i)
        {
            rms += data[i] * data[i];
        }

        rms = Mathf.Sqrt(rms / data.Length);
    }
}


using UnityEngine;
using UnityEngine.UI;
public class SealController3D : MonoBehaviour
{
    private AudioClip micClip;
    public float micSensitivity = 50.0f;
    public float loudness = 1.0f;
    
    public float jumpForce = 5.0f;
    public float maxLoudness = 2.0f;
    
    private Rigidbody sealRigidbody;

    public Slider micSlider; //for mic feedback

    public PauseMenu PM; //for game pausing

    void Start()
    {
        // microphone setup
        if (Microphone.devices.Length > 0)
        {
            micClip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
        }
        else
        {
            Debug.LogError("No microphone found!");
        }

        // rigidbody setup
        sealRigidbody = GetComponent<Rigidbody>();
    }

   void Update()
   {
        if (!PM.isPaused)
        {
            loudness = GetLoudnessFromMic();
            UpdateMicFeedbackUI();
        }
        else
        {
            loudness = 0;
            UpdateMicFeedbackUI();
        }
    }

    void FixedUpdate()
    {
        ApplySealMovement();
    }

    float GetLoudnessFromMic()
    {
        int sampleSize = 128;
        float[] data = new float[sampleSize];
        int micPosition = Microphone.GetPosition(Microphone.devices[0]) - sampleSize + 1;
        if (micPosition < 0) return 0;
        micClip.GetData(data, micPosition);

        float rms = 0;
        for (int i = 0; i < sampleSize; i++)
        {
            rms += data[i] * data[i];
        }

        return Mathf.Sqrt(rms / sampleSize) * micSensitivity;
    }

    void ApplySealMovement()
    {
        float normalizedLoudness = Mathf.Clamp01(loudness / maxLoudness);
        Vector3 upwardForce = new Vector3(0, normalizedLoudness * jumpForce, 0);
        
        Debug.Log(normalizedLoudness);
        sealRigidbody.AddForce(upwardForce, ForceMode.Force);
    }

    void UpdateMicFeedbackUI()
    {
        if (micSlider != null)
        {
            micSlider.value = Mathf.Clamp01(loudness / micSensitivity);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class SealController : MonoBehaviour
{
    private AudioClip micClip;
    private string device;
    public float micSensitivity = 100.0f;
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
            device = Microphone.devices[0];
            micClip = Microphone.Start(device, true, 10, 44100);
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
        int micPosition = Microphone.GetPosition(device) - sampleSize + 1;
        if (micPosition < 0) return 0;
        micClip.GetData(data, micPosition);

        float sum = 0;
        for (int i = 0; i < sampleSize; i++)
        {
            sum += data[i] * data[i];
        }

        return Mathf.Sqrt(sum / sampleSize) * micSensitivity;
    }

    void ApplySealMovement()
    {
        float normalizedLoudness = Mathf.Clamp01(loudness / maxLoudness);
        Vector3 upwardForce = new Vector3(0, normalizedLoudness * jumpForce, 0);
        sealRigidbody.AddForce(upwardForce, ForceMode.Acceleration);
    }

    void UpdateMicFeedbackUI()
    {
        if (micSlider != null)
        {
            micSlider.value = Mathf.Clamp01(loudness / micSensitivity);
        }
    }
}

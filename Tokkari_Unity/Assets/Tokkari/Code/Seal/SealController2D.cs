using UnityEngine;
using UnityEngine.UI;
public class SealController2D : MonoBehaviour
{
    private AudioClip micClip;
    public float micSensitivity = 100.0f;
    public float loudness = 1.0f;
    
    public float jumpForce = 12.5f;
    public float maxLoudness = 5.0f;
    
    private Rigidbody2D sealRigidbody;

    public Slider micSlider; //for mic feedback

    public PauseMenu PM; //for game pausing

    public SealFlicker SF;

    public GameScore GS;

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
        
        sealRigidbody = GetComponent<Rigidbody2D>(); // rigidbody setup
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
        Vector2 upwardForce = new Vector2(0, normalizedLoudness * jumpForce);
        
        Debug.Log(normalizedLoudness);
        sealRigidbody.AddForce(upwardForce, ForceMode2D.Force);
    }

    void OnCollisionEnter2D (Collision2D obstacle)
    {
        if (obstacle.gameObject.tag == "Obstacle")
        {
            SF.isFlickering = true;
        }
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Pass")
        {
           GS.score += 1;
        }
    }

    void UpdateMicFeedbackUI()
    {
        if (micSlider != null)
        {
            micSlider.value = Mathf.Clamp01(loudness / micSensitivity);
        }
    }
}

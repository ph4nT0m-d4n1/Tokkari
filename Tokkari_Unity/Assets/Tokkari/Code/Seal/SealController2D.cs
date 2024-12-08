using UnityEngine;
using UnityEngine.UI;
public class SealController2D : MonoBehaviour
{
    private AudioClip micClip;
    public float micSensitivity = 100.0f;
    public float loudness = 2.5f;
    
    public float jumpForce = 12.5f;
    public float maxLoudness = 5.0f;
    
    private Rigidbody2D sealRigidbody;

    public Slider micSlider; //for mic feedback

    public PauseMenu PM; //for game pausing logic

    public GameScore GS; //for score logic

    public EndMenu EM; //for game ending logic

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
        if (!PM.isPaused && !EM.isGameOver)
        {
            loudness = GetLoudnessFromMic();
            UpdateMicFeedbackUI();
        }
        else //if the game is paused, no sound feedbac is relayed, and the UI is updated
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
        float normalizedLoudness = Mathf.Clamp01(loudness / maxLoudness); //normalizes the loudness to a value between 0 and 1
        Vector2 upwardForce = new Vector2(0, normalizedLoudness * jumpForce);
        
        // Debug.Log(normalizedLoudness); //for testing

        sealRigidbody.AddForce(upwardForce, ForceMode2D.Force); //using the seal's mass to move it up based on the upward force
    }

    void OnCollisionEnter2D (Collision2D obstacle)
    {
        if (obstacle.gameObject.tag == "Obstacle")
        {
            EM.GameOver(); //game ends if the seal hits an obstacle
        }
    }

    void OnTriggerEnter2D (Collider2D collider)
    {
        if (collider.gameObject.tag == "Pass")
        {
           GS.score += 1; //score is increased if the seal passes through the colliders in
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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealFlicker : MonoBehaviour
{
    private SpriteRenderer sealSprite;
    private BoxCollider2D sealCollider;
    public float flickerDuration = 3f;
    public float flickerInterval = 0.1f;

    public float flickerTimer = 0f;
    public float elapsedTime = 0f;
    public bool isFlickering = false;
    void Start()
    {
        sealSprite = GetComponent<SpriteRenderer>();
        sealCollider = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (isFlickering == true)
        {
            elapsedTime += Time.time;
            flickerTimer += Time.time;

            if (flickerTimer >= flickerInterval)
            {
                sealSprite.enabled = !sealSprite.enabled; // Toggle visibility
                flickerTimer = 0f; // Reset flicker timer
                sealCollider.enabled = false;
            }

            if (elapsedTime >= flickerDuration)
            {
                StopFlicker(); // Stop flickering after duration
            }
        }
    }

    public void StartFlicker()
    {
        isFlickering = true;
        elapsedTime = 0f;
        flickerTimer = 0f;
    }

    private void StopFlicker()
    {
        isFlickering = false;
        sealSprite.enabled = true; // Ensure sprite is visible
        sealCollider.enabled = true;
    }
}

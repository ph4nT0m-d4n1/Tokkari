using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealFlicker : MonoBehaviour
{
    private SpriteRenderer sealSprite;
    private BoxCollider2D sealCollider;
    public float flickerDuration = 3f;
    public float flickerInterval = 0.3f;
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
            StartFlicker();
        }
    }

    void StartFlicker()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime < flickerDuration)
        {
            sealSprite.enabled = !sealSprite.enabled;
            sealCollider.enabled = false;
        }
        else if (elapsedTime >= flickerDuration)
        {
            StopFlicker();
        }
    }

    void StopFlicker ()
    {
        sealSprite.enabled = true;
        sealCollider.enabled = true;
    }
}

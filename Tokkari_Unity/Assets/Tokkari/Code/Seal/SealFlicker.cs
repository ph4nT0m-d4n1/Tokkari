using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SealFlicker : MonoBehaviour
{
    private SpriteRenderer sealSprite;
    public float flickerDuration = 2f;
    public float flickerInterval = 0.3f;
    public float elapsedTime = 0f;

    public bool isFlickering = false;
    void Start()
    {
        sealSprite = GetComponent<SpriteRenderer>();
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
        }
        else if (elapsedTime >= flickerDuration)
        {
            StopFlicker();
        }
    }

    void StopFlicker ()
    {
        sealSprite.enabled = true;
    }
}

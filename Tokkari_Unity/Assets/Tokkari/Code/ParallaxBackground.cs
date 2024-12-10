using System;
using UnityEngine;

public class ParallexBackground : MonoBehaviour
{
    public float moveSpeed;
    public bool scrollLeft;
    private float textureWidth;

    void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        textureWidth = sprite.texture.width / sprite.pixelsPerUnit;

        if(scrollLeft == true)
        {
            moveSpeed = -moveSpeed;
        }
    }

    void Scroll()
    {
        float del = moveSpeed * Time.deltaTime;
        transform.position += new Vector3 (del, 0f, 0f);
    }

    void Reset()
    {
        if ((Math.Abs(transform.position.x) - textureWidth) > 0)
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }

    void Update()
    {
        Scroll();
        Reset();
    }
}

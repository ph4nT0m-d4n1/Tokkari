using System;
using UnityEngine;

public class ParallexBackground : MonoBehaviour
{
    public float moveSpeed; //how fast the background item moves
    public bool scrollLeft; //whether or not the item moves left
    private float textureWidth; //the sprite width, for repeating purposes

    void Start()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        textureWidth = sprite.texture.width / sprite.pixelsPerUnit;

        if(scrollLeft == true)
        {
            moveSpeed = -moveSpeed; //changing the movement direction
        }
    }

    void Scroll()
    {
        float del = moveSpeed * Time.deltaTime; //delta = movement speed * time, same thing here
        transform.position += new Vector3 (del, 0f, 0f);
    }

    void Reset()
    {
        if ((Math.Abs(transform.position.x) - textureWidth) > 0) //finding the absolute value of the x position in relation to the texture's width
        {
            //resetting the x position when the object is out of camera's view (i.e. when the texture's width has passed the camera)
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }

    void Update()
    {
        Scroll();
        Reset();
    }
}

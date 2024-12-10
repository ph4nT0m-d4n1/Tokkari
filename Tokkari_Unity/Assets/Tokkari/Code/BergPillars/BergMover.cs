using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BergMover : MonoBehaviour
{
    public float iceSpeed = 0.1f;
    void Update()
    {
        //update position, - to move left multiplied by speed and time in-between frames.
        transform.position -= Vector3.left * iceSpeed * Time.deltaTime;
    }
}

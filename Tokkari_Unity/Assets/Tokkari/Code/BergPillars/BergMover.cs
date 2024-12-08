using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BergMover : MonoBehaviour
{
    [SerializeField] private float iceSpeed = 0.1f; //Serialized for editor purposes
    void Update()
    {
        //update position, - to move left multiplied by speed and time.
        transform.position -= Vector3.left * iceSpeed * Time.deltaTime;
    }
}

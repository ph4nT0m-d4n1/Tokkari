using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeMover : MonoBehaviour
{
    [SerializeField] private float iceSpeed = 0.1f;
    void Update()
    {
        transform.position -= Vector3.left * iceSpeed * Time.deltaTime;
    }
}

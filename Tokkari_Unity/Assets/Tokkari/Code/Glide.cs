using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glide : MonoBehaviour
{
    public Vector3 myVelocity;
    Vector3 myCopyOfPosition;
    // Start is called before the first frame update
    void Start()
    {
     myCopyOfPosition = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        myCopyOfPosition = myCopyOfPosition + myVelocity * Time.deltaTime;
        transform.position = myCopyOfPosition;
    }
}

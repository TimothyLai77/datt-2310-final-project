using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    //private Vector3 offset = new Vector3(0f, 0f, -10f);
    //private float smoothTime = 0.25f;
    //private Vector3 velocity = Vector3.zero;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3 targetPosition = target.position + offset;
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        transform.position = new Vector3(target.transform.position.x + 1, target.transform.position.y + 1, -10);
    }
}

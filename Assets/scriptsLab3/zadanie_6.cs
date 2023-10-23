using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zadanie_6 : MonoBehaviour
{
    // Smooth towards the height of the target

    public Transform point;
    public Transform target;
    
    public float smoothTime = 0.0f;
    public float speed = 10;
    public Vector3 velocity = Vector3.zero;

    void Update()
    {
        
       point.position = Vector3.SmoothDamp(point.position, target.position, ref velocity, smoothTime, speed);
        //point.position = Vector3.Lerp(point.position, target.position, speed);
        // Lerp jest o wiele szybsze od SmoothDamp
    }
}

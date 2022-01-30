using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformRotation : MonoBehaviour
{
 
    [SerializeField] int maxAngle = 180, minAngle = 90;

    [SerializeField] float speed = 1f;
    
    private int direction = 1;
    

    Vector2 startPosition;

    Quaternion startRotation;

    Quaternion endRotation;

    Vector2 Edge1;

    Vector2 Edge2;
 
    void Awake()
    {
        startPosition = transform.position;
        startRotation = Quaternion.Euler(0, 0, minAngle);
        endRotation = Quaternion.Euler(0, 0, maxAngle);
        Edge1 = startRotation * startPosition;
        Edge2 = endRotation * startPosition;

        Debug.LogError(startRotation);
        Debug.LogError(endRotation);
        Debug.LogError(Edge1);
        Debug.LogError(Edge2);
 
    }
 
    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime; // calculate distance to move

        transform.rotation = Quaternion.Lerp(startRotation, endRotation, Time.time * speed);

        //transform.rotation = Mathf.Clamp(speed * Time.deltaTime + minAngle, minAngle, maxAngle);

        //transform.position = Vector3.RotateTowards(Edge1, Edge2, step, 0.0f);

        //Debug.LogError("position " + Vector3.RotateTowards(Edge1, Edge2, step, 0.0f)); 

        

    }

    // public static Vector2 Rotate(Vector2 v, float degrees) {
    //      float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
    //      float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
    //      return new Vector2((cos * tx) - (sin * ty),(sin * tx) + (cos * ty));
    //  }

}
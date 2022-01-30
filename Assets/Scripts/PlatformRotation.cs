using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformRotation : MonoBehaviour
{
 
    [SerializeField] int maxAngle = 180, minAngle = 90;

    [SerializeField] float speed = 1f;
    [SerializeField] bool rotate360 = false;
    
    private int direction = 1;
    

    Vector2 startPosition;

    Quaternion startRotation;
    Quaternion endRotation;
    Quaternion middleRotation;
    bool useMiddlePoint = false;

    Quaternion[] order;


    Quaternion from;
    Quaternion to;
 
    void Awake()
    {
        startPosition = transform.position;
        startRotation = Quaternion.Euler(0, 0, minAngle);
        endRotation = Quaternion.Euler(0, 0, maxAngle);

        if(maxAngle>180){
            middleRotation = Quaternion.Euler(0, 0, (maxAngle - minAngle)/2);
            order = new Quaternion[]{startRotation,middleRotation,endRotation,middleRotation};
        }
        if(rotate360){
            startRotation = Quaternion.Euler(0, 0, 0);
            middleRotation = Quaternion.Euler(0, 0, 180);
            endRotation = Quaternion.Euler(0, 0, 360);
            order = new Quaternion[]{startRotation,middleRotation,endRotation,startRotation};
        } else {
            order = new Quaternion[]{startRotation,endRotation};
        }


        // Edge1 = startRotation * startPosition;
        // Edge2 = endRotation * startPosition;

        // Debug.LogError(startRotation);
        // Debug.LogError(endRotation);
        // Debug.LogError(Edge1);
        // Debug.LogError(Edge2);
 
    }
 
    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime; // calculate distance to move

        transform.rotation = Quaternion.Lerp(from, to, Time.time * speed);
        
        //updateFromTo();

    }

    // private void updateFromTo(){
    //     if (Quaternion.Angle(transform.rotation, target.rotation) < 0.5f){


    //     }

    // }

    // public static Vector2 Rotate(Vector2 v, float degrees) {
    //      float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
    //      float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
    //      return new Vector2((cos * tx) - (sin * ty),(sin * tx) + (cos * ty));
    //  }

}
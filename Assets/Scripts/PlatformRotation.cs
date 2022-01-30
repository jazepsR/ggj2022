using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformRotation : MonoBehaviour
{

    [SerializeField] float maxAngle = 180, minAngle = 90;

    [SerializeField] float speed = 1f;
    [SerializeField] bool rotate360 = false;
    [SerializeField] bool rotateReverse = false;
    
    float currentAngle;
    private int direction = 1;

    private int reverse = 1;
    


    void Awake()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, minAngle), 1);
        currentAngle = minAngle;
        if(rotateReverse) reverse=-1;
    }
 
    void Update()
    {
        float step =  speed * Time.deltaTime; // calculate distance to move

        currentAngle+=step * direction * reverse;

        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, currentAngle), 1);
        
        if (currentAngle>maxAngle && ! rotate360){
            direction = -1 * reverse;
        } else if ((currentAngle%360)<minAngle && ! rotate360){
            direction = 1 * reverse;
        }
        

    }

}
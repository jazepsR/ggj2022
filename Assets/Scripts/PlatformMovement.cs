using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlatformMovement : MonoBehaviour
{
 
    [SerializeField] Vector2 offset = new Vector2(4f, 0.0f);

    [SerializeField] float speed = 1f;
    
    private int direction = 1;
    private Vector2 destination;

    private Vector2 Edge1;
    private Vector2 Edge2;

    



    Vector2 startPosition;
 
    void Awake()
    {
        startPosition = transform.position;
        Edge1 = startPosition + offset;
        Edge2 = startPosition;
        destination = Edge1;
 
    }
 
    // Update is called once per frame
    void Update()
    {
        float step =  speed * Time.deltaTime; // calculate distance to move

        transform.position = Vector3.MoveTowards(transform.position, destination, step);


        if (Vector3.Distance(transform.position, destination) < 0.001f)
        {
            if(direction ==1 )
                destination = Edge1;
            else
                destination = Edge2;
            direction *= -1;
        }
        
    }

}
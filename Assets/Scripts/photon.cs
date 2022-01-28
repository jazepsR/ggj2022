using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photon : MonoBehaviour
{
    public float force = 10;
    public float waveDistance = 7;
    Rigidbody2D rb;
    enum photonStates  {PARTICLE,WAVE,IDLE,AIMING};
    photonStates activeState = photonStates.IDLE;
    public GameObject circle;
    TrailRenderer trail;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circle.SetActive(false);
        trail = GetComponent<TrailRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    switch (activeState)
    {
        case photonStates.IDLE:
                trail.enabled = true;
                break;
        case photonStates.AIMING:
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rb.AddForce(direction.normalized * force);
                activeState = photonStates.PARTICLE;
                    Debug.LogError("Particle STATE!");
                }
            
            break;

        case photonStates.PARTICLE:
            if (Input.GetMouseButtonDown(0))
            {
                activeState = photonStates.WAVE;
                    Debug.LogError("WAVE STATE!");
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    circle.SetActive(true);
                    trail.enabled = false;
                }
            break;
        case photonStates.WAVE:
            if (Input.GetMouseButtonUp(0))
            {
                    Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    if (direction.magnitude <waveDistance)
                    {
                        activeState = photonStates.IDLE;
                        Debug.LogError("Idle STATE!");
                        circle.SetActive(false);
                        Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                        transform.position = pos;
                        rb.constraints = RigidbodyConstraints2D.None;
                    }

                }
            break;

    }

    }

    public void onClick()
    {
        if (activeState == photonStates.IDLE)
        {
            Debug.LogError("AIMING STATE!");
            activeState = photonStates.AIMING;
        }
        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photon : MonoBehaviour
{
    public Vector2 startingCoordinates;
    public float force = 10;
    public float waveDistance = 7;
    Rigidbody2D rb;
    enum photonStates  {PARTICLE,WAVE,IDLE,AIMING};
    photonStates activeState = photonStates.IDLE;
    public GameObject circle;
    TrailRenderer trail;
    private Vector3 lastPosition;
    public float distanceTraveled = 0;
    public float maxDistance = 50;//Probably level speciffic, 
    public HealthBar healthBar;
    public int maxWaveLives = 5;//Probably level speciffic
    public int currentWaveLives = 5;
    [SerializeField] private aimArrow aimArrow;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circle.SetActive(false);    
        trail = GetComponent<TrailRenderer>();
        startingCoordinates = transform.position;
        aimArrow.ToggleArrow(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position ;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction;
    switch (activeState)
    {
        case photonStates.IDLE:
                trail.enabled = true;
                //Vector2 direction = (transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
                break;
        case photonStates.AIMING:

                direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                aimArrow.ToggleArrow(true);
                aimArrow.SetRotation(direction);
                if (Input.GetMouseButtonUp(0))
            {
                rb.AddForce(direction.normalized * force);
                activeState = photonStates.PARTICLE;
                Debug.LogError("Particle STATE!");
                    aimArrow.ToggleArrow(false);
                }
            
            break;

        case photonStates.PARTICLE:
            distanceTraveled += Vector3.Distance(lastPosition, transform.position);
            lastPosition = transform.position;
            if(healthBar.HealthBarRedrawAndIsEmpty())
                Reset();
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
                    direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
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

    public void Reset(){
        activeState = photonStates.IDLE;
        transform.position = startingCoordinates;
        distanceTraveled = 0;
        currentWaveLives = maxWaveLives;
        healthBar.HealthBarRedrawAndIsEmpty();
    }

}

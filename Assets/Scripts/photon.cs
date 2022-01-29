using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photon : MonoBehaviour
{
    public Vector2 startingCoordinates; //level speciffic
    public float force = 10;
    public float waveDistance = 7;
    Rigidbody2D rb;
    enum photonStates  {PARTICLE,WAVE,IDLE,AIMING, FINISH};
    photonStates activeState = photonStates.IDLE;
    public GameObject circle;
    TrailRenderer trail;
    private Vector3 lastPosition;
    public float distanceTraveled = 0;
    public float maxDistance = 150; //level speciffic
    public HealthBar healthBar;
    public int maxWaveLives = 5; //level speciffic
    public int currentWaveLives = 5;
    public waveLives waveLivesDisplay;
    [SerializeField] private aimArrow aimArrow;
    private Transform finish;
    public float finishPullForce = 1000;
    public LayerMask layerMask;
    public Sprite idleFace;
    public Sprite flyingFace;
    public Sprite waveFace;
    public SpriteRenderer photonRenderer;
    public SpriteRenderer faceRenderer;

    public void SetUp(int maxWaveTravels, float maxParticleDuration, Transform startPoint){
        maxDistance = maxParticleDuration;
        maxWaveLives = maxWaveTravels;
        startingCoordinates = startPoint.position;
        Reset();
    }
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        circle.SetActive(false);    
        trail = GetComponent<TrailRenderer>();
        startingCoordinates = transform.position;
        lastPosition = transform.position ;
        aimArrow.ToggleArrow(false);
 
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError("STARTING!");
        waveLivesDisplay.SetLives(currentWaveLives); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction;
    switch (activeState)
    {
        case photonStates.IDLE:
                trail.enabled = true;
                faceRenderer.sprite = idleFace;
                photonRenderer.enabled = true;
                //Vector2 direction = (transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition)).normalized;
                break;
        case photonStates.AIMING:

                direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                aimArrow.SetRotation(direction);
                if (Input.GetMouseButtonUp(0))
                {
                    rb.AddForce(direction.normalized * force);
                    activeState = photonStates.PARTICLE;
                    Debug.LogError("Particle STATE!");
                    aimArrow.ToggleArrow(false);
                    faceRenderer.sprite = flyingFace;
                }
            
            break;

        case photonStates.PARTICLE:
            distanceTraveled += Vector3.Distance(lastPosition, transform.position);
            lastPosition = transform.position;
            if (Input.GetMouseButtonDown(0) && currentWaveLives>=1)
                {
                    distanceTraveled = 0.0f;
                    activeState = photonStates.WAVE;
                    Debug.LogError("WAVE STATE!");
                    rb.constraints = RigidbodyConstraints2D.FreezeAll;
                    circle.SetActive(true);
                    trail.enabled = false;
                    faceRenderer.sprite = waveFace;
                    photonRenderer.enabled = false;
                }
            if(healthBar.HealthBarRedrawAndIsEmpty()){
                Reset();
            }
            break;
        case photonStates.WAVE:
            
            if (Input.GetMouseButtonUp(0))
            {
                direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);

                    if (direction.magnitude <waveDistance)
                    {
                        RaycastHit2D hit = Physics2D.Raycast(transform.position, -direction,direction.magnitude,layerMask);
                        if (hit.collider == null)
                        {
                            currentWaveLives -=1;
                            waveLivesDisplay.SetLives(currentWaveLives);
                            activeState = photonStates.IDLE;
                            Debug.LogError("Idle STATE!");
                            circle.SetActive(false);
                            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                            transform.position = pos;
                            rb.constraints = RigidbodyConstraints2D.None;
                        }
                        else
                        {
                           // Debug.LogError(hit.collider.name);
                        }
                    }

                }
            break;
            case photonStates.FINISH:
                direction = transform.position - finish.position;
                rb.angularDrag = 10;
                rb.drag = 5;
                if(direction.magnitude<0.2f)
                {
                    LevelController.instance.CompleteLevel();
                }
                else
                {
                    rb.AddForce(-direction.normalized * Time.deltaTime * finishPullForce);
                }

                break;

    }

    }
    public void OnReachedFinish(Transform finish)
    {
        this.finish = finish;
        activeState = photonStates.FINISH;

    }
    public void onClick()
    {
        if (activeState == photonStates.IDLE)
        {
            Debug.LogError("AIMING STATE!");
            activeState = photonStates.AIMING;
            aimArrow.ToggleArrow(true);
        }
        
    }

    public void Reset(){
        trail.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        rb.constraints = RigidbodyConstraints2D.None;
        activeState = photonStates.IDLE;
        transform.position = startingCoordinates;
        lastPosition = startingCoordinates;
        distanceTraveled = 0;
        currentWaveLives = maxWaveLives;
        waveLivesDisplay.SetLives(currentWaveLives);
        healthBar.HealthBarRedrawAndIsEmpty();
    }

}

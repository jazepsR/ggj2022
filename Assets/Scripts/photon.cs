using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class photon : MonoBehaviour
{
    public float force = 10;
    Rigidbody2D rb;
    enum photonStates = {PARTICLE,WAVE,IDLE,AIMING};
    photonStates activeState = IDLE;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
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
        case IDLE:
            break;
        case AIMING:
            if (Input.GetMouseButtonUp(0))
            {
                Vector2 direction = transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rb.AddForce(direction.normalized * force);
                isAiming = false;
                activeState = PARTICLE;
            }
            
            break;

        case PARTICLE:
            if (Input.GetMouseButtonDown(0))
            {
                Debug.LogError("PARTICLE STATE!");
                activeState = WAVE;
                //rb.Constrains = Rigidbody2D.FREEZE_ALLL
            }
            break;
        case WAVE:
            if (Input.GetMouseButtonUp(0))
            {
                Debug.LogError("WAVE STATE!");
                activeState = IDLE;
            }
            break;

    }

    }

    public void onClick()
    {
        Debug.LogError("AIMING STATE!");
         activeState = AIMING; 

        
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aimArrow : MonoBehaviour
{
    public SpriteRenderer sprite;
    public float rotationSpeed = 20;

    private void Awake()
    {

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ToggleArrow(bool isActive)
    {
        if (sprite)
        {
            sprite.enabled = isActive;
        }
    }

    public void SetRotation(Vector2 direction)
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.position, -direction), rotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

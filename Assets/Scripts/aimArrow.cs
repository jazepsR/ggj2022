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
      //  Debug.LogError(" direction: " + direction + " rotation: " +  Quaternion.An(transform.position, -direction));
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.AngleAxis(angle, Vector3.forward), rotationSpeed);
        // Quaternion.Lerp(transform.rotation, Quaternion.FromToRotation(transform.position, -direction), rotationSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

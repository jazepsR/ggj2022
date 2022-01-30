using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectionPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public bool isFinish = false;
    public bool collected = false;
    public bool collectedThisThrow = false;
    public GameObject highlight;

    private void Start()
    {
        ToggleCollected(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.LogError("got hit by " + collision.tag);
        if (collision.tag == "Player")
        { 
            if(isFinish)
            {
                if (LevelController.instance.activeLevel.AllCheckpointsCollected())
                {
                    photon photon = collision.gameObject.GetComponent<photon>();
                    photon.OnReachedFinish(transform);
                    ToggleCollected(true);
                }
            }
            else
            {
                ToggleCollected(true);
                collectedThisThrow = true;
            }
            
        }
    }

    public void ToggleCollected(bool collected)
    {
        highlight.SetActive(collected);
        this.collected = collected;
    }
}

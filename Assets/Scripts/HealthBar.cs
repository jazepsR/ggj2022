using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

  public Image healthBarImage;
  public photon photon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool HealthBarRedrawAndIsEmpty() {
        float fillAmount = Mathf.Clamp(1-photon.distanceTraveled / photon.maxDistance, 0, 1f);
        healthBarImage.fillAmount = fillAmount;
        if(fillAmount==0f){
            return true;
        } else{
            return false;
        }
    }
}
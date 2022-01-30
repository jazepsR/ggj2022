using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class waveLives : MonoBehaviour
{
    public Image life1;
    public Image life2;
    public Image life3;
    public Image life4;
    public Image life5;
    Image[] lives;

    private void Awake(){
        lives = new Image[5]{life1, life2, life3, life4, life5};
    }

     
    // Start is called before the first frame update
    void Start()
    {      

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLives(int currentLives){
        for (int i = 0; i < lives.Length; i++){
            if(currentLives>i)
                lives[i].enabled = true;
            else 
                lives[i].enabled = false;


        }
        
    }
}

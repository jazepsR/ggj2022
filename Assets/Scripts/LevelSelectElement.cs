using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public enum levelState { COMPLETED, AVAILABLE, LOCKED }
public class LevelSelectElement : MonoBehaviour
{
    // Start is called before the first frame update
    public Image bg;
    public Sprite completedColor;
    public Sprite availableColor;
    public Sprite lockedColor;
    public TMP_Text text;
    private int id;
    bool available;
    void Start()
    {
        
    }

    public void Setup(int id, levelState state)
    {
        this.id = id;
        text.text = id.ToString();
        switch(state)
        {
            case levelState.AVAILABLE:
                bg.sprite = availableColor;
                available = true;
                break;
            case levelState.COMPLETED:
                bg.sprite = completedColor;
                available = true;
                break;
            case levelState.LOCKED:
                bg.sprite = lockedColor;
                available = false;
                break;
        }
    }

    // Update is called once per frame
    public void StartLevel()
    {
        if(available)
        {
            Var.currentLevel = id-1;
            SceneManager.LoadScene("SampleScene");
        }
    }
}

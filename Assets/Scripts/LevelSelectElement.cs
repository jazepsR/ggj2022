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
    public Color completedColor;
    public Color availableColor;
    public Color lockedColor;
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
                bg.color = availableColor;
                available = true;
                break;
            case levelState.COMPLETED:
                bg.color = completedColor;
                available = true;
                break;
            case levelState.LOCKED:
                bg.color = lockedColor;
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

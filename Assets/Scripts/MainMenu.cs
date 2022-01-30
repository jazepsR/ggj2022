using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;

    // Start is called before the first frame update
    void Awake()
    {
        Var.Load();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GoToLevels()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToLevelSelect()
    {
        levelSelect.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void GoToMainMenu()
    {
        levelSelect.SetActive(false);
        mainMenu.SetActive(true);
    }

}

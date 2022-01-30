using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levelSelect;
    public GameObject tutorial;

    // Start is called before the first frame update
    void Awake()
    {
        Var.Load();
        tutorial.SetActive(false);
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


    public void PlayOrShowTutorial(){
        if(!Var.tutorialShown){
            ShowTutorial();
        } else {
            Play();
        }
    }

    public void ShowTutorial(){
        Var.tutorialShown = true;
        tutorial.SetActive(true);
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

    public void CloseTutorial()
    {
        tutorial.SetActive(false);
        Play();
    }

}

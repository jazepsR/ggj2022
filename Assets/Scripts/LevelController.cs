using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class LevelController : MonoBehaviour
{
    public LevelData[] levels;
   [HideInInspector] public LevelData currentLevelData;
    [HideInInspector] public Level activeLevel;
    public static LevelController instance;
    public GameObject levelCompleteMenu;
    public GameObject levelLoseMenu;
    public Animator levelCompleteStarsAnim;
    public CinemachineVirtualCamera cam;
    public photon photon;
    public Transform center;
    private void Awake()
    {
        instance = this;
        levelCompleteMenu.SetActive(false);
        levelLoseMenu.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        currentLevelData = levels[Var.currentLevel % levels.Length];
        GenerateLevel(currentLevelData);
    }

    public void GenerateLevel(LevelData level)
    {
        activeLevel= Instantiate(level.levelGeometry);
        photon.SetUp(level.shotsAllowed, level.particleDuration, level.levelGeometry.start);
        cam.m_Follow = level.staticCamera ? center : photon.transform;
        cam.m_LookAt = level.staticCamera ? center : photon.transform;
    }

    public void CompleteLevel(int livesLeft)
    {
        levelCompleteMenu.gameObject.SetActive(true);
        int score = CalculateScore(livesLeft);
        Debug.LogError("SCORE: " + score);
        levelCompleteStarsAnim.SetInteger("stars", score);
        Var.maxUnlockedLevel = Mathf.Max(Var.currentLevel+1, Var.maxUnlockedLevel);
        Var.Save();
    }

    public void GoToNextLevel()
    {
        Var.currentLevel++;
        Var.Save();
        SceneManager.LoadScene("SampleScene");
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public int CalculateScore(int livesLeft)
    {
        if (livesLeft == 0)
        {
            return 1;
        }
        if((currentLevelData.shotsAllowed - livesLeft) < currentLevelData.bestScoreShots)
        {
            return 3;
        }
        else
        {
            return 2;
        }
    }
}

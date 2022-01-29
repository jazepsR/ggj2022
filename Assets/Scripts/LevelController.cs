using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public LevelData[] levels;
   [HideInInspector] public LevelData currentLevelData;
    [HideInInspector] public Level activeLevel;
    public static LevelController instance;
    public GameObject levelCompleteMenu;

    public photon photon;

    private void Awake()
    {
        instance = this;
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
        
    }

    public void CompleteLevel()
    {
        levelCompleteMenu.gameObject.SetActive(true);
    }

    public void GoToNextLevel()
    {
        Var.currentLevel++;
        SceneManager.LoadScene("SampleScene");
    }

}

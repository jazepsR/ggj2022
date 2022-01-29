using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelController : MonoBehaviour
{
    public LevelData[] levels;
   [HideInInspector] public LevelData currentLevel;
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
        currentLevel = levels[Var.currentLevel % levels.Length];
        GenerateLevel(currentLevel);
    }

    public void GenerateLevel(LevelData level)
    {
        Instantiate(level.levelGeometry);
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

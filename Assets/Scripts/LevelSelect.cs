using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelect : MonoBehaviour
{
    public Transform levelElementParent;
    public LevelSelectElement levelElementPrefab;
    // Start is called before the first frame update
    void Start()
    {
        CreateLevelElements();
    }

    private void CreateLevelElements()
    {
        for(int i=0;i<Var.levelCount;i++)
        {
            LevelSelectElement obj = Instantiate(levelElementPrefab, levelElementParent);
            if (i < Var.maxUnlockedLevel)
            {
                obj.Setup((i + 1), levelState.COMPLETED);
            }
                else if(i == Var.maxUnlockedLevel)
            {
                obj.Setup((i + 1), levelState.AVAILABLE);
            }
            else
            {
                obj.Setup((i + 1), levelState.LOCKED);
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

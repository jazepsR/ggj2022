using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "level", menuName = "ScriptableObjects/levelData", order = 1)]
public class LevelData : ScriptableObject
{
    public Level levelGeometry;
    public int shotsAllowed = 3;
    public int bestScoreShots = 3;
    public float particleDuration = 50;
    public bool staticCamera = true;
   

}

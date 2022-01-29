using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public CollectionPoint finish;
    public Transform start;
    public CollectionPoint[] chechpoints;

    public bool AllCheckpointsCollected()
    {

        foreach (CollectionPoint point in chechpoints)
        {
            if (!point.collected)
            {
                return false;
            }
        }
        return true;

    }

}

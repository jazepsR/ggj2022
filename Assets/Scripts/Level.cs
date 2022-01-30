using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public CollectionPoint finish;
    public Transform start;
    public CollectionPoint[] checkPoints;

    public bool AllCheckpointsCollected()
    {
        if (checkPoints.Length == 0)
            return true;
        foreach (CollectionPoint point in checkPoints)
        {
            if (!point.collected)
            {
                return false;
            }
        }
        return true;
    }

    public void DiscardCollectedThisThrow()
    {
        if (checkPoints.Length == 0)
            return;
        foreach (CollectionPoint point in checkPoints)
        {
            if (point.collectedThisThrow)
            {
                point.ToggleCollected(false);
            }
        }

    }

    public void PrepForNextThrow()
    {
        if (checkPoints.Length == 0)
            return;
        foreach(CollectionPoint point in checkPoints)
        {
            point.collectedThisThrow = false;
        }
    }

}

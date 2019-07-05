using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellTower : MonoBehaviour
{
    [SerializeField] private Material selectMat = null;
    [SerializeField] private MeshRenderer lightRender = null;
    private bool isNotified = false;

    public void NotifyEventState()
    {
        if (!isNotified)
        {
            this.tag = "Untagged";
            lightRender.material = selectMat;
            GameState.instance.Notify();
            isNotified = true;
        }
    }
}

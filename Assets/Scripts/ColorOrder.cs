using UnityEngine;

public class ColorOrder : Interactable
{
    [SerializeField] private int order = 0;
    [SerializeField] private PuzzleOrder po = null;

    public override void ExecuteEvent()
    {
        po.CheckOrder(order);
    }
}

using UnityEngine;

public class PuzzleOrder : MonoBehaviour
{
    [SerializeField] private int[] correctOrder = null;
    [SerializeField] private Animator triggerAnim = null;
    private int counter = 0;
    private bool isFinished = false;

    public void CheckOrder(int order)
    {
        if(correctOrder[counter] == order)
        {
            counter++;

            if(counter == correctOrder.Length && !isFinished)
            {
                triggerAnim.SetBool("Trigger", true);
            }
        } else
        {
            counter = 0;
        }
    }
}

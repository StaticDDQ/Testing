using UnityEngine;

public class ElevatorShard : MonoBehaviour
{
    private bool isUp = false;

    public void UseElevator()
    {
        if (!isUp)
            transform.parent.GetComponent<Animator>().Play("MoveUp");
        else
            transform.parent.GetComponent<Animator>().Play("MoveDown");

        isUp = !isUp;
    }
}

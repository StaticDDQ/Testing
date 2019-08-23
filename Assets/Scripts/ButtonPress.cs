using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] private Interactable interactEvent = null;
    [SerializeField] private bool pressOnce = false;
    private bool isSelected = false;
    private Material currMat;

    private void Start()
    {
        currMat = GetComponent<MeshRenderer>().material;
    }

    public void PressButton()
    {
        if ((pressOnce && !isSelected) || !pressOnce)
        {
            transform.parent.GetComponent<Animator>().Play("buttonPress", -1, 0f);

            if(interactEvent != null)
                interactEvent.ExecuteEvent();

            isSelected = !isSelected;
        }
    }
}

using UnityEngine;

public class ButtonPress : MonoBehaviour
{
    [SerializeField] private Interactable interactEvent;
    [SerializeField] private Material selectMat;
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
            if(interactEvent != null)
                interactEvent.ExecuteEvent();

            isSelected = !isSelected;

            if (isSelected)
            {
                GetComponent<MeshRenderer>().material = selectMat;
            }
            else
            {
                GetComponent<MeshRenderer>().material = currMat;
            }
        }
    }
}

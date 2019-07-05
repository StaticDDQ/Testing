using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private float dist = 10f;
    private Transform selectObject;
    private bool isSelected = false;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward),out hit, dist))
        {
            if (hit.transform.tag == "BellTower")
            {
                if (!isSelected)
                {
                    selectObject = hit.transform;
                    selectObject.GetComponent<MeshHighlight>().EnableHighlight(true);
                    isSelected = true;
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    selectObject.GetComponent<BellTower>().NotifyEventState();
                }
            }
            else if (selectObject != null)
            {
                selectObject.GetComponent<MeshHighlight>().EnableHighlight(false);
                selectObject = null;
                isSelected = false;
            }
        }
        else if (selectObject != null)
        {
            selectObject.GetComponent<MeshHighlight>().EnableHighlight(false);
            selectObject = null;
            isSelected = false;
        }        
    }
}

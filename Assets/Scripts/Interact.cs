using UnityEngine;

public class Interact : MonoBehaviour
{
    [SerializeField] private float dist = 10f;

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, dist))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (hit.transform.tag == "BellTower")
                {
                    hit.transform.GetComponent<BellTower>().NotifyEventState();
                }
                else if (hit.transform.tag == "Portal")
                {
                    hit.transform.GetComponent<PortalPath>().LoadPath();
                }
                else if (hit.transform.tag == "Shard")
                {
                    hit.transform.GetComponent<ElevatorShard>().UseElevator();
                }
                else if(hit.transform.tag == "Button")
                {
                    hit.transform.GetComponent<ButtonPress>().PressButton();
                }
            }
        }
    }
}

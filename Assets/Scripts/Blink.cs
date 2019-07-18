using UnityEngine;

public class Blink : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] private float range = 20f;

    private GameObject GetLookedAtObject()
    {
        Vector3 origin = transform.position;
        Vector3 dir = Camera.main.transform.forward;
        if(Physics.Raycast(origin, dir, out hit, range) && hit.transform.tag == "Ground")
        {
            return hit.collider.gameObject;
        } else
        {
            return null;
        }
    }

    private void Teleport()
    {
        transform.parent.position = hit.point + hit.normal * 1.5f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if(GetLookedAtObject() != null)
            {
                Teleport();
            }
        }
    }
}

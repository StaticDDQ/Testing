using UnityEngine;

public class Blink : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] private float range = 20f;
    [SerializeField] private float cooldown = 10f;
    private bool canBlink = true;
    private float cdElapsed = 0;

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
        if (canBlink && Input.GetKeyDown(KeyCode.F))
        {
            if(GetLookedAtObject() != null)
            {
                Teleport();
                canBlink = false;
                cdElapsed = cooldown;
            }
        }

        if (!canBlink)
        {
            cdElapsed -= Time.deltaTime;
            if (cdElapsed <= 0)
            {
                canBlink = true;
            }
        }
    }
}

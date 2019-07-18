using UnityEngine;

public class ZoneTeleport : MonoBehaviour
{
    [SerializeField] private Transform newPos = null;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = newPos.position;
    }
}

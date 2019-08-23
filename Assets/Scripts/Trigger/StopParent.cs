using UnityEngine;

public class StopParent : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            other.transform.SetParent(null);
            Destroy(gameObject);
        }
    }
}

using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class ZoneTeleport : MonoBehaviour
{
    [SerializeField] private Transform newPos = null;

    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<CharacterMovement>().MoveCharacter(newPos.position);
    }
}

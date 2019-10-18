using UnityEngine;

public class PortalTeleport : PortalBehaviour
{
    [SerializeField] private Transform otherPortal = null;
    [SerializeField] private Vector3 offset = Vector3.zero;

    public override void LoadPath(Transform entity)
    {
        entity.position = otherPortal.position - offset;
    }
}

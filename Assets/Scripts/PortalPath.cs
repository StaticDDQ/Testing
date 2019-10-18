using UnityEngine;

public class PortalPath : PortalBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private bool isHome = false;
    private bool hasLoad = false;

    public override void LoadPath(Transform entity)
    {
        if (!hasLoad)
        {
            SceneFade.instance.StartLevel(level, isHome);
            hasLoad = true;
        }
    }
}

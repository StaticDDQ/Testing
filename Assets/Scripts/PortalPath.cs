using UnityEngine;

public class PortalPath : MonoBehaviour
{
    [SerializeField] private int level = 1;
    [SerializeField] private bool isHome = false;
    private bool hasLoad = false;

    public void LoadPath()
    {
        if (!hasLoad)
        {
            SceneFade.instance.StartLevel(level, isHome);
            hasLoad = true;
        }
    }
}

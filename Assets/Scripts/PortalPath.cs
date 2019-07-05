using UnityEngine;

public class PortalPath : MonoBehaviour
{
    [SerializeField] private int level = 1;
    private bool hasLoad = false;

    public void LoadPath()
    {
        if (!hasLoad)
        {
            SceneFade.instance.StartLevel(level);
            hasLoad = true;
        }
    }
}

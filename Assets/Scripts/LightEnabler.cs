using UnityEngine;

public class LightEnabler : MonoBehaviour
{
    private bool isEnabled = false;
    private MeshRenderer mr;
    [SerializeField] private Material newMat = null;
    private Material currMat;

    private void Start()
    {
        mr = GetComponent<MeshRenderer>();
        currMat = mr.material;
    }

    public void TurnOn()
    {
        if (!isEnabled)
        {
            isEnabled = true;
            mr.material = newMat;
            ConditionEvent.instance.CompleteEvent();
        }
    }

    public void TurnOff()
    {
        if (isEnabled)
        {
            isEnabled = false;
            mr.material = currMat;
            ConditionEvent.instance.DecompleteEvent();
        }
    }

    public bool GetIsEnabled()
    {
        return this.isEnabled;
    }
}

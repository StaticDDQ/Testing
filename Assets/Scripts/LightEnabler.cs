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

    public void SwitchControl()
    {
        isEnabled = !isEnabled;
        if (isEnabled)
        {
            mr.material = newMat;
            ConditionEvent.instance.CompleteEvent();
        } else
        {
            mr.material = currMat;
            ConditionEvent.instance.DecompleteEvent();
        }
    }
}

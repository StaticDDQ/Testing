using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class MeshHighlight : MonoBehaviour
{
    private MeshRenderer mr;
    [SerializeField]
    private Material highlightMat = null;
    private Material currMat;

    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
        currMat = mr.material;
    }

    public void EnableHighlight(bool onOff)
    {
        if(highlightMat != null && onOff)
        {
            mr.material = highlightMat;
        }
        else
        {
            mr.material = currMat;
        }
    }
}

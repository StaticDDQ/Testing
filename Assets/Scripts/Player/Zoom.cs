using UnityEngine;

public class Zoom : MonoBehaviour
{
    // zoom distance
    [SerializeField] private int zoomAmnt = 20;
    // normal distance
    [SerializeField] private int normalAmnt = 60;
    // smooth transition
    [SerializeField] private float smooth = 5;
    private bool zoomed = false;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        // right click
        if (Input.GetMouseButtonDown(1))
        {
            zoomed = !zoomed;
        }

        // zoom at unscaled time at zoom amount
        if (zoomed)
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, zoomAmnt, Time.unscaledDeltaTime * smooth);
        }
        else
        {
            cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, normalAmnt, Time.unscaledDeltaTime * smooth);
        }
    }
}

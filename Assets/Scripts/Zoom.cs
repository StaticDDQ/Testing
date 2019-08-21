using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    [SerializeField] private int zoomAmnt = 20;
    [SerializeField] private int normalAmnt = 60;
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
        if (Input.GetMouseButtonDown(1))
        {
            zoomed = !zoomed;
        }

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

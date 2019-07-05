using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;
using System.Collections;

public class PlatformControl : EventHandle
{
    [SerializeField]
    private Animator towersAnim = null;
    private Animator platformAnim;
    [SerializeField]
    private List<Collider> blocks = null;

    // Start is called before the first frame update
    void Start()
    {
        platformAnim = GetComponent<Animator>();
    }

    public override void PerformAction()
    {
        foreach (Collider collider in blocks)
        {
            collider.enabled = true;
        }

        platformAnim.Play("Cube|CubeAction");

        StartCoroutine(CutsceneEvent());
    }

    private IEnumerator CutsceneEvent()
    {
        towersAnim.Play("TowersEmerge");
        CameraShaker.Instance.ShakeOnce(4f, 3f, 0.5f, 3f);

        yield return new WaitForSeconds(5);

        platformAnim.Play("Reverse");
        yield return new WaitForSeconds(1);

        foreach (Collider collider in blocks)
        {
            collider.enabled = false;
        }
    }
}

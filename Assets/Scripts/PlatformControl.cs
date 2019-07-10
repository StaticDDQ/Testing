using UnityEngine;
using System.Collections;

public class PlatformControl : EventHandle
{
    private Animator platformAnim;
    [SerializeField]
    private HomeControl homeControl;

    // Start is called before the first frame update
    void Start()
    {
        platformAnim = GetComponent<Animator>();
    }

    public override void PerformAction()
    {
        StartCoroutine(CutsceneEvent());
    }

    private IEnumerator CutsceneEvent()
    {
        platformAnim.Play("PlatformOn");
        StartCoroutine(homeControl.InitialSetup());
        yield return new WaitForSeconds(5);
        platformAnim.Play("PlatformOff");
    }
}

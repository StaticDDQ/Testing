using System.Collections;
using UnityEngine;
using EZCameraShake;

public class HomeControl : MonoBehaviour
{
    [SerializeField]
    private Animator[] stairsAnim = null;
    [SerializeField]
    private Animator towersAnim = null;
    [SerializeField]
    private GameObject[] portals;
    [SerializeField]
    private PlayerControl control;
    [SerializeField]
    private GameObject elevator = null;

    // Start is called before the first frame update
    private void Start()
    {
        int currState = GameProgress.GetProgress();

        if (currState > 0)
        {
            towersAnim.Play("StartEmerge" + currState);

            if (GameProgress.GetClearState() && currState < 5)
                StartCoroutine(AnimateStairs(currState - 1));
            else if (GameProgress.GetClearState() && currState == 5)
                StartCoroutine(EnableElevator());

            for (int i = 0; i < currState; i++)
            {
                portals[i].SetActive(true);
            }

            if(currState >= 2)
            {
                for(int j = 0; j <= currState-2; j++)
                {
                    stairsAnim[j].Play("DefaultStairs");
                }
            }
        }
    }

    private IEnumerator AnimateStairs(int index)
    {
        yield return new WaitForSeconds(1);
        stairsAnim[index].Play("ShowStairs");

        GameProgress.ClearedStage(false);

        StartCoroutine(DisplayPortal(index));
    }

    private IEnumerator EnableElevator()
    {
        yield return new WaitForSeconds(1);
        control.enabled = false;
        elevator.GetComponent<Animator>().Play("ElevatorEnabled");
        GameProgress.ClearedStage(false);
        yield return new WaitForSeconds(7);
        control.enabled = true;
    }

    private IEnumerator DisplayPortal(int index)
    {
        control.enabled = false;
        SceneFade.instance.Blink();
        yield return new WaitForSeconds(.5f);
        towersAnim.Play("OpenPortal" + index);
        yield return new WaitForSeconds(2f);
        SceneFade.instance.Blink();
        yield return new WaitForSeconds(.5f);
        control.enabled = true;

        GameProgress.NextProgress();
    }

    public IEnumerator InitialSetup()
    {
        towersAnim.Play("TowersEmerge");
        CameraShaker.Instance.ShakeOnce(4f, 3f, 0.5f, 3f);

        yield return new WaitForSeconds(6);
        StartCoroutine(DisplayPortal(0));
    }
}

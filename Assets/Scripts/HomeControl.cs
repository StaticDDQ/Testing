using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeControl : MonoBehaviour
{
    [SerializeField]
    private Animator[] stairsAnim = null;
    [SerializeField]
    private GameObject[] portals;
    [SerializeField]
    private Animator towersAnim = null;

    // Start is called before the first frame update
    private void Start()
    {
        int currState = GameProgress.GetProgress();

        if (currState > 0)
        {
            towersAnim.Play("StartEmerge");

            if(currState > 1)
            {
                switch (currState)
                {
                    case 3:
                        stairsAnim[0].Play("stairEmerge");
                        portals[0].SetActive(true);
                        break;
                    case 4:
                        stairsAnim[0].Play("stairsEmerge");
                        stairsAnim[1].Play("stairsEmerge");
                        portals[0].SetActive(true);
                        portals[1].SetActive(true);
                        break;
                    case 5:
                        stairsAnim[0].Play("stairsEmerge");
                        stairsAnim[1].Play("stairsEmerge");
                        stairsAnim[2].Play("stairsEmerge");
                        portals[0].SetActive(true);
                        portals[1].SetActive(true);
                        portals[2].SetActive(true);
                        break;
                }
                if(GameProgress.GetClearState())
                    StartCoroutine(AnimateStairs(currState - 2));
            }
        }
    }

    private IEnumerator AnimateStairs(int index)
    {
        yield return null;
        stairsAnim[index].Play("drawStairs");
        portals[index].SetActive(true);

        GameProgress.ClearedStage(false);
    }
}

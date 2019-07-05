using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    [SerializeField]
    private List<EventHandle> actions = null;
    public static GameState instance;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void Notify()
    {
        if (actions.Count > 0)
        {
            actions[0].PerformAction();
            actions.RemoveAt(0);
            GameProgress.NextProgress();
        }
    }
}

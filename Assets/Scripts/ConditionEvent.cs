using UnityEngine;

public class ConditionEvent : MonoBehaviour
{
    public static ConditionEvent instance;
    private int completeEvents = 4;
    [SerializeField] private GameObject goal = null;

    private void Start()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(this.gameObject);
    }

    public void CompleteEvent()
    {
        completeEvents--;

        if(completeEvents == 0)
        {
            goal.SetActive(true);
        }
    }

    public void DecompleteEvent()
    {
        completeEvents++;
    }
}

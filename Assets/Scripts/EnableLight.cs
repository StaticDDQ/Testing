using UnityEngine;

public class EnableLight : Interactable
{
    [SerializeField] private LightEnabler[] lights = null;
    [SerializeField] private bool checkAll = false;

    public override void ExecuteEvent()
    {
        if (checkAll)
        {
            bool atleast1 = false;
            foreach(LightEnabler le in lights)
            {
                if (le.GetIsEnabled())
                {
                    atleast1 = true;
                    break;
                }
            }
            if (!atleast1)
                return;
        }

        foreach(LightEnabler le in lights)
        {
            le.SwitchControl();
        }
    }
}

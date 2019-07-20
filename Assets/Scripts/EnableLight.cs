using UnityEngine;

public class EnableLight : Interactable
{
    [SerializeField] LightEnabler[] lights = null;

    public override void ExecuteEvent()
    {
        foreach(LightEnabler le in lights)
        {
            le.SwitchControl();
        }
    }
}

using UnityEngine;

public class EnableLight : Interactable
{
    [SerializeField] private LightEnabler[] lightsOn = null;
    [SerializeField] private LightEnabler[] lightsOff = null;

    public override void ExecuteEvent()
    {
        foreach (LightEnabler le in lightsOn)
        {
            le.TurnOn();
        }

        foreach (LightEnabler le in lightsOff)
        {
            le.TurnOff();
        }
    }
}

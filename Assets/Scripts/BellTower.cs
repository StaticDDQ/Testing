using UnityEngine;

public class BellTower : MonoBehaviour
{
    [SerializeField] private Material selectMat = null;
    [SerializeField] private MeshRenderer[] lightRender = null;
    private bool isNotified = false;

    private void Start()
    {
        if(GameProgress.GetProgress() > 0)
        {
            isNotified = true;
            foreach (MeshRenderer render in lightRender)
            {
                render.material = selectMat;
            }
        }
    }

    // initial interaction, play towers first animation
    public void NotifyEventState()
    {
        if (!isNotified)
        {
            foreach(MeshRenderer render in lightRender){
                render.material = selectMat;
            }
            GameState.instance.Notify();
            isNotified = true;
        }
    }
}

using UnityEngine;
using UnityEngine.UI;

public class Blink : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] private float offset = 1.5f;
    [SerializeField] private float range = 20f;
    [SerializeField] private float cooldown = 10f;
    [SerializeField] private Image cdBar = null;
    [SerializeField] private Transform indicate = null;
    [SerializeField] private float rotateSpeed = 50f;
    private bool canBlink = true;
    private float cdElapsed = 0;

    private void Teleport()
    {
        transform.parent.position = hit.point + hit.normal * offset;
    }

    private void Update()
    {
        if (canBlink)
        {
            if(Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, range) && hit.transform.tag == "Ground")
            {
                indicate.Rotate(0, 0, rotateSpeed * Time.unscaledDeltaTime);

                if (Input.GetKeyDown(KeyCode.F))
                {
                    Teleport();
                    canBlink = false;
                    cdElapsed = cooldown;
                    cdBar.fillAmount = 0;
                    indicate.rotation = Quaternion.identity;
                }
            } else
            {
                indicate.rotation = Quaternion.identity;
            }             
        }

        if (!canBlink)
        {
            cdElapsed -= Time.unscaledDeltaTime;
            cdBar.fillAmount = 1 - cdElapsed / cooldown;
            if (cdElapsed <= 0)
            {
                canBlink = true;
            }
        }
    }
}

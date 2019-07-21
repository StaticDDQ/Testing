using UnityEngine;

public class AnimTrigger : MonoBehaviour
{
    [SerializeField] private Animator anim = null;
    [SerializeField] private string animName = "";

    private void OnTriggerEnter(Collider other)
    {
        anim.Play(animName);
        Destroy(gameObject);
    }
}

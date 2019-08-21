using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeControl : MonoBehaviour
{
    [SerializeField] private float slowTime = 0.05f;
    [SerializeField] private float speedTime = 2f;
    [SerializeField] private float slowLen = 2f;
    [SerializeField] private float duration = 4f;
    private bool timeChanged = false;
    private float timeDuration = 0;

    private float modifier = 1;
    private bool underEffect = false;

    private PostProcessVolume m_Volume;
    private ColorGrading m_ColorGrading;

    private void Start()
    {
        m_ColorGrading = ScriptableObject.CreateInstance<ColorGrading>();
        m_ColorGrading.enabled.Override(true);

        m_Volume = PostProcessManager.instance.QuickVolume(8, 100f, m_ColorGrading);
    }

    // Update is called once per frame
    void Update()
    {
        if (timeChanged && !GameProgress.GetPaused())
        {
            timeDuration -= Time.unscaledDeltaTime;
            if(timeDuration <= 0)
            {
                timeChanged = false;
                underEffect = false;
            }
        }
        else if(!GameProgress.GetPaused())
        {
            m_ColorGrading.hueShift.value = Mathf.Lerp(m_ColorGrading.hueShift.value, 0f, (1f/slowLen) * Time.unscaledDeltaTime);

            Time.timeScale += modifier * (1f / slowLen) * Time.unscaledDeltaTime;

            Time.timeScale = Mathf.Clamp(Time.timeScale, (modifier == 1) ? 0f : 1f, (modifier == 1) ? 1f : speedTime);
        }

        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Space) && !underEffect && !GameProgress.GetPaused())
        {
            SpeedTime();
        } else if(Input.GetKeyDown(KeyCode.Space) && !underEffect && !GameProgress.GetPaused())
        {
            SlowTime();
        }
    }

    private void SlowTime()
    {
        Time.timeScale = slowTime;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        modifier = 1;
        timeChanged = true;
        timeDuration = duration;

        m_ColorGrading.hueShift.Override(50f);
        underEffect = true;
    }

    private void SpeedTime()
    {
        Time.timeScale = speedTime;
        Time.fixedDeltaTime = Time.timeScale * .02f;
        modifier = -1;
        timeChanged = true;
        timeDuration = duration;

        m_ColorGrading.hueShift.Override(-50f);
        underEffect = true;
    }
}

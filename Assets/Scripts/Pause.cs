using UnityEngine;

public class Pause : MonoBehaviour
{
    private GameObject pauseScreen;
    private bool isPaused = false;
    private float currTime = 0;

    private void Start()
    {
        pauseScreen = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
            GameProgress.SetPaused(isPaused);

            if (isPaused)
            {
                currTime = Time.timeScale;
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = currTime;
            }

            pauseScreen.SetActive(isPaused);
        }
    }
}

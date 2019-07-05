using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFade: MonoBehaviour {

    public static SceneFade instance;
    [SerializeField]
    private Animator fadeAnim = null;

    // There is only one instance of this and will appear in every scene
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    // when the player wants to load a level
    public void StartLevel(int level)
    {
        StartCoroutine(LoadLevel(level));
    }

    // it will fade in first and wait till the level is ready to be loaded, afterwards it will fade out
    private IEnumerator LoadLevel(int index)
    {
        fadeAnim.Play("fadeIn");
        yield return new WaitForSeconds(1);
        AsyncOperation operation = SceneManager.LoadSceneAsync(index);
        while (!operation.isDone)
        {
            yield return null;
        }
        fadeAnim.Play("fadeOut");
        yield return new WaitForSeconds(2);
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SceneFade: MonoBehaviour {

    public static SceneFade instance;
    [SerializeField] private Animator fadeAnim;
    [SerializeField] private Transform player;

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

    private void AssignVariables()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        fadeAnim = GameObject.FindGameObjectWithTag("FadeScreen").GetComponent<Animator>();
    }

    // when the player wants to load a level
    public void StartLevel(int level, bool home)
    {
        if (home)
        {
            PlayerPrefs.SetString("lastLoadedScene", SceneManager.GetActiveScene().name);

            GameProgress.SetPos(player.position);
            GameProgress.SetRot(player.GetChild(0).eulerAngles);
            player.GetComponent<PlayerControl>().enabled = false;

            StartCoroutine(LoadLevel(level));
        }
        else
        {
            string scene = PlayerPrefs.GetString("lastLoadedScene");
            StartCoroutine(LoadLevel(scene));
        }
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

        AssignVariables();

        fadeAnim.Play("fadeOut");
    }

    private IEnumerator LoadLevel(string sceneName)
    {
        fadeAnim.Play("fadeIn");
        yield return new WaitForSeconds(1);
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            yield return null;
        }

        AssignVariables();

        Quaternion newRot = Quaternion.Euler(GameProgress.GetRot() + new Vector3(0f, 180f, 0f));

        player.GetChild(0).GetComponent<CameraMovement>().SetOriginal(newRot);
        player.GetChild(0).localRotation = newRot;
        player.position = GameProgress.GetPos();

        fadeAnim.Play("fadeOut");
    }
}

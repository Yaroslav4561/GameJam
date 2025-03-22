using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim; // ✅ Змінив Animation → Animator

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        if (nextSceneIndex >= SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        StartCoroutine(loadLevel(nextSceneIndex));
    }

    IEnumerator loadLevel(int nextSceneIndex)
    {
        transitionAnim.SetTrigger("End"); 
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(nextSceneIndex);
        transitionAnim.SetTrigger("Start");
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }
}

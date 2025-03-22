using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController instance;
    [SerializeField] Animator transitionAnim;

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
        int nextSceneIndex;

        // Якщо ми на другій сцені (індекс 1), переходимо на першу сцену (індекс 0)
        if (currentSceneIndex == 1)
        {
            nextSceneIndex = 0; // Повертаємося на першу сцену
        }
        else
        {
            nextSceneIndex = currentSceneIndex + 1; // Інакше просто йдемо до наступної сцени
        }

        StartCoroutine(LoadLevel(nextSceneIndex));
    }

    IEnumerator LoadLevel(int nextSceneIndex)
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

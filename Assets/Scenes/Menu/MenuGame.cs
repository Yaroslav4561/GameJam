using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuGame : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Level 1"); 
    }

    public void QuitGame()
    {
        Application.Quit(); 
        Debug.Log("Гра закрита!"); 
    }
}

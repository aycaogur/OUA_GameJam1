using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{    
    public void PlayGame()
    {
        //SceneManager.LoadScene("menu"); bu da olabilir
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    //back tusu icin bu kod:
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}

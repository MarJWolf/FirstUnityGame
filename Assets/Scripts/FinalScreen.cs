using UnityEngine.SceneManagement;
using UnityEngine;

public class FinalScreen : MonoBehaviour
{
    public void Menu()
    {
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

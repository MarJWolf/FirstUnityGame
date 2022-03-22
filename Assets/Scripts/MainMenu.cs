using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        float timer = Time.realtimeSinceStartup;
        AudioManager.Instance.sounds[4].source.Pause();
        AudioManager.Instance.Play("EndTheme");
       // while(Time.realtimeSinceStartup <= timer + 10f){}//Debug.Log(("in loop"));}
        SceneManager.LoadScene(2);
    }

    public void PlayTutorial()
    {
        float timer = Time.realtimeSinceStartup;
        AudioManager.Instance.sounds[4].source.Pause();
        AudioManager.Instance.sounds[0].source.Play();
        //while(Time.realtimeSinceStartup <= timer + 5f){}
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
 
}

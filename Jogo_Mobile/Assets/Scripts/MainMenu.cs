using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    public void PlayGame()
    {
        SceneManager.LoadScene("Level1");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void ChangeVolume(float newVolume)
    {
        GlobalSettings.singleton.volume = newVolume;
        GlobalSettings.singleton.UpdateVolume();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}

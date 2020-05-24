using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    public void Resume()
    {
        GameManager.state = GameState.PLAYING;
        gameObject.SetActive(false);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}

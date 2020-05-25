using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarUI : MonoBehaviour
{

    [SerializeField]
    private GameObject pauseMenuPrefab = null;


    private GameObject pauseMenu;
    private Canvas canvas;
    private Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        canvas = FindObjectOfType<Canvas>();

        pauseMenu = Instantiate(pauseMenuPrefab, canvas.transform);
        pauseMenu.transform.SetParent(canvas.transform);

        pauseMenu.SetActive(false);
    }

    public void PauseButton()
    {
        GameManager.manager.state = GameState.PAUSED;
        pauseMenu.SetActive(true);
    }
}

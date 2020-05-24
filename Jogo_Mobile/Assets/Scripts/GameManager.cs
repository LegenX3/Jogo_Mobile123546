using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    COUNTDOWN,
    PLAYING,
    PAUSED,
    FINISHED
}

public class GameManager : MonoBehaviour
{

    [HideInInspector]
    public static float timer = 60;
    [HideInInspector]
    public static int score = 0;
    [HideInInspector]
    public static GameState state = new GameState();


    [SerializeField]
    private Text timerText = null;
    [SerializeField]
    private Text scoreText = null;
    [SerializeField]
    private Text countdownText = null;


    private int countdownTimer = 3;

    private int seconds;
    private float deltaTime;   

    private void Start()
    {
        state = GameState.COUNTDOWN;
        deltaTime = Time.fixedDeltaTime;

        StartCoroutine(Countdown());
    }

    private void FixedUpdate()
    {
        if (state == GameState.PLAYING)
        {
            timer -= deltaTime;

            seconds = Mathf.CeilToInt(timer);

            if (timerText != null)
            {
                timerText.text = seconds.ToString();
            }
            if (scoreText != null)
            {
                scoreText.text = score.ToString();
            }

            if (seconds <= 0)
                state = GameState.FINISHED;
        }
    }
    
    private IEnumerator Countdown()
    {
        countdownText.text = countdownTimer.ToString();
        for(int i = 0; i < 3; i++)
        {
            yield return new WaitForSeconds(1f);
            countdownTimer--;
            countdownText.text = countdownTimer.ToString();
        }

        countdownText.enabled = false;
        state = GameState.PLAYING;
    }

}

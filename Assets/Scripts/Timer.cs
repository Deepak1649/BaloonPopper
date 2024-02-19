using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Timer : MonoBehaviour
{
    public float timeRemaining = 5f;
    public bool timerIsRunning = false;
    public TMP_Text timeText;
    

    public PlayfabScript playfabScript;
    public gameScript game;
    
    public GameObject gameovercanvas;
    private void Start()
    {
        // Starts the timer automatically
        timerIsRunning = true;
        playfabScript.Login();
    }

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                game.gameEnd = true;
                timeRemaining = 0;
                timerIsRunning = false;
                gameovercanvas.SetActive(true);
                loadEndScene();
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60); 
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    
    void loadEndScene(){
        SceneManager.LoadScene(2);
    }
}

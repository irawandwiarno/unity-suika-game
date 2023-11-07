using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    public static bool isPaused = false;
    public GameObject UIHandler;
    private UIHandler UIHandlerScript;



    private void Start()
    {
        UIHandlerScript = UIHandler.GetComponent<UIHandler>();
    }

    

    public void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0; // set timescale ke 0 untuk pause game
    }
    public void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1; // set timescale ke 0 untuk pause game
    }


    public void GameOver()
    {
        PauseGame(); // pause game
        UIHandlerScript.GameOver();
    }



}

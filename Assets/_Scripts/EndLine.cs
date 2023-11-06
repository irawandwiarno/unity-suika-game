using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndLine : MonoBehaviour
{
    private float timeInTrigger = 0;
    public static bool isPaused = false;
    public GameObject UIHandler;
    private UIHandler UIHandlerScript;

    private void Start()
    {
        UIHandlerScript = UIHandler.GetComponent<UIHandler>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        timeInTrigger = 0; // reset timer
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Buah buah = other.GetComponent<Buah>();
        if (buah != null)
        {
            timeInTrigger += Time.deltaTime; // tambah waktu yang dihabiskan dalam trigger

            if (timeInTrigger >= 5f && !isPaused) // jika sudah lebih dari 5 detik dan game belum di pause
            {
                PauseGame(); // pause game
                UIHandlerScript.GameOver();
                isPaused = true;
            }
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Buah buah = other.GetComponent<Buah>();
        if (buah != null)
        {
            timeInTrigger = 0; // reset timer
            if (isPaused)
            {
                ResumeGame(); // resume game
                isPaused = false;
            }
        }

    }

    private void PauseGame()
    {
        Time.timeScale = 0; // set timescale ke 0 untuk pause game
    }

    private void ResumeGame()
    {
        Time.timeScale = 1; // set timescale ke 1 untuk resume game
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIHandler : MonoBehaviour
{
    public GameObject PanelScore;

    private void Start()
    {
        PanelScore.SetActive(false);

    }

    public void backMainButton()
    {
        SceneManager.LoadScene("MainMenu");
    }


    public void GameOver()
    {
        PanelScore.SetActive(true);
    }

    public void PlayAgain()
    {
        PanelScore.SetActive(false);
        SceneManager.LoadScene("GamePlay");
    }
}

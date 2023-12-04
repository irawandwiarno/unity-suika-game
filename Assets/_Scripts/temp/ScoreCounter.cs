using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ScoreCounter : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ShowScores();
    }

    private void ShowScores()
    {
        scoreText.text = score.ToString();
        //Menurutku ga perlu pakai kata "Score" cukup font yang mencolok
        //Yang dimana nanti player bakal tahu kalau itu adalah angka score kita
    }//UI Score

    public void AddScores()
    {
        score += 100;
    }//Logic Score
}

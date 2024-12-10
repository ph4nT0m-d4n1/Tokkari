using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameScore : MonoBehaviour
{
    //integer to store score value
    public int score;
    public TextMeshProUGUI scoreText;

    void Start()
    {
        score = 0; //score is at 0 when the game starts
    }

    public void UpdateScore() //this is called when the seal passes in between the pillars
    {
        scoreText.text = "Score" + score.ToString();
    }
}

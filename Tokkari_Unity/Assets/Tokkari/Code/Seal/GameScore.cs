using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine;

public class GameScore : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;
    public GameObject ripText;

    void Start()
    {
        score = 0;
        ripText.SetActive(false);
    }

    void UpdateScore()
    {
        scoreText.text = "Score: " + score.ToString();
        Debug.Log("da cheese has hit the second tower");
    }
}

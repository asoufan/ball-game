using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score;
    public Text scoredisplay;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            score++;
            Debug.Log(score);
        }
    }

    void Update()
    {
        scoredisplay.text = score.ToString();
    }
}

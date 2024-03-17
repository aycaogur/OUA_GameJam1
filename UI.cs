using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public static UI instance;

    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI timerText;
    private int scoreValue;

    private float timerDuration = 120f; 
    private float timer;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        timer = timerDuration;
        UpdateTimer();
    }

    private void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {

            SceneManager.LoadScene("menu"); // menu scene in gercek adi buraya yazilcak
            timer = 0; 
        }

        UpdateTimer();
    }

    private void UpdateTimer()
    {
        int minutes = Mathf.FloorToInt(timer / 60f);
        int seconds = Mathf.FloorToInt(timer % 60f);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void AddScore()
    {
        scoreValue++;
        scoreText.text = scoreValue.ToString();
    }



}

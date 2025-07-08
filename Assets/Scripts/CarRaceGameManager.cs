using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarRaceGameManager : MonoBehaviour
{
    public static CarRaceGameManager instance;
    public GameObject scoreUI;

    public int scorePoint;
    private int score;

    private void Awake()
    {
        instance = this;
        score = 0;
    }


    public GameObject gameOverUI;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ScoreToSpeed();
    }

    public void GameOver()
    {
        gameOverUI.SetActive(true);
        Destroy(RoadManager.Instance);
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene("MenuCarRace");
    }

    public void startGame()
    {
        SceneManager.LoadScene("CarRace");
        Time.timeScale = 1.0f;
    }

    public void IncreaseScore()
    {
        score += scorePoint;

       TextMeshProUGUI scoreText = scoreUI.GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();


    }

    void ScoreToSpeed()
    {
        if (score > 100)
        {
            Car.instance.runSpeed = 23;
            Car.instance.moveSpeed = 9;
            RoadManager.Instance.roadRepeatRate = 0.46f;
            RoadManager.Instance.obstacelSpeed = 7;
        }
        else if (score > 300)
        {
            Car.instance.runSpeed = 26;
            Car.instance.moveSpeed = 10;
            RoadManager.Instance.roadRepeatRate = 0.375f;
            RoadManager.Instance.obstacelSpeed = 9;
        }
        else if (score > 600)
        {
            Car.instance.runSpeed = 29;
            Car.instance.moveSpeed = 10;
            RoadManager.Instance.roadRepeatRate = 0.4f;
            RoadManager.Instance.obstacelSpeed = 11;
        }
        else if (score > 1000)
        {
            Car.instance.runSpeed = 33;
            Car.instance.moveSpeed = 11;
            RoadManager.Instance.roadRepeatRate = 0.35f;
            RoadManager.Instance.obstacelSpeed = 13;

        }

    }

    public void Exit()
    {
        Application.Quit();
    }

    
}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject gameOverUI;

    public GameObject ScoreUI;
    public int scorePoint;
    private int score;

    public GameObject bridgeManager;

    private void Awake()
    {
        instance = this;
        score = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore()
    {
        score += scorePoint;
       TextMeshProUGUI scoreText =  ScoreUI.GetComponent<TextMeshProUGUI>();
        scoreText.text = score.ToString();
    }

   public void GameOver()
    {
        gameOverUI.SetActive(true);
        //Destroy(bridgeManager);
        BridgeManager.instance.bridgePrefab = null;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("MenuNinjaRunner");
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("NinjaRunner");
    }
}

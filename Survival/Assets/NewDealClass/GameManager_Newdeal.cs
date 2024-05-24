using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager_Newdeal : MonoBehaviour
{
    public static GameManager_Newdeal instance;

    public Player player;
    public ObjectPool objectPool;

    bool isGameOver;
    float bestTime;
    float recordTime;

    public float time { get; private set; }
    public TimeSpan timeSpan { get; private set; }



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        Time.timeScale = 1;
        time = 0;
        recordTime = 0;
        isGameOver = false;
    }
    private void Update()
    {
        if (!isGameOver)
        {
            time += Time.deltaTime;
            timeSpan = TimeSpan.FromSeconds(time);
        }
    }

    public void ReStart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("CubeTest");
    }
    public void EndGame(GameObject endingPanel, Text bestTimetext, Text currentTimetext)
    {
        isGameOver = true;
        recordTime = time;
        endingPanel.SetActive(true);

        if (recordTime > PlayerPrefs.GetFloat("currentBsetTime"))
        {
            bestTime = recordTime;
            PlayerPrefs.SetFloat("currentBsetTime", bestTime);
        }

        TimeSpan currentTimeSpan = TimeSpan.FromSeconds(recordTime);
        string currentTimeText = string.Format("Time : {0:00}:{1:00}:{2:00}", currentTimeSpan.Minutes, currentTimeSpan.Seconds, currentTimeSpan.Milliseconds / 10);
        currentTimetext.text = currentTimeText;

        TimeSpan bestTimeSpan = TimeSpan.FromSeconds(PlayerPrefs.GetFloat("currentBsetTime"));
        string bestTimeText = string.Format("BestTime : {0:00}:{1:00}:{2:00}", bestTimeSpan.Minutes, bestTimeSpan.Seconds, bestTimeSpan.Milliseconds / 10);
        bestTimetext.text = bestTimeText;

        Time.timeScale = 0;
    }
}

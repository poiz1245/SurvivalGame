using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] Text uiTimeText;
    [SerializeField] Text uiPlayerHpText;
    [SerializeField] Text uiBestTimeText;
    [SerializeField] Text uiCurrentTimeText;
    [SerializeField] GameObject endingPanel;


    private void Update()
    {
        TimerSetting();
        PlayerHpSetting();

        if(GameManager_Newdeal.instance.player.hp<= 0)
        {
            Ending();
        }
    }

    private void TimerSetting()
    {
        string timeText = string.Format("{0:00}:{1:00}:{2:00}", GameManager_Newdeal.instance.timeSpan.Minutes, GameManager_Newdeal.instance.timeSpan.Seconds, (int)GameManager_Newdeal.instance.timeSpan.Milliseconds / 10);
        uiTimeText.text = timeText;
    }

    void PlayerHpSetting()
    {
        string hpText = string.Format("HP : {0}", GameManager_Newdeal.instance.player.hp);
        uiPlayerHpText.text = hpText;
    }
    void Ending()
    {
        GameManager_Newdeal.instance.EndGame(endingPanel, uiBestTimeText, uiCurrentTimeText);
    }
}

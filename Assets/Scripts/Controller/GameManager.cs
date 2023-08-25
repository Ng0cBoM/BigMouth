using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EgdFoundation;
using TMPro;
using MoreMountains.TopDownEngine;
using MoreMountains.Tools;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager I;

    [SerializeField]
    private float timeMatchSeconds = 50;

    [SerializeField]
    private GameObject[] characterPrefabList;

    private float timeShow;

    public state gameState;
    public int score;

    [SerializeField]
    private Text timeText;

    public enum state
    {
        Start,
        Playing,
        Pause,
        End
    }

    private void Awake()
    {
        gameState = state.Playing;
        score = 0;
        timeShow = timeMatchSeconds;
        if (I == null)
        {
            I = this;
        }
        ChooseCharacterWhenGameStart();
    }

    private void ChooseCharacterWhenGameStart()
    {
        UserData userData = (UserData)MMSaveLoadManager.Load(typeof(UserData), "HighScore.txt", "UserData");
        for (int i = 0; i < characterPrefabList.Length; i++)
        {
            characterPrefabList[i].SetActive(i == userData.currentCharacterId);
        }
    }

    private void Update()
    {
        if (gameState == state.Playing)
        {
            timeShow -= Time.deltaTime;
            if (timeShow <= 0)
            {
                gameState = state.End;
                UpdateHighScore();
                Time.timeScale = 0;
                SignalBus.I.FireSignal<TimeOutSignal>(new TimeOutSignal());
            }
            timeText.text = ((int)timeShow).ToString();
        }
    }

    private void UpdateHighScore()
    {
        UserData userData = (UserData)MMSaveLoadManager.Load(typeof(UserData), "HighScore.txt", "UserData");
        if (score > userData.HighScore)
        {
            userData.HighScore = score;
            MMSaveLoadManager.Save(userData, "HighScore.txt", "UserData");
        }
    }
}
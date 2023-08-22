using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EgdFoundation;
using TMPro;
using MoreMountains.TopDownEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField]
    private int timeMatchSeconds = 50;

    private state gameState;

    private enum state
    {
        Start,
        Playing,
        Pause,
        End
    }

    private void Awake()
    {
        gameState = state.Playing;
    }

    private void Update()
    {
        if (gameState == state.Playing)
        {
            timeMatchSeconds -= Mathf.RoundToInt(Time.deltaTime);
            if (timeMatchSeconds <= 0)
            {
                gameState = state.End;
            }
            GUIManager.Instance.SetTimeText(timeMatchSeconds);
        }
    }
}
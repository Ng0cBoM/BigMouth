using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Tools;
using TMPro;
using System;

public class HomePageView : ScreenItem
{
    [SerializeField] private Button playButton;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int highScore;

    [SerializeField]
    private Button chooseCharacterNextButton;

    [SerializeField]
    private Button chooseCharacterPreviousButton;

    private Action nextCharacter;
    private Action previousCharacter;

    private void Awake()
    {
        playButton.onClick.AddListener(StartGame);
        UserData userData = (UserData)MMSaveLoadManager.Load(typeof(UserData), "HighScore.txt", "UserData");
        highScoreText.text = userData.HighScore.ToString();
    }

    public void StartGame()
    {
        ScenesChanger.ChangeScene("MainGame");
    }

    public override void ReSetup()
    {
    }

    protected override IEnumerator OnPopScreen()
    {
        yield return null;
    }

    protected override IEnumerator OnPushScreen(ScreenData screenData = null)
    {
        yield return null;
    }

    protected override IEnumerator Setup(ScreenData screenData)
    {
        if (screenData == null)
        {
            Debug.LogError("Screen Data Is Null");
            yield return null;
        }
        Debug.Log($"Screen data {screenData.screenAction}");
        nextCharacter = screenData.screenAction["nextCharacter"];
        previousCharacter = screenData.screenAction["previousCharacter"];
        chooseCharacterNextButton.onClick.AddListener(nextCharacter.Invoke);
        chooseCharacterPreviousButton.onClick.AddListener(previousCharacter.Invoke);
        yield return null;
    }
}
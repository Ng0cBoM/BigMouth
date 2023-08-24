using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using MoreMountains.Tools;
using TMPro;

public class HomePageView : ScreenItem
{
    [SerializeField] private Button playButton;
    [SerializeField] private TextMeshProUGUI highScoreText;
    private int highScore;

    private void Awake()
    {
        playButton.onClick.AddListener(StartGame);
        UserData userData = (UserData)MMSaveLoadManager.Load(typeof(UserData), "HighScore", "UserData");
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

    protected override IEnumerator Setup(ScreenData screenData = null)
    {
        yield return null;
    }
}
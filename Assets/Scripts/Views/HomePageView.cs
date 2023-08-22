using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomePageView : ScreenItem
{
    [SerializeField] private Button playButton;

    private void Awake()
    {
        playButton.onClick.AddListener(StartGame);
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
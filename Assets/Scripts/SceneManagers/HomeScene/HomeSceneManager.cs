using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class HomeSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;

    [SerializeField]
    private GameObject currentCharacter;

    private UserData userData;

    private void Start()
    {
        RotateCharacter();
        InitUi();
        userData = (UserData)MMSaveLoadManager.Load(typeof(UserData), "HighScore.txt", "UserData");
        ChooseCharacter();
    }

    private void InitUi()
    {
        ScreenData screenData = new ScreenData();
        screenData.screenAction = new Dictionary<string, Action>()
            {
                { "nextCharacter", NextCharacter },
                { "previousCharacter", PreviousCharacter }
            };
        UiManager.I.Push("HomePage", screenData);
    }

    private void NextCharacter()
    {
        if (userData.currentCharacterId == characterPrefabs.Length - 1)
        {
            userData.currentCharacterId = 0;
        }
        else
        {
            userData.currentCharacterId += 1;
        }
        ChooseCharacter();
        MMSaveLoadManager.Save(userData, "HighScore.txt", "UserData");
    }

    private void PreviousCharacter()
    {
        if (userData.currentCharacterId == 0)
        {
            userData.currentCharacterId = characterPrefabs.Length - 1;
        }
        else
        {
            userData.currentCharacterId -= 1;
        }
        ChooseCharacter();
        MMSaveLoadManager.Save(userData, "HighScore.txt", "UserData");
    }

    private void ChooseCharacter()
    {
        for (int i = 0; i < characterPrefabs.Length; i++)
        {
            characterPrefabs[i].SetActive((i == userData.currentCharacterId));
        }
    }

    private void RotateCharacter()
    {
        currentCharacter.transform.DORotate(new Vector3(0, 360, 0), 3, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
    }
}
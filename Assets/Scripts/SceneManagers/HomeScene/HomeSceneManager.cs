using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HomeSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject[] characterPrefabs;

    [SerializeField]
    private GameObject currentCharacter;

    private UserData userData;

    private void Start()
    {
        RotateCharacter();
        UiManager.I.Push("HomePage", null);
        userData = (UserData)MMSaveLoadManager.Load(typeof(UserData), "HighScore", "UserData");
        //currentCharacter = characterPrefabs[userData.currentCharacterId];
        //ChooseCharacter();
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
        MMSaveLoadManager.Save(userData, "HighScore", "UserData");
        //currentCharacter = characterPrefabs[userData.currentCharacterId];
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
        MMSaveLoadManager.Save(userData, "HighScore", "UserData");
        //currentCharacter = characterPrefabs[userData.currentCharacterId];
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
        currentCharacter.transform.DORotate(new Vector3(0, 360, 0), 2, RotateMode.FastBeyond360)
                .SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
    }
}
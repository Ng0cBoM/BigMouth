using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadingSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        UserData userData = new UserData();
        userData = (UserData)MMSaveLoadManager.Load(typeof(UserData), "HighScore.txt", "UserData");
        if (userData == null)
        {
            MMSaveLoadManager.Save(new UserData(), "HighScore.txt", "UserData");
        }
        ScenesChanger.ChangeScene("Home");
    }
}
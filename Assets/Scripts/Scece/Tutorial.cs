using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [Header("Screen")]
    public GameObject TutorialScreen;
    public GameObject SettingScreen;

    void Awake()
    {
        TutorialScreen.SetActive(false);
        SettingScreen.SetActive(false);
    }

    public void EnableTutorial()
    {
        TutorialScreen.SetActive(true);
    }
    public void EnableSetting()
    {
        SettingScreen.SetActive(true);
    }
    public void DisableSetting()
    {
        SettingScreen.SetActive(false);
    }
}

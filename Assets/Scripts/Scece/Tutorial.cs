using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [Header("Screen")]
    public GameObject TutorialScreen;
    public GameObject SettingScreen;
    // setting
    public GameObject optionsScreen;

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
    // setting
    public void OpenOptions()
    {
        optionsScreen.SetActive(true);
    }
    public void CloseOptions()
    {
        optionsScreen.SetActive(false);
    }
}

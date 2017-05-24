using System.Collections;
using System.Collections.Generic;
using Coroutines;
using RED.Game.Saving;
using RED.UI.Core;
using UnityEngine;

public class SettingsPageController : MonoBehaviour
{
    public Page MainMenuPage;
    public Navigator Navigator;

    public EasyTween Sounds;
    public EasyTween Music;

    private void Start()
    {
        if (GameSettings.Instance.Sounds.Value)
            this.Sounds.OpenCloseObjectAnimation();

        if (GameSettings.Instance.Music.Value)
            this.Music.OpenCloseObjectAnimation();
    }

    public void Save()
    {
        GameSettings.Instance.Music.Value = this.Music.IsObjectOpened();
        GameSettings.Instance.Sounds.Value = this.Sounds.IsObjectOpened();
        GameSaver.Instance.Save();

        this.Navigator.Navigate(this.MainMenuPage).StartCoroutine();
    }
}

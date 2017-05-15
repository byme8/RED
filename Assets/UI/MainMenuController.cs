using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coroutines;
using RED.Levels;
using RED.UI.Core;
using Tweens;
using Tweens.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Page SettingsPage;
    public Page MainMenuPage;

    public GameController GameController;
    public Navigator Navigator;

    public void Play()
    {
        this.PlayCoroutine().StartCoroutine();
    }

    private IEnumerator PlayCoroutine()
    {
        yield return this.MainMenuPage.Hide();
        yield return this.GameController.Play(0);
    }

    public void Settings()
    {
        this.Navigator.Navigate(this.SettingsPage).StartCoroutine();
    }

    public void Quit()
    {
        Debug.Log("Quit");
    }
}

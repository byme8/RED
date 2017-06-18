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
    public GameController GameController;

    public void Play()
    {
        Navigator.Instance.CategoriesPage.Navigate().StartCoroutine();
    }

    public void Settings()
    {
        Navigator.Instance.SettingsPage.Navigate().StartCoroutine();
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Feedback()
    {
        Navigator.Instance.FeedbackPage.Navigate().StartCoroutine();
    }

    public void About()
    {
        Navigator.Instance.AboutPage.Navigate().StartCoroutine();
    }
}

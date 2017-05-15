using System.Collections;
using System.Collections.Generic;
using Coroutines;
using RED.UI.Core;
using UnityEngine;

public class SettingsPageController : MonoBehaviour
{
    public Page MainMenuPage;
    public Navigator Navigator;

    public void Save()
    {
        this.Navigator.Navigate(this.MainMenuPage).StartCoroutine();
    }
}

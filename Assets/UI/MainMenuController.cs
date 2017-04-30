using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuController : MonoBehaviour {

    public GameObject SettingsPage;

    public void Play()
    {
        Debug.Log("Play");
    }

    public void Settings()
    {
        this.gameObject.SetActive(false);
        this.SettingsPage.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("Quit");
    }
}

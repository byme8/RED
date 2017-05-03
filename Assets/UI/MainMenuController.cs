using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RED.Levels;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {

    public GameObject SettingsPage;

    public void Play()
    {
        SceneManager.LoadScene(LevelsManager.Levels.First(), LoadSceneMode.Additive);
        this.gameObject.Disable();
    }

    public void Settings()
    {
        this.gameObject.Disable();
        this.SettingsPage.Enable();
    }

    public void Quit()
    {
        Debug.Log("Quit");
    }
}

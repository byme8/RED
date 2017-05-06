using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Coroutines;
using RED.Levels;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public GameObject SettingsPage;
    public GameController GameController;

    private void Start()
    {
        this.GameController = FindObjectOfType<GameController>();
    }

    public void Play()
    {
        CoroutinesFactory.StartCoroutine(this.PlayCoroutine());
    }

    private IEnumerator PlayCoroutine()
    {
        // wait for ui animation
        yield return new WaitForSeconds(0.1f);

        this.gameObject.Disable();
        yield return this.GameController.Play();
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

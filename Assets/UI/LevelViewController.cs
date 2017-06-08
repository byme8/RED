using System;
using System.Collections;
using System.Collections.Generic;
using Coroutines;
using RED.Levels;
using RED.UI.Core;
using UnityEngine;
using UnityEngine.UI;

public class LevelViewController : MonoBehaviour
{
    public GameController GameController;
    public Text Text;
    public Level Level;

    private void Start()
    {
        this.GameController = GameObject.FindObjectOfType<GameController>();

        this.Text.text = this.Level.Order.ToString();
    }

    public void Play()
    {
        Navigator.Instance.GamePage.Navigate().StartCoroutine();
        this.GameController.Play(this.Level.Index).StartCoroutine();
    }
}

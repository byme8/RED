using System.Collections;
using System.Collections.Generic;
using Coroutines;
using RED.UI.Core;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackViewController : MonoBehaviour
{
    public FeedbackManager FeedbackManager;
    public Text Body;

    public void SendFeedback()
    {
        this.FeedbackManager.Send(this.Body.text);
        this.ToMainMenu();
    }

    public void ToMainMenu()
    {
        Navigator.Instance.StartPage.Navigate().StartCoroutine();
    }
}

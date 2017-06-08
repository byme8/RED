using System.Collections;
using System.Collections.Generic;
using Coroutines;
using RED.UI.Core;
using UnityEngine;

public class CategoriesViewController : MonoBehaviour
{
    public void ToMainMenu()
    {
        Navigator.Instance.StartPage.Navigate().StartCoroutine();
    }
}
